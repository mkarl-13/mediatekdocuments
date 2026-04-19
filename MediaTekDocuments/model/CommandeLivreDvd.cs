using System;
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier CommandeLivreDvd
    /// </summary>
    public class CommandeLivreDvd : Commande
    {
        public int NbExemplaire { get; }
        public string IdLivreDvd { get; }
        public int IdSuivi { get; }
        public string Suivi { get; }

        public CommandeLivreDvd(string id, DateTime dateCommande, double montant,
            int nbExemplaire, string idLivreDvd, int idSuivi, string suivi) : base(id, dateCommande, montant)
        {
            NbExemplaire = nbExemplaire;
            IdLivreDvd = idLivreDvd;
            IdSuivi = idSuivi;
            Suivi = suivi;
        }
    }
}
