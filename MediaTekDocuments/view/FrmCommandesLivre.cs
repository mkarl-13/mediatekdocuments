using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    public partial class FrmCommandesLivre : Form
    {
        private readonly FrmMediatekController controller;
        private readonly BindingSource bdgLivresListe = new BindingSource();
        private readonly BindingSource bdgCommandesListe = new BindingSource();
        private readonly BindingSource bdgGenres = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();
        private readonly BindingSource bdgRayons = new BindingSource();
        private List<Livre> lesLivres = new List<Livre>();
        private List<CommandeLivreDvd> lesCommandes = new List<CommandeLivreDvd>();
        private List<Suivi> lesSuivis = new List<Suivi>();

        public FrmCommandesLivre()
        {
            InitializeComponent();
            this.controller = new FrmMediatekController();
        }

        private void FrmCommandesLivre_Load(object sender, EventArgs e)
        {
            lesLivres = controller.GetAllLivres();
            lesSuivis = controller.GetAllSuivis();
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cbxGenres);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cbxPublics);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cbxRayons);
            RemplirLivresListeComplete();
        }

        #region Combos

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

        #endregion

        #region Liste Livres

        private void RemplirLivresListe(List<Livre> livres)
        {
            bdgLivresListe.DataSource = livres;
            dgvLivresListe.DataSource = bdgLivresListe;
            dgvLivresListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLivresListe.Columns["idRayon"].Visible = false;
            dgvLivresListe.Columns["idGenre"].Visible = false;
            dgvLivresListe.Columns["idPublic"].Visible = false;
            dgvLivresListe.Columns["image"].Visible = false;
            dgvLivresListe.Columns["isbn"].Visible = false;
            dgvLivresListe.Columns["id"].DisplayIndex = 0;
            dgvLivresListe.Columns["titre"].DisplayIndex = 1;
        }

        private void RemplirLivresListeComplete()
        {
            RemplirLivresListe(lesLivres);
            VideLivresZones();
        }

        private void dgvLivresListe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VideLivresZones();
            string titreColonne = dgvLivresListe.Columns[e.ColumnIndex].HeaderText;
            List<Livre> sortedList = new List<Livre>();
            switch (titreColonne)
            {
                case "Id":
                    sortedList = lesLivres.OrderBy(o => o.Id).ToList();
                    break;
                case "Titre":
                    sortedList = lesLivres.OrderBy(o => o.Titre).ToList();
                    break;
                case "Auteur":
                    sortedList = lesLivres.OrderBy(o => o.Auteur).ToList();
                    break;
                case "Collection":
                    sortedList = lesLivres.OrderBy(o => o.Collection).ToList();
                    break;
                case "Genre":
                    sortedList = lesLivres.OrderBy(o => o.Genre).ToList();
                    break;
                case "Public":
                    sortedList = lesLivres.OrderBy(o => o.Public).ToList();
                    break;
                case "Rayon":
                    sortedList = lesLivres.OrderBy(o => o.Rayon).ToList();
                    break;
                default:
                    return;
            }
            RemplirLivresListe(sortedList);
        }

        private void dgvLivresListe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLivresListe.CurrentCell != null)
            {
                try
                {
                    Livre livre = (Livre)bdgLivresListe.List[bdgLivresListe.Position];
                    AfficheLivreInfos(livre);
                    lesCommandes = controller.GetCommandesLivreDvd(livre.Id);
                    RemplirCommandesListe(lesCommandes);
                }
                catch
                {
                    VideLivresZones();
                }
            }
            else
            {
                VideLivreInfos();
            }
        }

        private void AfficheLivreInfos(Livre livre)
        {
            txbLivreNumero.Text = livre.Id;
            txbLivreTitre.Text = livre.Titre;
            txbLivreAuteur.Text = livre.Auteur;
            txbLivreIsbn.Text = livre.Isbn;
            txbLivreCollection.Text = livre.Collection;
            txbLivreGenre.Text = livre.Genre;
            txbLivrePublic.Text = livre.Public;
            txbLivreRayon.Text = livre.Rayon;
            txbLivreImage.Text = livre.Image;
        }

        private void VideLivresZones()
        {
            cbxGenres.SelectedIndex = -1;
            cbxRayons.SelectedIndex = -1;
            cbxPublics.SelectedIndex = -1;
            txbLivreNumRecherche.Text = "";
            txbLivreTitreRecherche.Text = "";
        }

        private void VideLivreInfos()
        {
            txbLivreNumero.Text = "";
            txbLivreTitre.Text = "";
            txbLivreAuteur.Text = "";
            txbLivreIsbn.Text = "";
            txbLivreCollection.Text = "";
            txbLivreGenre.Text = "";
            txbLivrePublic.Text = "";
            txbLivreRayon.Text = "";
            txbLivreImage.Text = "";
        }

        #endregion

        #region Filtres et recherche

        private void cbxPublics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPublics.SelectedIndex >= 0)
            {
                txbLivreTitreRecherche.Text = "";
                txbLivreNumRecherche.Text = "";
                Public lePublic = (Public)cbxPublics.SelectedItem;
                List<Livre> livresFiltres = lesLivres.FindAll(x => x.Public.Equals(lePublic.Libelle));
                RemplirLivresListe(livresFiltres);
                cbxRayons.SelectedIndex = -1;
                cbxGenres.SelectedIndex = -1;
            }
        }

        private void cbxRayons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRayons.SelectedIndex >= 0)
            {
                txbLivreTitreRecherche.Text = "";
                txbLivreNumRecherche.Text = "";
                Rayon rayon = (Rayon)cbxRayons.SelectedItem;
                List<Livre> livresFiltres = lesLivres.FindAll(x => x.Rayon.Equals(rayon.Libelle));
                RemplirLivresListe(livresFiltres);
                cbxGenres.SelectedIndex = -1;
                cbxPublics.SelectedIndex = -1;
            }
        }

        private void cbxGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxGenres.SelectedIndex >= 0)
            {
                txbLivreTitreRecherche.Text = "";
                txbLivreNumRecherche.Text = "";
                Genre genre = (Genre)cbxGenres.SelectedItem;
                List<Livre> livresFiltres = lesLivres.FindAll(x => x.Genre.Equals(genre.Libelle));
                RemplirLivresListe(livresFiltres);
                cbxRayons.SelectedIndex = -1;
                cbxPublics.SelectedIndex = -1;
            }
        }

        private void txbLivreTitreRecherche_TextChanged(object sender, EventArgs e)
        {
            if (!txbLivreTitreRecherche.Text.Equals(""))
            {
                cbxGenres.SelectedIndex = -1;
                cbxRayons.SelectedIndex = -1;
                cbxPublics.SelectedIndex = -1;
                txbLivreNumRecherche.Text = "";
                List<Livre> livresParTitre = lesLivres.FindAll(x => x.Titre.ToLower().Contains(txbLivreTitreRecherche.Text.ToLower()));
                RemplirLivresListe(livresParTitre);
            }
            else
            {
                if (cbxGenres.SelectedIndex < 0 && cbxPublics.SelectedIndex < 0 && cbxRayons.SelectedIndex < 0
                    && txbLivreNumRecherche.Text.Equals(""))
                {
                    RemplirLivresListeComplete();
                }
            }
        }

        private void btnLivreNumRecherche_Click(object sender, EventArgs e)
        {
            if (!txbLivreNumRecherche.Text.Equals(""))
            {
                txbLivreTitreRecherche.Text = "";
                cbxGenres.SelectedIndex = -1;
                cbxRayons.SelectedIndex = -1;
                cbxPublics.SelectedIndex = -1;
                Livre livre = lesLivres.Find(x => x.Id.Equals(txbLivreNumRecherche.Text));
                if (livre != null)
                {
                    RemplirLivresListe(new List<Livre>() { livre });
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                    RemplirLivresListeComplete();
                }
            }
            else
            {
                RemplirLivresListeComplete();
            }
        }

        private void btnLivresAnnulGenres_Click(object sender, EventArgs e)
        {
            RemplirLivresListeComplete();
        }

        private void btnlivresAnnulPublics_Click(object sender, EventArgs e)
        {
            RemplirLivresListeComplete();
        }

        private void btnLivresAnnulRayons_Click(object sender, EventArgs e)
        {
            RemplirLivresListeComplete();
        }

        #endregion

        #region Commandes

        private void RemplirCommandesListe(List<CommandeLivreDvd> commandes)
        {
            bdgCommandesListe.DataSource = commandes;
            dgvCommandesListe.DataSource = bdgCommandesListe;
            dgvCommandesListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCommandesListe.Columns["Id"].Visible = false;
            dgvCommandesListe.Columns["IdLivreDvd"].Visible = false;
            dgvCommandesListe.Columns["IdSuivi"].Visible = false;
        }

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
                default:
                    return;
            }
            RemplirCommandesListe(sortedList);
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
                Livre livre = (Livre)bdgLivresListe.List[bdgLivresListe.Position];
                lesCommandes = controller.GetCommandesLivreDvd(livre.Id);
                RemplirCommandesListe(lesCommandes);
            }
            else
            {
                MessageBox.Show("Erreur lors de la mise à jour du suivi.");
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (dgvLivresListe.CurrentCell == null)
            {
                MessageBox.Show("Veuillez sélectionner un livre.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMontant.Text) || string.IsNullOrWhiteSpace(txtNbExemplaire.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }
            try
            {
                Livre livre = (Livre)bdgLivresListe.List[bdgLivresListe.Position];
                string id = controller.GetNextIdCommande();
                DateTime dateCommande = dtpDate.Value;
                double montant = double.Parse(txtMontant.Text);
                int nbExemplaire = int.Parse(txtNbExemplaire.Text);

                CommandeLivreDvd commande = new CommandeLivreDvd(id, dateCommande, montant, nbExemplaire, livre.Id, 1, "En cours");

                if (controller.CreerCommandeLivreDvd(commande))
                {
                    MessageBox.Show("Commande ajoutée avec succès.");
                    lesCommandes = controller.GetCommandesLivreDvd(livre.Id);
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

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvCommandesListe.CurrentCell == null) return;

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

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtMontant.Text = "";
            txtNbExemplaire.Text = "";
            dtpDate.Text = "";
        }

        #endregion
    }
}