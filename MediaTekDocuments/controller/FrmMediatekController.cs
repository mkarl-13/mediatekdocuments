using MediaTekDocuments.dal;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    public class FrmMediatekController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// getter sur les periodicites
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPeriodicites()
        {
            return access.GetAllPeriodicites();
        }


        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }

        /// <summary>
        /// Récupère le prochain id de livre à créer
        /// </summary>
        /// <returns></returns>
        public string GetNextIdLivre()
        {
            return access.GetNextIdLivre();
        }

        /// <summary>
        /// Récupère le prochain id de dvd à créer
        /// </summary>
        /// <returns></returns>
        public string GetNextIdDvd()
        {
            return access.GetNextIdDvd();
        }

        /// <summary>
        /// Récupère le prochain id de revue à créer
        /// </summary>
        /// <returns></returns>
        public string GetNextIdRevue()
        {
            return access.GetNextIdRevue();
        }

        /// <summary>
        /// Récupère le prochain id de commande à créer
        /// </summary>
        /// <returns></returns>
        public string GetNextIdCommande()
        {
            return access.GetNextIdCommande();
        }

        public List<CommandeLivreDvd> GetCommandesLivreDvd(string idLivresDvd)
        {
            return access.GetCommandesLivreDvd(idLivresDvd);
        }

        public List<CommandeRevue> GetCommandesRevue(string idRevue)
        {
            return access.GetCommandesRevue(idRevue);
        }

        public List<Suivi> GetAllSuivis()
        {
            return access.GetAllSuivis();
        }

        /// <summary>
        /// Crée un livre dans la BDD
        /// </summary>
        /// <param name="livre">objet Livre à insérer</param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public bool CreerLivre(Livre livre)
        {
            return access.CreerLivre(livre);
        }

        /// <summary>
        /// Crée un DVD dans la BDD
        /// </summary>
        /// <param name="dvd">objet Dvd à insérer</param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public bool CreerDvd(Dvd dvd)
        {
            return access.CreerDvd(dvd);
        }

        /// <summary>
        /// Crée une revue dans la BDD
        /// </summary>
        /// <param name="revue">objet Revue à insérer</param>
        /// <returns>true si l'insertion a pu se faire</returns>
        public bool CreerRevue(Revue revue)
        {
            return access.CreerRevue(revue);
        }

        /// <summary>
        /// Modifie un livre dans la BDD
        /// </summary>
        /// <param name="livre">objet livre à modifier</param>
        /// <returns>true si la modification a pu se faire</returns>
        public bool ModifierLivre(Livre livre)
        {
            return access.ModifierLivre(livre);
        }

        /// <summary>
        /// Modifie un dvd dans la BDD
        /// </summary>
        /// <param name="dvd">objet dvd à modifier</param>
        /// <returns>true si la modification a pu se faire</returns>
        public bool ModifierDvd(Dvd dvd)
        {
            return access.ModifierDvd(dvd);
        }

        /// <summary>
        /// Modifie une revue dans la BDD
        /// </summary>
        /// <param name="revue">objet revue à modifier</param>
        /// <returns>true si la modification a pu se faire</returns>
        public bool ModifierRevue(Revue revue)
        {
            return access.ModifierRevue(revue);
        }

        /// <summary>
        /// Supprime un livre dans la BDD
        /// </summary>
        /// <param name="id">objet livre à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerLivre(string id)
        {
            return access.SupprimerLivre(id);
        }

        /// <summary>
        /// Supprime un dvd dans la BDD
        /// </summary>
        /// <param name="id">objet dvd à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerDvd(string id)
        {
            return access.SupprimerDvd(id);
        }

        /// <summary>
        /// Supprime une revue dans la BDD
        /// </summary>
        /// <param name="id">objet revue à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerRevue(string id)
        {
            return access.SupprimerRevue(id);
        }

        public bool CreerCommandeLivreDvd(CommandeLivreDvd commande)
        {
            return access.CreerCommandeLivreDvd(commande);
        }

        public bool CreerCommandeRevue(CommandeRevue commande)
        {
            return access.CreerCommandeRevue(commande);
        }

        public bool ModifierSuiviCommandeLivreDvd(string idCommande, int idSuivi)
        {
            return access.ModifierSuiviCommandeLivreDvd(idCommande, idSuivi);
        }

        public bool SupprimerCommandeLivreDvd(CommandeLivreDvd commande)
        {
            if (commande.IdSuivi == 3 || commande.IdSuivi == 4)
            {
                return false;
            }
            return access.SupprimerCommandeLivreDvd(commande.Id);
        }

        public bool SupprimerCommandeRevue(string commandeId)
        {
            return access.SupprimerCommandeRevue(commandeId);
        }

        /// <summary>
        /// Renvoie true si un exemplaire/parution fait partie d'un abonnement
        /// </summary>
        /// <param name="dateCommande"></param>
        /// <param name="dateFinAbonnement"></param>
        /// <param name="dateParution"></param>
        /// <returns></returns>
        public bool ParutionDansAbonnement(
            DateTime dateCommande,
            DateTime dateFinAbonnement,
            DateTime dateParution)
        {
            return dateParution >= dateCommande && dateParution <= dateFinAbonnement;
        }

        public List<CommandeRevue> GetAbonnementsFinProche()
        {
            return access.GetAbonnementsFinProche();
        }
    }
}
