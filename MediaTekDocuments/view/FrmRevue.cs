using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    public partial class FrmRevue : Form
    {
        private Revue revue = null;
        private readonly FrmMediatekController controller;
        private readonly BindingSource bdgRayons = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();
        private readonly BindingSource bdgPeriodicite = new BindingSource();
        private readonly BindingSource bdgGenres = new BindingSource();

        public FrmRevue(Revue revue = null)
        {
            InitializeComponent();
            controller = new FrmMediatekController();
            this.revue = revue;
        }

        private void FrmRevue_Load(object sender, EventArgs e)
        {
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cboRayon);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cboPublic);
            RemplirComboCategorie(controller.GetAllPeriodicites(), bdgPeriodicite, cboPeriodicite);
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cboGenre);

            if (revue != null)
            {
                txtTitre.Text = revue.Titre;
                txtImage.Text = revue.Image;
                txtDelaiDispo.Text = revue.DelaiMiseADispo.ToString();
                cboPeriodicite.SelectedValue = revue.IdPeriodicite;
                cboGenre.SelectedValue = revue.IdGenre;
                cboPublic.SelectedValue = revue.IdPublic;
                cboRayon.SelectedValue = revue.IdRayon;

                btnAjout.Text = "Modifier";
                this.Text = "Modifier une revue";
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

        private Revue CreerRevue()
        {
            string id = revue != null ? revue.Id : controller.GetNextIdRevue();
            string titre = txtTitre.Text;
            string image = txtImage.Text;
            string periodicite = ((Categorie)cboPeriodicite.SelectedItem).Id;
            int delaiDispo = int.Parse(txtDelaiDispo.Text);
            string idGenre = ((Categorie)cboGenre.SelectedItem).Id;
            string genre = ((Categorie)cboGenre.SelectedItem).Libelle;
            string idPublic = ((Categorie)cboPublic.SelectedItem).Id;
            string lePublic = ((Categorie)cboPublic.SelectedItem).Libelle;
            string idRayon = ((Categorie)cboRayon.SelectedItem).Id;
            string rayon = ((Categorie)cboRayon.SelectedItem).Libelle;
            return new Revue(
                id: id,
                titre: titre,
                image: image,
                periodicite: periodicite,
                delaiMiseADispo: delaiDispo,
                idGenre: idGenre,
                genre: genre,
                idPublic: idPublic,
                lePublic: lePublic,
                idRayon: idRayon,
                rayon: rayon
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
            if (cboPeriodicite.SelectedIndex <= 0)
            {
                MessageBox.Show("Veuillez sélectionner une périodicité.", "Erreur");
                cboPeriodicite.Focus();
                return false;
            }
            if (txtDelaiDispo.Text.Equals(""))
            {
                MessageBox.Show("Le délai de mise à disposition est obligatoire.", "Erreur");
                txtDelaiDispo.Focus();
                return false;
            }
            if (!int.TryParse(txtDelaiDispo.Text, out _))
            {
                MessageBox.Show("Le délai doit être un nombre entier.", "Erreur");
                txtDelaiDispo.Focus();
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
            if (cboRayon.SelectedIndex <= 0)
            {
                MessageBox.Show("Veuillez sélectionner un rayon.", "Erreur");
                cboRayon.Focus();
                return false;
            }
            return true;
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            if (ValiderChamps())
            {
                Revue newRevue = CreerRevue();
                if (revue == null)
                {
                    if (controller.CreerRevue(newRevue))
                    {
                        MessageBox.Show("Revue ajoutée avec succès !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout.", "Erreur");
                    }
                }
                else
                {
                    if (controller.ModifierRevue(newRevue))
                    {
                        MessageBox.Show("Revue modifiée avec succès !");
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
