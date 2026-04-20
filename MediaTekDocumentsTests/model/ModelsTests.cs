using MediaTekDocuments.model;

namespace MediaTekDocuments.Tests
{
    [TestClass]
    public class CategorieTests
    {
        [TestMethod]
        public void Constructeur_IdEtLibelleCorrectementInitialises()
        {
            Categorie categorie = new Categorie("10000", "Roman");
            Assert.AreEqual("10000", categorie.Id);
            Assert.AreEqual("Roman", categorie.Libelle);
        }

        [TestMethod]
        public void ToString_RetourneLeLibelle()
        {
            Categorie categorie = new Categorie("10000", "Roman");
            Assert.AreEqual("Roman", categorie.ToString());
        }

        [TestMethod]
        public void Constructeur_AvecValeursVides_ProprietesSontVides()
        {
            Categorie categorie = new Categorie("", "");
            Assert.AreEqual("", categorie.Id);
            Assert.AreEqual("", categorie.Libelle);
        }
    }

    [TestClass]
    public class GenreTests
    {
        [TestMethod]
        public void Constructeur_IdEtLibelleCorrectementInitialises()
        {
            Genre genre = new Genre("00001", "Roman");
            Assert.AreEqual("00001", genre.Id);
            Assert.AreEqual("Roman", genre.Libelle);
        }

        [TestMethod]
        public void Genre_EstUneCategorieEtConserveLeLibelle()
        {
            Genre genre = new Genre("00002", "Science-fiction");
            Assert.IsInstanceOfType(genre, typeof(Categorie));
            Assert.AreEqual("Science-fiction", genre.ToString());
        }
    }

    [TestClass]
    public class PublicTests
    {
        [TestMethod]
        public void Constructeur_IdEtLibelleCorrectementInitialises()
        {
            Public lePublic = new Public("00001", "Adulte");
            Assert.AreEqual("00001", lePublic.Id);
            Assert.AreEqual("Adulte", lePublic.Libelle);
        }

        [TestMethod]
        public void Public_EstUneCategorie()
        {
            Public lePublic = new Public("00002", "Jeunesse");
            Assert.IsInstanceOfType(lePublic, typeof(Categorie));
        }
    }

    [TestClass]
    public class RayonTests
    {
        [TestMethod]
        public void Constructeur_IdEtLibelleCorrectementInitialises()
        {
            Rayon rayon = new Rayon("LV002", "Littérature française");
            Assert.AreEqual("LV002", rayon.Id);
            Assert.AreEqual("Littérature française", rayon.Libelle);
        }

        [TestMethod]
        public void Rayon_EstUneCategorie()
        {
            Rayon rayon = new Rayon("DV001", "Sciences");
            Assert.IsInstanceOfType(rayon, typeof(Categorie));
        }
    }

    [TestClass]
    public class EtatTests
    {
        [TestMethod]
        public void Constructeur_IdEtLibelleCorrectementInitialises()
        {
            Etat etat = new Etat("00001", "Neuf");
            Assert.AreEqual("00001", etat.Id);
            Assert.AreEqual("Neuf", etat.Libelle);
        }

        [TestMethod]
        public void ModificationId_NouvelleValeurPriseEnCompte()
        {
            Etat etat = new Etat("00001", "Neuf");
            etat.Id = "00002";
            Assert.AreEqual("00002", etat.Id);
        }

        [TestMethod]
        public void ModificationLibelle_NouvelleValeurPriseEnCompte()
        {
            Etat etat = new Etat("00001", "Neuf");
            etat.Libelle = "Abîmé";
            Assert.AreEqual("Abîmé", etat.Libelle);
        }
    }

    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void Constructeur_ToutesLesProprietesSontCorrectementInitialisees()
        {
            Document document = new Document("00001", "Titre test", "image.jpg",
                "00001", "Roman", "00001", "Adulte", "BL001", "Beaux Livres");
            Assert.AreEqual("00001", document.Id);
            Assert.AreEqual("Titre test", document.Titre);
            Assert.AreEqual("image.jpg", document.Image);
            Assert.AreEqual("00001", document.IdGenre);
            Assert.AreEqual("Roman", document.Genre);
            Assert.AreEqual("00001", document.IdPublic);
            Assert.AreEqual("Adulte", document.Public);
            Assert.AreEqual("BL001", document.IdRayon);
            Assert.AreEqual("Beaux Livres", document.Rayon);
        }
    }

    [TestClass]
    public class LivreTests
    {
        [TestMethod]
        public void Constructeur_ToutesLesProprietesSontCorrectementInitialisees()
        {
            Livre livre = new Livre("00001", "Les Misérables", "miserables.jpg",
                "978-2-07-040850-4", "Victor Hugo", "Folio",
                "00001", "Roman", "00001", "Adulte", "LV002", "Littérature française");
            Assert.AreEqual("00001", livre.Id);
            Assert.AreEqual("Les Misérables", livre.Titre);
            Assert.AreEqual("miserables.jpg", livre.Image);
            Assert.AreEqual("978-2-07-040850-4", livre.Isbn);
            Assert.AreEqual("Victor Hugo", livre.Auteur);
            Assert.AreEqual("Folio", livre.Collection);
            Assert.AreEqual("00001", livre.IdGenre);
            Assert.AreEqual("Roman", livre.Genre);
            Assert.AreEqual("00001", livre.IdPublic);
            Assert.AreEqual("Adulte", livre.Public);
            Assert.AreEqual("LV002", livre.IdRayon);
            Assert.AreEqual("Littérature française", livre.Rayon);
        }

        [TestMethod]
        public void Livre_EstUnDocument()
        {
            Livre livre = new Livre("00001", "Test", "", "", "", "",
                "00001", "Roman", "00001", "Adulte", "LV002", "Littérature française");
            Assert.IsInstanceOfType(livre, typeof(Document));
        }
    }

    [TestClass]
    public class DvdTests
    {
        [TestMethod]
        public void Constructeur_ToutesLesProprietesSontCorrectementInitialisees()
        {
            Dvd dvd = new Dvd("00001", "Inception", "inception.jpg", 148,
                "Christopher Nolan", "Un voleur pénètre dans les rêves.",
                "00001", "Science-fiction", "00001", "Adulte", "DF001", "DVD films");
            Assert.AreEqual("00001", dvd.Id);
            Assert.AreEqual("Inception", dvd.Titre);
            Assert.AreEqual("inception.jpg", dvd.Image);
            Assert.AreEqual(148, dvd.Duree);
            Assert.AreEqual("Christopher Nolan", dvd.Realisateur);
            Assert.AreEqual("Un voleur pénètre dans les rêves.", dvd.Synopsis);
            Assert.AreEqual("00001", dvd.IdGenre);
            Assert.AreEqual("Science-fiction", dvd.Genre);
            Assert.AreEqual("00001", dvd.IdPublic);
            Assert.AreEqual("Adulte", dvd.Public);
            Assert.AreEqual("DF001", dvd.IdRayon);
            Assert.AreEqual("DVD films", dvd.Rayon);
        }

        [TestMethod]
        public void Dvd_EstUnDocument()
        {
            Dvd dvd = new Dvd("00001", "Test", "", 0, "", "",
                "00001", "Genre", "00001", "Public", "DF001", "DVD films");
            Assert.IsInstanceOfType(dvd, typeof(Document));
        }
    }

    [TestClass]
    public class RevueTests
    {
        [TestMethod]
        public void Constructeur_ToutesLesProprietesSontCorrectementInitialisees()
        {
            Revue revue = new Revue("00001", "Science & Vie", "sciencevie.jpg",
                "00001", "Sciences", "00001", "Adulte", "PR002", "Magazines",
                "Mensuelle", 30);
            Assert.AreEqual("00001", revue.Id);
            Assert.AreEqual("Science & Vie", revue.Titre);
            Assert.AreEqual("sciencevie.jpg", revue.Image);
            Assert.AreEqual("00001", revue.IdGenre);
            Assert.AreEqual("Sciences", revue.Genre);
            Assert.AreEqual("00001", revue.IdPublic);
            Assert.AreEqual("Adulte", revue.Public);
            Assert.AreEqual("PR002", revue.IdRayon);
            Assert.AreEqual("Magazines", revue.Rayon);
            Assert.AreEqual("Mensuelle", revue.Periodicite);
            Assert.AreEqual(30, revue.DelaiMiseADispo);
        }

        [TestMethod]
        public void ModificationPeriodicite_NouvelleValeurPriseEnCompte()
        {
            Revue revue = new Revue("00001", "Test", "", "00001", "Genre",
                "00001", "Public", "PR001", "Presse quotidienne", "Mensuelle", 30);
            revue.Periodicite = "Hebdomadaire";
            Assert.AreEqual("Hebdomadaire", revue.Periodicite);
        }

        [TestMethod]
        public void ModificationDelaiMiseADispo_NouvelleValeurPriseEnCompte()
        {
            Revue revue = new Revue("00001", "Test", "", "00001", "Genre",
                "00001", "Public", "PR001", "Presse quotidienne", "Mensuelle", 30);
            revue.DelaiMiseADispo = 15;
            Assert.AreEqual(15, revue.DelaiMiseADispo);
        }

        [TestMethod]
        public void Revue_EstUnDocument()
        {
            Revue revue = new Revue("00001", "Test", "", "00001", "Genre",
                "00001", "Public", "PR002", "Magazines", "Mensuelle", 30);
            Assert.IsInstanceOfType(revue, typeof(Document));
        }
    }

    [TestClass]
    public class ExemplaireTests
    {
        [TestMethod]
        public void Constructeur_ToutesLesProprietesSontCorrectementInitialisees()
        {
            DateTime dateAchat = new DateTime(2025, 3, 15);
            Exemplaire exemplaire = new Exemplaire(1, dateAchat, "photo.jpg", "00001", "00001");
            Assert.AreEqual(1, exemplaire.Numero);
            Assert.AreEqual(dateAchat, exemplaire.DateAchat);
            Assert.AreEqual("photo.jpg", exemplaire.Photo);
            Assert.AreEqual("00001", exemplaire.IdEtat);
            Assert.AreEqual("00001", exemplaire.Id);
        }

        [TestMethod]
        public void ModificationIdEtat_NouvelleValeurPriseEnCompte()
        {
            Exemplaire exemplaire = new Exemplaire(1, DateTime.Now, "", "00001", "00001");
            exemplaire.IdEtat = "00003";
            Assert.AreEqual("00003", exemplaire.IdEtat);
        }

        [TestMethod]
        public void ModificationPhoto_NouvelleValeurPriseEnCompte()
        {
            Exemplaire exemplaire = new Exemplaire(1, DateTime.Now, "ancienne.jpg", "00001", "00001");
            exemplaire.Photo = "nouvelle.jpg";
            Assert.AreEqual("nouvelle.jpg", exemplaire.Photo);
        }
    }

    [TestClass]
    public class CommandeTests
    {
        [TestMethod]
        public void Constructeur_ToutesLesProprietesSontCorrectementInitialisees()
        {
            DateTime dateCommande = new DateTime(2025, 1, 10);
            Commande commande = new CommandeLivreDvd("00001", dateCommande, 29.90, 3, "00001", 1, "En cours");
            Assert.AreEqual("00001", commande.Id);
            Assert.AreEqual(dateCommande, commande.DateCommande);
            Assert.AreEqual(29.90, commande.Montant, 0.001);
        }
    }

    [TestClass]
    public class CommandeLivreDvdTests
    {
        [TestMethod]
        public void Constructeur_ToutesLesProprietesSontCorrectementInitialisees()
        {
            DateTime dateCommande = new DateTime(2025, 2, 1);
            CommandeLivreDvd commande = new CommandeLivreDvd("00001", dateCommande, 49.90, 5, "00001", 2, "Livrée");
            Assert.AreEqual("00001", commande.Id);
            Assert.AreEqual(dateCommande, commande.DateCommande);
            Assert.AreEqual(49.90, commande.Montant, 0.001);
            Assert.AreEqual(5, commande.NbExemplaire);
            Assert.AreEqual("00001", commande.IdLivreDvd);
            Assert.AreEqual(2, commande.IdSuivi);
            Assert.AreEqual("Livrée", commande.Suivi);
        }

        [TestMethod]
        public void CommandeLivreDvd_EstUneCommande()
        {
            CommandeLivreDvd commande = new CommandeLivreDvd("00001", DateTime.Now, 0, 1, "00001", 1, "En cours");
            Assert.IsInstanceOfType(commande, typeof(Commande));
        }
    }

    [TestClass]
    public class CommandeRevueTests2
    {
        [TestMethod]
        public void Constructeur_ToutesLesProprietesSontCorrectementInitialisees()
        {
            DateTime dateCommande = new DateTime(2025, 1, 1);
            DateTime dateFin = new DateTime(2025, 12, 31);
            CommandeRevue commande = new CommandeRevue("00001", dateCommande, 120.00, dateFin, "00001");
            Assert.AreEqual("00001", commande.Id);
            Assert.AreEqual(dateCommande, commande.DateCommande);
            Assert.AreEqual(120.00, commande.Montant, 0.001);
            Assert.AreEqual(dateFin, commande.DateFinAbonnement);
            Assert.AreEqual("00001", commande.IdRevue);
        }

        [TestMethod]
        public void CommandeRevue_EstUneCommande()
        {
            CommandeRevue commande = new CommandeRevue("00001", DateTime.Now, 0, DateTime.Now.AddYears(1), "00001");
            Assert.IsInstanceOfType(commande, typeof(Commande));
        }
    }

    [TestClass]
    public class SuiviTests
    {
        [TestMethod]
        public void Constructeur_IdEtLibelleCorrectementInitialises()
        {
            Suivi suivi = new Suivi(1, "En cours");
            Assert.AreEqual(1, suivi.Id);
            Assert.AreEqual("En cours", suivi.Libelle);
        }

        [TestMethod]
        public void Constructeur_AvecDifferentsEtats_ProprietesSontCorrectementInitialisees()
        {
            Suivi suivi = new Suivi(4, "Réglée");
            Assert.AreEqual(4, suivi.Id);
            Assert.AreEqual("Réglée", suivi.Libelle);
        }
    }
}