namespace FleetManager.EFCore.Models
{
    public class Garage
    {
        public string Id { get; set; }

        public string Naam { get; set; }

        public Contactgegevens Contactgegevens { get; set; }

        public string Ondernemingsnummer { get; set; }

        public string Bankrekeningnummer { get; set; }
    }
}
