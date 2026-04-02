using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    public partial class FrmDvd : Form
    {
        private Dvd dvd = null;
        private readonly FrmMediatekController controller;
        private readonly BindingSource bdgGenres = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();

        public FrmDvd(Dvd dvd = null)
        {
            InitializeComponent();
            this.controller = new FrmMediatekController();
            this.dvd = dvd;
        }

        private void FrmDvd_Load(object sender, EventArgs e)
        {
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cboPublic);
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cboGenre);

            if (dvd != null)
            {
                txtTitre.Text = dvd.Titre;
                txtImage.Text = dvd.Image;
                txtRealisateur.Text = dvd.Realisateur;
                txtDuree.Text = dvd.Duree.ToString();
                rtbSynopsis.Text = dvd.Synopsis;
                cboGenre.SelectedValue = dvd.IdGenre;
                cboPublic.SelectedValue = dvd.IdPublic;

                btnAjout.Text = "Modifier";
                this.Text = "Modifier un DVD";
            }
        }

        /// <summary>
        /// Rempli un des 3 combo (genre, public, rayon)
        /// </summary>
        /// <param name="lesCategories">liste des objets de type Genre ou Public ou Rayon</param>
        /// <param name="bdg">bindingsource contenant les informations</param>
        /// <param name="cbx">combobox à remplir</param>
        public void RemplirComboCategorie(List<Categorie> lesCategories, BindingSource bdg, ComboBox cbo)
        {
            lesCategories.Insert(0, new Categorie("", "-- Sélectionner --"));
            bdg.DataSource = lesCategories;
            cbo.DataSource = bdg;
            cbo.DisplayMember = "Libelle";
            cbo.ValueMember = "Id";
            cbo.SelectedIndex = 0;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Dvd CreerDvd()
        {
            string id = dvd != null ? dvd.Id : controller.GetNextIdDvd();
            string titre = txtTitre.Text;
            string image = txtImage.Text;
            string synopsis = rtbSynopsis.Text;
            string realisateur = txtRealisateur.Text;
            int duree = int.Parse(txtDuree.Text);
            string idGenre = ((Categorie)cboGenre.SelectedItem).Id;
            string genre = ((Categorie)cboGenre.SelectedItem).Libelle;
            string idPublic = ((Categorie)cboPublic.SelectedItem).Id;
            string lePublic = ((Categorie)cboPublic.SelectedItem).Libelle;
            return new Dvd(
                id: id,
                titre: titre,
                image: image,
                synopsis: synopsis,
                realisateur: realisateur,
                duree: duree,
                idGenre: idGenre,
                genre: genre,
                idPublic: idPublic,
                lePublic: lePublic,
                idRayon: "DF001",
                rayon: "DVD films"
            );
        }

        private bool ValiderChamps()
        {
            if (txtTitre.Text.Equals(""))
            {
                MessageBox.Show("Le titre est obligatoire.", "Erreur");
                txtTitre.Focus();
                return false;
            }
            if (txtRealisateur.Text.Equals(""))
            {
                MessageBox.Show("Le réalisateur est obligatoire.", "Erreur");
                txtRealisateur.Focus();
                return false;
            }
            if (txtDuree.Text.Equals(""))
            {
                MessageBox.Show("La durée est obligatoire.", "Erreur");
                txtDuree.Focus();
                return false;
            }
            if (!int.TryParse(txtDuree.Text, out _))
            {
                MessageBox.Show("La durée doit être un nombre entier.", "Erreur");
                txtDuree.Focus();
                return false;
            }
            if (cboGenre.SelectedIndex <= 0)
            {
                MessageBox.Show("Veuillez sélectionner un genre.", "Erreur");
                cboGenre.Focus();
                return false;
            }
            if (cboPublic.SelectedIndex <= 0)
            {
                MessageBox.Show("Veuillez sélectionner un public.", "Erreur");
                cboPublic.Focus();
                return false;
            }
            return true;
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            if (ValiderChamps())
            {
                Dvd newDvd = CreerDvd();
                if (dvd == null)
                {
                    if (controller.CreerDvd(newDvd))
                    {
                        MessageBox.Show("DVD ajouté avec succès !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout.", "Erreur");
                    }
                }
                else
                {
                    if (controller.ModifierDvd(newDvd))
                    {
                        MessageBox.Show("DVD modifié avec succès !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification.", "Erreur");
                    }
                }
            }
        }
    }
}
