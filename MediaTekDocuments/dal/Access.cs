using MediaTekDocuments.manager;
using MediaTekDocuments.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {
        /// <summary>
        /// adresse de l'API
        /// </summary>
        private static readonly string uriApi = "http://localhost/rest_mediatekdocuments/";
        /// <summary>
        /// informations de connexion récupérées depuis App.config
        /// </summary>
        private static readonly string authenticationString = "mediatekdocuments.Properties.Settings.mediatek86AuthenticationString";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        private const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        private const string PUT = "PUT";
        /// <summary>
        /// méthode HTTP pour suppression
        /// </summary>
        private const string DELETE = "DELETE";

        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            try
            {
                api = ApiRest.GetInstance(uriApi, GetConnectionStringByName(authenticationString));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if(instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Récupération de la chaîne de connexion
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre", null);
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon", null);
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public", null);
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// Retourne toutes les périodicités disponibles à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPeriodicites()
        {
            IEnumerable<Public> lesPeriodicites = TraitementRecup<Public>(GET, "periodicite", null);
            return new List<Categorie>(lesPeriodicites);
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre", null);
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd", null);
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue", null);
            return lesRevues;
        }


        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocument">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument, null);
            return lesExemplaires;
        }

        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire">exemplaire à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try
            {
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire", "champs=" + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
        /// <param name="message">information envoyée dans l'url</param>
        /// <param name="parametres">paramètres à envoyer dans le body, au format "chp1=val1&chp2=val2&..."</param>
        /// <returns>liste d'objets récupérés (ou liste vide)</returns>
        private List<T> TraitementRecup<T> (String methode, String message, String parametres)
        {
            // trans
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message, parametres);
                // extraction du code retourné
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Console.WriteLine("code erreur = " + code + " message = " + (String)retour["message"]);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Erreur lors de l'accès à l'API : "+e.Message);
                Environment.Exit(0);
            }
            return liste;
        }

        /// <summary>
        /// Convertit en json un couple nom/valeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="valeur"></param>
        /// <returns>couple au format json</returns>
        private String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);
            return JsonConvert.SerializeObject(dictionary);
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

        /// <summary>
        /// Retourne le prochain id de livre libre pour l'insertion
        /// </summary>
        /// <returns>Prochain id disponible pour un livre</returns>
        public string GetNextIdLivre()
        {
            List<Document> liste = TraitementRecup<Document>(GET, "nextidlivre", null);
            return liste?[0].Id ?? "00001";
        }

        /// <summary>
        /// Retourne tous les suivis à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetAllSuivis()
        {
            List<Suivi> lesSuivis = TraitementRecup<Suivi>(GET, "suivi", null);
            return lesSuivis;
        }

        /// <summary>
        /// Retourne le prochain id de dvd libre pour l'insertion
        /// </summary>
        /// <returns>Prochain id disponible pour un dvd</returns>
        public string GetNextIdDvd()
        {
            List<Document> liste = TraitementRecup<Document>(GET, "nextiddvd", null);
            return liste?[0].Id ?? "20001";
        }

        /// <summary>
        /// Retourne le prochain id de revue libre pour l'insertion
        /// </summary>
        /// <returns>Prochain id disponible pour une revue</returns>
        public string GetNextIdRevue()
        {
            List<Document> liste = TraitementRecup<Document>(GET, "nextidrevue", null);
            return liste?[0].Id ?? "10001";
        }

        /// <summary>
        /// Retourne le prochain id de commande libre pour l'insertion
        /// </summary>
        /// <returns>Prochain id disponible pour une commande</returns>
        public string GetNextIdCommande()
        {
            List<Document> liste = TraitementRecup<Document>(GET, "nextidcommande", null);
            return liste?[0].Id ?? "00001";
        }

        /// <summary>
        /// Crée un livre dans les tables document, livres_dvd et livre
        /// </summary>
        /// <param name="livre">objet Livre à insérer</param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public bool CreerLivre(Livre livre)
        {
            string jsonLivre = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id",         livre.Id },
                { "titre",      livre.Titre },
                { "image",      livre.Image },
                { "idGenre",    livre.IdGenre },
                { "idPublic",   livre.IdPublic },
                { "idRayon",    livre.IdRayon },
                { "ISBN",       livre.Isbn },
                { "auteur",     livre.Auteur },
                { "collection", livre.Collection }
            });
            try
            {
                JObject retour = api.RecupDistant(POST, "insertlivre", "champs=" + jsonLivre);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Crée un dvd dans les tables document, livres_dvd et dvd
        /// </summary>
        /// <param name="dvd">objet Dvd à insérer</param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public bool CreerDvd(Dvd dvd)
        {
            string jsonDvd = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id",          dvd.Id },
                { "titre",       dvd.Titre },
                { "image",       dvd.Image },
                { "idGenre",     dvd.IdGenre },
                { "idPublic",    dvd.IdPublic },
                { "idRayon",     dvd.IdRayon },
                { "synopsis",    dvd.Synopsis },
                { "realisateur", dvd.Realisateur },
                { "duree",       dvd.Duree }
            });
            try
            {
                JObject retour = api.RecupDistant(POST, "insertdvd", "champs=" + jsonDvd);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Crée une revue dans les tables document et revue
        /// </summary>
        /// <param name="revue">objet Revue à insérer</param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public bool CreerRevue(Revue revue)
        {
            string jsonRevue = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id",              revue.Id },
                { "titre",           revue.Titre },
                { "image",           revue.Image },
                { "idGenre",         revue.IdGenre },
                { "idPublic",        revue.IdPublic },
                { "idRayon",         revue.IdRayon },
                { "periodicite",     revue.Periodicite },
                { "delaiMiseADispo", revue.DelaiMiseADispo }
            });
            try
            {
                JObject retour = api.RecupDistant(POST, "insertrevue", "champs=" + jsonRevue);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Modifie un livre dans les tables document et livre
        /// </summary>
        /// <param name="livre">objet livre à modifier</param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public bool ModifierLivre(Livre livre)
        {
            string jsonLivre = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id",         livre.Id },
                { "titre",      livre.Titre },
                { "image",      livre.Image },
                { "idGenre",    livre.IdGenre },
                { "idPublic",   livre.IdPublic },
                { "idRayon",    livre.IdRayon },
                { "ISBN",       livre.Isbn },
                { "auteur",     livre.Auteur },
                { "collection", livre.Collection }
            });
            try
            {
                JObject retour = api.RecupDistant(PUT, "updatelivre", "champs=" + jsonLivre);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Modifie un dvd dans les tables document et dvd
        /// </summary>
        /// <param name="dvd">objet Dvd à modifier</param>
        /// <returns>true si la modification a pu se faire</returns>
        public bool ModifierDvd(Dvd dvd)
        {
            string jsonDvd = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id",          dvd.Id },
                { "titre",       dvd.Titre },
                { "image",       dvd.Image },
                { "idGenre",     dvd.IdGenre },
                { "idPublic",    dvd.IdPublic },
                { "idRayon",     dvd.IdRayon },
                { "synopsis",    dvd.Synopsis },
                { "realisateur", dvd.Realisateur },
                { "duree",       dvd.Duree }
            });
            try
            {
                JObject retour = api.RecupDistant(PUT, "updatedvd", "champs=" + jsonDvd);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Modifie le suivi d'une commande de livre ou dvd dans la BDD
        /// </summary>
        /// <param name="idCommande">id de la commande à modifier</param>
        /// <param name="idSuivi">nouvel id de suivi</param>
        /// <returns>true si la modification a pu se faire</returns>
        public bool ModifierSuiviCommandeLivreDvd(string idCommande, int idSuivi)
        {
            string jsonCommande = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id", idCommande },
                { "suivi", idSuivi }
            });
            try
            {
                JObject retour = api.RecupDistant(PUT, "updatecommande", "champs=" + jsonCommande);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Modifie une revue dans les tables document et revue
        /// </summary>
        /// <param name="revue">objet Revue à modifier</param>
        /// <returns>true si la modification a pu se faire</returns>
        public bool ModifierRevue(Revue revue)
        {
            string jsonRevue = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id",              revue.Id },
                { "titre",           revue.Titre },
                { "image",           revue.Image },
                { "idGenre",         revue.IdGenre },
                { "idPublic",        revue.IdPublic },
                { "idRayon",         revue.IdRayon },
                { "periodicite",     revue.Periodicite },
                { "delaiMiseADispo", revue.DelaiMiseADispo }
            });
            try
            {
                JObject retour = api.RecupDistant(PUT, "updaterevue", "champs=" + jsonRevue);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Supprime un livre dans les tables exemplaire, livre, livres_dvd et document
        /// </summary>
        /// <param name="id">id du livre à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerLivre(string id)
        {
            string jsonLivre = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id", id }
            });
            try
            {
                JObject retour = api.RecupDistant(DELETE, "deletelivre", "champs=" + jsonLivre);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Supprime un dvd dans les tables dvd, livres_dvd et document
        /// </summary>
        /// <param name="id">id du dvd à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerDvd(string id)
        {
            string jsonDvd = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id", id }
            });
            try
            {
                JObject retour = api.RecupDistant(DELETE, "deletedvd", "champs=" + jsonDvd);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Supprime une revue dans les tables exemplaire, revue et document
        /// </summary>
        /// <param name="id">id de la revue à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerRevue(string id)
        {
            string jsonRevue = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id", id }
            });
            try
            {
                JObject retour = api.RecupDistant(DELETE, "deleterevue", "champs=" + jsonRevue);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Retourne les commandes d'un livre ou dvd à partir de la BDD
        /// </summary>
        /// <param name="idDocument">id du livre ou dvd concerné</param>
        /// <returns>Liste d'objets CommandeLivreDvd</returns>
        public List<CommandeLivreDvd> GetCommandesLivreDvd(string idDocument)
        {
            string jsonIdDocument = convertToJson("id", idDocument);
            List<CommandeLivreDvd> lesCommandes = TraitementRecup<CommandeLivreDvd>(GET, "commandeslivresdvd/" + jsonIdDocument, null);
            return lesCommandes;
        }

        /// <summary>
        /// Retourne les abonnements d'une revue à partir de la BDD
        /// </summary>
        /// <param name="idRevue">id de la revue concernée</param>
        /// <returns>Liste d'objets CommandeRevue</returns>
        public List<CommandeRevue> GetCommandesRevue(string idRevue)
        {
            string jsonIdRevue = convertToJson("id", idRevue);
            List<CommandeRevue> lesCommandes = TraitementRecup<CommandeRevue>(GET, "commandesrevues/" + jsonIdRevue, null);
            return lesCommandes;
        }

        /// <summary>
        /// Crée une commande dans les tables commande et commandedocument
        /// </summary>
        /// <param name="commande">objet Commande à insérer</param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public bool CreerCommandeLivreDvd(CommandeLivreDvd commande)
        {
            string jsonCommande = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id",           commande.Id },
                { "dateCommande", commande.DateCommande },
                { "montant",      commande.Montant },
                { "nbExemplaire", commande.NbExemplaire },
                { "idLivreDvd",   commande.IdLivreDvd },
                { "suivi",        commande.IdSuivi }
            }, new CustomDateTimeConverter());
            try
            {
                JObject retour = api.RecupDistant(POST, "insertcommande", "champs=" + jsonCommande);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Crée une commande/abonnement dans les tables commande et abonnement
        /// </summary>
        /// <param name="commande">objet CommandeRevue à insérer</param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public bool CreerCommandeRevue(CommandeRevue commande)
        {
            string jsonCommande = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id",                commande.Id },
                { "dateCommande",      commande.DateCommande },
                { "montant",           commande.Montant },
                { "dateFinAbonnement", commande.DateFinAbonnement },
                { "idRevue",           commande.IdRevue }
            }, new CustomDateTimeConverter());
            try
            {
                JObject retour = api.RecupDistant(POST, "insertcommanderevue", "champs=" + jsonCommande);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Supprime une commande dans les tables commandedocument et commande
        /// </summary>
        /// <param name="id">id de la commande à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerCommandeLivreDvd(string id)
        {
            string jsonCommande = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id", id }
            });
            try
            {
                JObject retour = api.RecupDistant(DELETE, "deletecommande", "champs=" + jsonCommande);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Supprime un abonnement / commande dans les tables abonnement et commande
        /// </summary>
        /// <param name="id">id de la commande à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerCommandeRevue(string id)
        {
            string jsonCommande = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "id", id }
            });
            try
            {
                JObject retour = api.RecupDistant(DELETE, "deletecommanderevue", "champs=" + jsonCommande);
                string code = (string)retour["code"];
                return code.Equals("200");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Retourne les abonnements dont la fin est proche à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets CommandeRevue</returns>
        public List<CommandeRevue> GetAbonnementsFinProche()
        {
            List<CommandeRevue> lesCommandes = TraitementRecup<CommandeRevue>(GET, "abonnementsfinproche", null);
            return lesCommandes;
        }

        /// <summary>
        /// Vérifie les identifiants de connexion via l'API et retourne l'id du service
        /// </summary>
        /// <param name="login">login de l'utilisateur</param>
        /// <param name="mdp">mot de passe de l'utilisateur</param>
        /// <returns>id du service si authentification réussie, null sinon</returns>
        public string GetVerifierAuthentification(string login, string mdp)
        {
            string json = JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                { "login", login },
                { "mdp", mdp }
            });
            try
            {
                JObject retour = api.RecupDistant(GET, "controleauthentification/" + json, null);
                string code = (string)retour["code"];
                if (code.Equals("200"))
                {
                    string resultString = JsonConvert.SerializeObject(retour["result"]);
                    List<JObject> liste = JsonConvert.DeserializeObject<List<JObject>>(resultString);
                    if (liste != null && liste.Count > 0)
                        return liste[0]["idService"].ToString();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
