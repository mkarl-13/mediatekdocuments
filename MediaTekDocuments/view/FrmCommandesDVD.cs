using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    /// <summary>
    /// Classe d'affichage
    /// </summary>
    public partial class FrmCommandesDVD : Form
    {
        private readonly FrmMediatekController controller;
        private readonly BindingSource bdgDvdListe = new BindingSource();
        private readonly BindingSource bdgCommandesListe = new BindingSource();
        private readonly BindingSource bdgGenres = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();
        private readonly BindingSource bdgRayons = new BindingSource();
        private readonly BindingSource bdgSuivi = new BindingSource();
        private List<Dvd> lesDvd = new List<Dvd>();
        private List<CommandeLivreDvd> lesCommandes = new List<CommandeLivreDvd>();
        private List<Suivi> lesSuivis = new List<Suivi>();

        #region Recherche
        /// <summary>
        /// Constructeur : création du contrôleur lié à ce formulaire
        /// </summary>
        public FrmCommandesDVD()
        {
            InitializeComponent();
            this.controller = new FrmMediatekController();
        }

        /// <summary>
        /// Ouverture de la fenêtre : 
        /// appel des méthodes pour remplir le datagrid des Dvd et des combos (genre, rayon, public)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCommandesDVD_Load(object sender, EventArgs e)
        {
            lesDvd = controller.GetAllDvd();
            lesSuivis = controller.GetAllSuivis();
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cbxDvdGenres);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cbxDvdPublics);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cbxDvdRayons);
            RemplirDvdListeComplete();
        }

        /// <summary>
        /// Rempli un des 3 combo (genre, public, rayon)
        /// </summary>
        /// <param name="lesCategories">liste des objets de type Genre ou Public ou Rayon</param>
        /// <param name="bdg">bindingsource contenant les informations</param>
        /// <param name="cbx">combobox à remplir</param>
        public void RemplirComboCategorie(List<Categorie> lesCategories, BindingSource bdg, ComboBox cbx)
        {
            bdg.DataSource = lesCategories;
            cbx.DataSource = bdg;
            if (cbx.Items.Count > 0)
            {
                cbx.SelectedIndex = -1;
            }
        }


        private void RemplirComboSuivi(int idSuiviActuel)
        {
            List<Suivi> suivisAutorises = lesSuivis.FindAll(s =>
            {
                if (s.Id == idSuiviActuel) return true;
                if (s.Id < idSuiviActuel) return false;
                if (s.Id == 4 && idSuiviActuel < 3) return false;
                return true;
            });
            cbxSuivi.DataSource = suivisAutorises;
            cbxSuivi.DisplayMember = "Libelle";
            cbxSuivi.ValueMember = "Id";
            cbxSuivi.SelectedValue = idSuiviActuel;
        }

        /// <summary>
        /// Remplit le dategrid avec la liste reçue en paramètre
        /// </summary>
        /// <param name="Dvds">liste de dvds</param>
        private void RemplirDvdListe(List<Dvd> dvds)
        {
            bdgDvdListe.DataSource = dvds;
            dgvDvdListe.DataSource = bdgDvdListe;
            dgvDvdListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDvdListe.Columns["idRayon"].Visible = false;
            dgvDvdListe.Columns["idGenre"].Visible = false;
            dgvDvdListe.Columns["idPublic"].Visible = false;
            dgvDvdListe.Columns["image"].Visible = false;
            dgvDvdListe.Columns["synopsis"].Visible = false;
            dgvDvdListe.Columns["id"].DisplayIndex = 0;
            dgvDvdListe.Columns["titre"].DisplayIndex = 1;
        }

        private void RemplirCommandesListe(List<CommandeLivreDvd> commandes)
        {
            bdgCommandesListe.DataSource = commandes;
            dgvCommandesListe.DataSource = bdgCommandesListe;
            dgvCommandesListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCommandesListe.Columns["Id"].Visible = false;
            dgvCommandesListe.Columns["IdLivreDvd"].Visible = false;
            dgvCommandesListe.Columns["IdSuivi"].Visible = false;
        }

        /// <summary>
        /// Affichage de la liste complète des Dvd
        /// et annulation de toutes les recherches et filtres
        /// </summary>
        private void RemplirDvdListeComplete()
        {
            RemplirDvdListe(lesDvd);
            VideDvdZones();
        }

        /// <summary>
        /// Tri sur les colonnes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDvdListe_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            VideDvdZones();
            string titreColonne = dgvDvdListe.Columns[e.ColumnIndex].HeaderText;
            List<Dvd> sortedList = new List<Dvd>();
            switch (titreColonne)
            {
                case "Id":
                    sortedList = lesDvd.OrderBy(o => o.Id).ToList();
                    break;
                case "Titre":
                    sortedList = lesDvd.OrderBy(o => o.Titre).ToList();
                    break;
                case "Duree":
                    sortedList = lesDvd.OrderBy(o => o.Duree).ToList();
                    break;
                case "Realisateur":
                    sortedList = lesDvd.OrderBy(o => o.Realisateur).ToList();
                    break;
                case "Genre":
                    sortedList = lesDvd.OrderBy(o => o.Genre).ToList();
                    break;
                case "Public":
                    sortedList = lesDvd.OrderBy(o => o.Public).ToList();
                    break;
                case "Rayon":
                    sortedList = lesDvd.OrderBy(o => o.Rayon).ToList();
                    break;
            }
            RemplirDvdListe(sortedList);
        }

        /// <summary>
        /// Sur la sélection d'une ligne ou cellule dans le grid
        /// affichage des informations du dvd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDvdListe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDvdListe.CurrentCell != null)
            {
                try
                {
                    Dvd dvd = (Dvd)bdgDvdListe.List[bdgDvdListe.Position];
                    AfficheDvdInfos(dvd);
                    lesCommandes = controller.GetCommandesLivreDvd(dvd.Id);
                    RemplirCommandesListe(lesCommandes);
                }
                catch
                {
                    VideDvdZones();
                }
            }
            else
            {
                VideDvdInfos();
            }
        }

        /// <summary>
        /// Affichage des informations du dvd sélectionné
        /// </summary>
        /// <param name="dvd">le dvd</param>
        private void AfficheDvdInfos(Dvd dvd)
        {
            txbDvdRealisateur.Text = dvd.Realisateur;
            txbDvdSynopsis.Text = dvd.Synopsis;
            txbDvdImage.Text = dvd.Image;
            txbDvdDuree.Text = dvd.Duree.ToString();
            txbDvdNumero.Text = dvd.Id;
            txbDvdGenre.Text = dvd.Genre;
            txbDvdPublic.Text = dvd.Public;
            txbDvdRayon.Text = dvd.Rayon;
            txbDvdTitre.Text = dvd.Titre;
        }

        /// <summary>
        /// vide les zones de recherche et de filtre
        /// </summary>
        private void VideDvdZones()
        {
            cbxDvdGenres.SelectedIndex = -1;
            cbxDvdRayons.SelectedIndex = -1;
            cbxDvdPublics.SelectedIndex = -1;
            txbDvdNumRecherche.Text = "";
            txbDvdTitreRecherche.Text = "";
        }

        /// <summary>
        /// Vide les zones d'affichage des informations du dvd
        /// </summary>
        private void VideDvdInfos()
        {
            txbDvdRealisateur.Text = "";
            txbDvdSynopsis.Text = "";
            txbDvdImage.Text = "";
            txbDvdDuree.Text = "";
            txbDvdNumero.Text = "";
            txbDvdGenre.Text = "";
            txbDvdPublic.Text = "";
            txbDvdRayon.Text = "";
            txbDvdTitre.Text = "";
        }

        /// <summary>
        /// Filtre sur la catégorie de public
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDvdPublics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDvdPublics.SelectedIndex >= 0)
            {
                txbDvdTitreRecherche.Text = "";
                txbDvdNumRecherche.Text = "";
                Public lePublic = (Public)cbxDvdPublics.SelectedItem;
                List<Dvd> dvdsFiltres = lesDvd.FindAll(x => x.Public.Equals(lePublic.Libelle));
                RemplirDvdListe(dvdsFiltres);
                cbxDvdRayons.SelectedIndex = -1;
                cbxDvdGenres.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur le rayon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDvdRayons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDvdRayons.SelectedIndex >= 0)
            {
                txbDvdTitreRecherche.Text = "";
                txbDvdNumRecherche.Text = "";
                Rayon rayon = (Rayon)cbxDvdRayons.SelectedItem;
                List<Dvd> dvdsFiltres = lesDvd.FindAll(x => x.Rayon.Equals(rayon.Libelle));
                RemplirDvdListe(dvdsFiltres);
                cbxDvdGenres.SelectedIndex = -1;
                cbxDvdPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur le genre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDvdGenres_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxDvdGenres.SelectedIndex >= 0)
            {
                txbDvdTitreRecherche.Text = "";
                txbDvdNumRecherche.Text = "";
                Genre genre = (Genre)cbxDvdGenres.SelectedItem;
                List<Dvd> dvdsFiltres = lesDvd.FindAll(x => x.Genre.Equals(genre.Libelle));
                RemplirDvdListe(dvdsFiltres);
                cbxDvdRayons.SelectedIndex = -1;
                cbxDvdPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Recherche et affichage des Dvd dont le titre matche acec la saisie.
        /// Cette procédure est exécutée à chaque ajout ou suppression de caractère
        /// dans le textBox de saisie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbDvdTitreRecherche_TextChanged(object sender, EventArgs e)
        {
            if (!txbDvdTitreRecherche.Text.Equals(""))
            {
                cbxDvdGenres.SelectedIndex = -1;
                cbxDvdRayons.SelectedIndex = -1;
                cbxDvdPublics.SelectedIndex = -1;
                txbDvdNumRecherche.Text = "";
                List<Dvd> lesDvdParTitre;
                lesDvdParTitre = lesDvd.FindAll(x => x.Titre.ToLower().Contains(txbDvdTitreRecherche.Text.ToLower()));
                RemplirDvdListe(lesDvdParTitre);
            }
            else
            {
                // si la zone de saisie est vide et aucun élément combo sélectionné, réaffichage de la liste complète
                if (cbxDvdGenres.SelectedIndex < 0 && cbxDvdPublics.SelectedIndex < 0 && cbxDvdRayons.SelectedIndex < 0
                    && txbDvdNumRecherche.Text.Equals(""))
                {
                    RemplirDvdListeComplete();
                }
            }
        }

        /// <summary>
        /// Recherche et affichage du Dvd dont on a saisi le numéro.
        /// Si non trouvé, affichage d'un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDvdNumRecherche_Click(object sender, EventArgs e)
        {
            if (!txbDvdNumRecherche.Text.Equals(""))
            {
                txbDvdTitreRecherche.Text = "";
                cbxDvdGenres.SelectedIndex = -1;
                cbxDvdRayons.SelectedIndex = -1;
                cbxDvdPublics.SelectedIndex = -1;
                Dvd dvd = lesDvd.Find(x => x.Id.Equals(txbDvdNumRecherche.Text));
                if (dvd != null)
                {
                    List<Dvd> dvdTrouve = new List<Dvd>() { dvd };
                    RemplirDvdListe(dvdTrouve);
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                    RemplirDvdListeComplete();
                }
            }
            else
            {
                RemplirDvdListeComplete();
            }
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des Dvd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDvdAnnulGenres_Click(object sender, EventArgs e)
        {
            RemplirDvdListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des Dvd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDvdAnnulPublics_Click(object sender, EventArgs e)
        {
            RemplirDvdListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des Dvd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDvdAnnulRayons_Click(object sender, EventArgs e)
        {
            RemplirDvdListeComplete();
        }

        #endregion

        private void dgvCommandesListe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string titreColonne = dgvCommandesListe.Columns[e.ColumnIndex].HeaderText;
            List<CommandeLivreDvd> sortedList = new List<CommandeLivreDvd>();
            switch (titreColonne)
            {
                case "DateCommande":
                    sortedList = lesCommandes.OrderBy(o => o.DateCommande).ToList();
                    break;
                case "Montant":
                    sortedList = lesCommandes.OrderBy(o => o.Montant).ToList();
                    break;
                case "NbExemplaire":
                    sortedList = lesCommandes.OrderBy(o => o.NbExemplaire).ToList();
                    break;
                case "Suivi":
                    sortedList = lesCommandes.OrderBy(o => o.Suivi).ToList();
                    break;
            }
            RemplirCommandesListe(sortedList);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (dgvDvdListe.CurrentCell == null)
            {
                MessageBox.Show("Veuillez sélectionner un DVD.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMontant.Text) || string.IsNullOrWhiteSpace(txtNbExemplaire.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }
            try
            {
                Dvd dvd = (Dvd)bdgDvdListe.List[bdgDvdListe.Position];
                string id = controller.GetNextIdCommande();
                DateTime dateCommande = dtpDate.Value;
                double montant = double.Parse(txtMontant.Text);
                int nbExemplaire = int.Parse(txtNbExemplaire.Text);

                CommandeLivreDvd commande = new CommandeLivreDvd(id, dateCommande, montant, nbExemplaire, dvd.Id, 1, "En cours");

                if (controller.CreerCommandeLivreDvd(commande))
                {
                    MessageBox.Show("Commande ajoutée avec succès.");
                    lesCommandes = controller.GetCommandesLivreDvd(dvd.Id);
                    RemplirCommandesListe(lesCommandes);
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout de la commande.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Veuillez saisir des valeurs numériques valides.");
            }
        }

        private void dgvCommandesListe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCommandesListe.CurrentCell != null)
            {
                CommandeLivreDvd commande = (CommandeLivreDvd)bdgCommandesListe.List[bdgCommandesListe.Position];
                RemplirComboSuivi(commande.IdSuivi);
            }
        }

        private void cbxSuivi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSuivi.SelectedValue == null || dgvCommandesListe.CurrentCell == null)
                return;

            CommandeLivreDvd commande = (CommandeLivreDvd)bdgCommandesListe.List[bdgCommandesListe.Position];
            Suivi suiviSelectionne = (Suivi)cbxSuivi.SelectedItem;
            int nouveauSuivi = suiviSelectionne.Id;

            if (nouveauSuivi == commande.IdSuivi)
                return;

            if (controller.ModifierSuiviCommandeLivreDvd(commande.Id, nouveauSuivi))
            {
                Dvd dvd = (Dvd)bdgDvdListe.List[bdgDvdListe.Position];
                lesCommandes = controller.GetCommandesLivreDvd(dvd.Id);
                RemplirCommandesListe(lesCommandes);
            }
            else
            {
                MessageBox.Show("Erreur lors de la mise à jour du suivi.");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvCommandesListe.CurrentCell != null)
            {
                CommandeLivreDvd commande = (CommandeLivreDvd)bdgCommandesListe.List[bdgCommandesListe.Position];
                if (MessageBox.Show("Voulez-vous confirmer la suppression de cette commande ?",
                    "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (controller.SupprimerCommandeLivreDvd(commande))
                    {
                        lesCommandes = controller.GetCommandesLivreDvd(commande.IdLivreDvd);
                        RemplirCommandesListe(lesCommandes);
                    }
                    else
                    {
                        MessageBox.Show("Suppression impossible : la commande est déjà livrée ou réglée.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtMontant.Text = "";
            txtNbExemplaire.Text = "";
            dtpDate.Text = "";
        }
    }
}
