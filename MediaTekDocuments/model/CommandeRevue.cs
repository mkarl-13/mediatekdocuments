using System;
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier CommandeRevue
    /// </summary>
    public class CommandeRevue : Commande
    {
        public DateTime DateFinAbonnement { get; }
        public string IdRevue { get; }

        public CommandeRevue(string id, DateTime dateCommande, double montant,
            DateTime dateFinAbonnement, string idRevue) : base(id, dateCommande, montant)
        {
            DateFinAbonnement = dateFinAbonnement;
            IdRevue = idRevue;
        }
    }
}
