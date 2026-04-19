using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    public partial class FrmCommandesRevues : Form
    {
        private readonly FrmMediatekController controller;
        private readonly BindingSource bdgRevuesListe = new BindingSource();
        private readonly BindingSource bdgCommandesListe = new BindingSource();
        private readonly BindingSource bdgGenres = new BindingSource();
        private readonly BindingSource bdgPublics = new BindingSource();
        private readonly BindingSource bdgRayons = new BindingSource();
        private List<Revue> lesRevues = new List<Revue>();
        private List<CommandeRevue> lesCommandes = new List<CommandeRevue>();

        public FrmCommandesRevues()
        {
            InitializeComponent();
            this.controller = new FrmMediatekController();
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

        /// <summary>
        /// Ouverture de l'onglet Revues : 
        /// appel des méthodes pour remplir le datagrid des revues et des combos (genre, rayon, public)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCommandesRevues_Load(object sender, EventArgs e)
        {
            lesRevues = controller.GetAllRevues();
            RemplirComboCategorie(controller.GetAllGenres(), bdgGenres, cbxGenres);
            RemplirComboCategorie(controller.GetAllPublics(), bdgPublics, cbxPublics);
            RemplirComboCategorie(controller.GetAllRayons(), bdgRayons, cbxRayons);
            RemplirRevuesListeComplete();
        }

        /// <summary>
        /// Remplit le dategrid de liste des revue avec la liste reçue en paramètre
        /// </summary>
        /// <param name="revues"></param>
        private void RemplirRevuesListe(List<Revue> revues)
        {
            bdgRevuesListe.DataSource = revues;
            dgvRevuesListe.DataSource = bdgRevuesListe;
            dgvRevuesListe.Columns["idRayon"].Visible = false;
            dgvRevuesListe.Columns["idGenre"].Visible = false;
            dgvRevuesListe.Columns["idPublic"].Visible = false;
            dgvRevuesListe.Columns["image"].Visible = false;
            dgvRevuesListe.Columns["idPeriodicite"].Visible = false;
            dgvRevuesListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRevuesListe.Columns["id"].DisplayIndex = 0;
            dgvRevuesListe.Columns["titre"].DisplayIndex = 1;
        }

        /// <summary>
        /// Remplit le dategrid de liste des commande avec la liste reçue en paramètre
        /// </summary>
        /// <param name="commandes"></param>
        private void RemplirCommandesListe(List<CommandeRevue> commandes)
        {
            bdgCommandesListe.DataSource = commandes;
            dgvCommandesListe.DataSource = bdgCommandesListe;
            dgvCommandesListe.Columns["id"].Visible = false;
            dgvCommandesListe.Columns["idRevue"].Visible = false;
            dgvCommandesListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCommandesListe.Columns["dateCommande"].DisplayIndex = 0;
            dgvCommandesListe.Columns["dateFinAbonnement"].DisplayIndex = 1;
        }

        /// <summary>
        /// Recherche et affichage de la revue dont on a saisi le numéro.
        /// Si non trouvé, affichage d'un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNumRecherche_Click(object sender, EventArgs e)
        {
            if (!txbNumRecherche.Text.Equals(""))
            {
                txbTitreRecherche.Text = "";
                cbxGenres.SelectedIndex = -1;
                cbxRayons.SelectedIndex = -1;
                cbxPublics.SelectedIndex = -1;
                Revue revue = lesRevues.Find(x => x.Id.Equals(txbNumRecherche.Text));
                if (revue != null)
                {
                    List<Revue> revues = new List<Revue>() { revue };
                    RemplirRevuesListe(revues);
                }
                else
                {
                    MessageBox.Show("numéro introuvable");
                    RemplirRevuesListeComplete();
                }
            }
            else
            {
                RemplirRevuesListeComplete();
            }
        }

        /// <summary>
        /// Recherche et affichage des revues dont le titre matche acec la saisie.
        /// Cette procédure est exécutée à chaque ajout ou suppression de caractère
        /// dans le textBox de saisie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbTitreRecherche_TextChanged(object sender, EventArgs e)
        {
            if (!txbTitreRecherche.Text.Equals(""))
            {
                cbxGenres.SelectedIndex = -1;
                cbxRayons.SelectedIndex = -1;
                cbxPublics.SelectedIndex = -1;
                txbNumRecherche.Text = "";
                List<Revue> lesRevuesParTitre = lesRevues.FindAll(x => x.Titre.ToLower().Contains(txbTitreRecherche.Text.ToLower()));
                RemplirRevuesListe(lesRevuesParTitre);
            }
            else
            {
                // si la zone de saisie est vide et aucun élément combo sélectionné, réaffichage de la liste complète
                if (cbxGenres.SelectedIndex < 0 && cbxPublics.SelectedIndex < 0 && cbxRayons.SelectedIndex < 0
                    && txbNumRecherche.Text.Equals(""))
                {
                    RemplirRevuesListeComplete();
                }
            }
        }

        /// <summary>
        /// Affichage des informations de la revue sélectionné
        /// </summary>
        /// <param name="revue">la revue</param>
        private void AfficheInfos(Revue revue)
        {
            txbPeriodicite.Text = revue.Periodicite;
            txbImage.Text = revue.Image;
            txbDateMiseADispo.Text = revue.DelaiMiseADispo.ToString();
            txbNumero.Text = revue.Id;
            txbGenre.Text = revue.Genre;
            txbPublic.Text = revue.Public;
            txbRayon.Text = revue.Rayon;
            txbTitre.Text = revue.Titre;
        }

        /// <summary>
        /// Vide les zones d'affichage des informations de la reuve
        /// </summary>
        private void VideInfos()
        {
            txbPeriodicite.Text = "";
            txbImage.Text = "";
            txbDateMiseADispo.Text = "";
            txbNumero.Text = "";
            txbGenre.Text = "";
            txbPublic.Text = "";
            txbRayon.Text = "";
            txbTitre.Text = "";
        }

        /// <summary>
        /// Filtre sur le genre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxGenres.SelectedIndex >= 0)
            {
                txbTitreRecherche.Text = "";
                txbNumRecherche.Text = "";
                Genre genre = (Genre)cbxGenres.SelectedItem;
                List<Revue> revues = lesRevues.FindAll(x => x.Genre.Equals(genre.Libelle));
                RemplirRevuesListe(revues);
                cbxRayons.SelectedIndex = -1;
                cbxPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur la catégorie de public
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxPublics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPublics.SelectedIndex >= 0)
            {
                txbTitreRecherche.Text = "";
                txbNumRecherche.Text = "";
                Public lePublic = (Public)cbxPublics.SelectedItem;
                List<Revue> revues = lesRevues.FindAll(x => x.Public.Equals(lePublic.Libelle));
                RemplirRevuesListe(revues);
                cbxRayons.SelectedIndex = -1;
                cbxGenres.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Filtre sur le rayon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRayons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRayons.SelectedIndex >= 0)
            {
                txbTitreRecherche.Text = "";
                txbNumRecherche.Text = "";
                Rayon rayon = (Rayon)cbxRayons.SelectedItem;
                List<Revue> revues = lesRevues.FindAll(x => x.Rayon.Equals(rayon.Libelle));
                RemplirRevuesListe(revues);
                cbxGenres.SelectedIndex = -1;
                cbxPublics.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Sur la sélection d'une ligne ou cellule dans le grid
        /// affichage des informations de la revue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRevuesListe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRevuesListe.CurrentCell != null)
            {
                try
                {
                    Revue revue = (Revue)bdgRevuesListe.List[bdgRevuesListe.Position];
                    AfficheInfos(revue);
                    lesCommandes = controller.GetCommandesRevue(revue.Id);
                    RemplirCommandesListe(lesCommandes);
                }
                catch
                {
                    VideZones();
                }
            }
            else
            {
                VideInfos();
            }
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des revues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnulPublics_Click(object sender, EventArgs e)
        {
            RemplirRevuesListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des revues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnulRayons_Click(object sender, EventArgs e)
        {
            RemplirRevuesListeComplete();
        }

        /// <summary>
        /// Sur le clic du bouton d'annulation, affichage de la liste complète des revues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnulGenres_Click(object sender, EventArgs e)
        {
            RemplirRevuesListeComplete();
        }

        /// <summary>
        /// Affichage de la liste complète des revues
        /// et annulation de toutes les recherches et filtres
        /// </summary>
        private void RemplirRevuesListeComplete()
        {
            RemplirRevuesListe(lesRevues);
            VideZones();
        }

        /// <summary>
        /// vide les zones de recherche et de filtre
        /// </summary>
        private void VideZones()
        {
            cbxGenres.SelectedIndex = -1;
            cbxRayons.SelectedIndex = -1;
            cbxPublics.SelectedIndex = -1;
            txbNumRecherche.Text = "";
            txbTitreRecherche.Text = "";
        }

        /// <summary>
        /// Tri sur les colonnes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRevuesListe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VideZones();
            string titreColonne = dgvRevuesListe.Columns[e.ColumnIndex].HeaderText;
            List<Revue> sortedList = new List<Revue>();
            switch (titreColonne)
            {
                case "Id":
                    sortedList = lesRevues.OrderBy(o => o.Id).ToList();
                    break;
                case "Titre":
                    sortedList = lesRevues.OrderBy(o => o.Titre).ToList();
                    break;
                case "Periodicite":
                    sortedList = lesRevues.OrderBy(o => o.Periodicite).ToList();
                    break;
                case "DelaiMiseADispo":
                    sortedList = lesRevues.OrderBy(o => o.DelaiMiseADispo).ToList();
                    break;
                case "Genre":
                    sortedList = lesRevues.OrderBy(o => o.Genre).ToList();
                    break;
                case "Public":
                    sortedList = lesRevues.OrderBy(o => o.Public).ToList();
                    break;
                case "Rayon":
                    sortedList = lesRevues.OrderBy(o => o.Rayon).ToList();
                    break;
            }
            RemplirRevuesListe(sortedList);
        }

        /// <summary>
        /// Tri sur les colonnes des commandes/abonnements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCommandesListe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VideZones();
            string titreColonne = dgvCommandesListe.Columns[e.ColumnIndex].HeaderText;
            List<CommandeRevue> sortedList = new List<CommandeRevue>();
            switch (titreColonne)
            {
                case "DateCommande":
                    sortedList = lesCommandes.OrderBy(o => o.DateCommande).ToList();
                    break;
                case "DateFinAbonnement":
                    sortedList = lesCommandes.OrderBy(o => o.DateFinAbonnement).ToList();
                    break;
                case "Montant":
                    sortedList = lesCommandes.OrderBy(o => o.Montant).ToList();
                    break;
            }
            RemplirCommandesListe(sortedList);
        }

        /// <summary>
        /// Enregistrement d'un nouvel abonnement / commande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (bdgRevuesListe.Position < 0)
            {
                MessageBox.Show("Veuillez sélectionner une revue.");
                return;
            }

            double montant;
            try
            {
                montant = double.Parse(txbMontant.Text);
                if (montant < 0)
                {
                    MessageBox.Show("Le montant doit être positif.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Montant invalide.");
                return;
            }

            DateTime dateCommande = dtpDebut.Value.Date;
            DateTime dateFinAbonnement = dtpFin.Value.Date;
            if (dateFinAbonnement <= dateCommande)
            {
                MessageBox.Show("La date de fin doit être après la date de commande.");
                return;
            }

            if (MessageBox.Show("Confirmer l'enregistrement ?", "Confirmation",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            Revue revue = (Revue)bdgRevuesListe.List[bdgRevuesListe.Position];
            string id = controller.GetNextIdCommande();
            CommandeRevue commande = new CommandeRevue(
                id, dtpDebut.Value, montant, dtpFin.Value, revue.Id);
            
            if (controller.CreerCommandeRevue(commande))
            {
                MessageBox.Show("Commande enregistrée.");
            }
            else
            {
                MessageBox.Show("Erreur lors de l'enregistrement.");
            }

            List<CommandeRevue> revues = controller.GetCommandesRevue(revue.Id);
            RemplirCommandesListe(revues);
        }

        /// <summary>
        /// Suppression d'une commande / abonnement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (bdgCommandesListe.Position < 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande.");
                return;
            }

            CommandeRevue commande = (CommandeRevue)bdgCommandesListe.List[bdgCommandesListe.Position];
            List<Exemplaire> exemplaires = controller.GetExemplairesRevue(commande.IdRevue);

            foreach (Exemplaire exemplaire in exemplaires)
            {
                if (controller.ParutionDansAbonnement(commande.DateCommande, commande.DateFinAbonnement, exemplaire.DateAchat))
                {
                    MessageBox.Show("Suppression impossible : un exemplaire est rattaché à cette commande.");
                    return;
                }
            }

            if (MessageBox.Show("Confirmer la suppression de cette commande ?", "Confirmation",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            if (controller.SupprimerCommandeRevue(commande.Id))
            {
                MessageBox.Show("Commande supprimée.");

                List<CommandeRevue> revues = controller.GetCommandesRevue(commande.IdRevue);
                RemplirCommandesListe(revues);
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression.");
            }
        }
    }
}
