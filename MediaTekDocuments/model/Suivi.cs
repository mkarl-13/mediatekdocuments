namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Suivi
    /// </summary>
    public class Suivi
    {
        public int Id { get; }
        public string Libelle { get; }

        public Suivi(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }
    }
}
