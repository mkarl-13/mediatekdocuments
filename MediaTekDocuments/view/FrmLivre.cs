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
    public partial class FrmLivre : Form
    {
        private Livre livre = null;
        private readonly FrmMediatekController controller;
        private readonly BindingSource bdgGenres = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();
        private readonly BindingSource bdgRayons = new BindingSource();

        public FrmLivre(Livre livre = null)
        {
            InitializeComponent();
            this.controller = new FrmMediatekController();
            this.livre = livre;
        }

        private void FrmLivre_Load(object sender, EventArgs e)
        {
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cboPublic);
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cboGenre);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cboRayon);

            if (livre != null)
            {
                txtTitre.Text = livre.Titre;
                txtImage.Text = livre.Image;
                txtIsbn.Text = livre.Isbn;
                txtAuteur.Text = livre.Auteur;
                txtCollection.Text = livre.Collection;
                cboGenre.SelectedValue = livre.IdGenre;
                cboPublic.SelectedValue = livre.IdPublic;
                cboRayon.SelectedValue = livre.IdRayon;
                
                btnAjout.Text = "Modifier";
                this.Text = "Modifier un livre";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblAuteur_Click(object sender, EventArgs e)
        {

        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            if (ValiderChamps())
            {
                Livre newLivre = CreerLivre();
                if (livre == null)
                {
                    if (controller.CreerLivre(newLivre))
                    {
                        MessageBox.Show("Livre ajouté avec succès !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout.", "Erreur");
                    }
                } 
                else
                {
                    if (controller.ModifierLivre(newLivre))
                    {
                        MessageBox.Show("Livre modifié avec succès !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification.", "Erreur");
                    }
                }
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

        private Livre CreerLivre()
        {
            string id = livre != null ? livre.Id : controller.GetNextIdLivre();
            string titre = txtTitre.Text;
            string image = txtImage.Text;
            string isbn = txtIsbn.Text;
            string auteur = txtAuteur.Text;
            string collection = txtCollection.Text;

            string idGenre = ((Categorie)cboGenre.SelectedItem).Id;
            string genre = ((Categorie)cboGenre.SelectedItem).Libelle;

            string idPublic = ((Categorie)cboPublic.SelectedItem).Id;
            string lePublic = ((Categorie)cboPublic.SelectedItem).Libelle;

            string idRayon = ((Categorie)cboRayon.SelectedItem).Id;
            string rayon = ((Categorie)cboRayon.SelectedItem).Libelle;

            return new Livre(
                id: id, 
                titre: titre, 
                image: image, 
                isbn: isbn,
                auteur: auteur,
                collection: collection,
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
            if (txtAuteur.Text.Equals(""))
            {
                MessageBox.Show("L'auteur est obligatoire.", "Erreur");
                txtAuteur.Focus();
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
    }
}
