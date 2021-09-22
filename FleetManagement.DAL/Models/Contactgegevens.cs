namespace FleetManagement.Domain.Models
{
    public class Contactgegevens
    {
        public string Id { get; set; }

        public string EmailAdres { get; set; }

        public string GsmNummer { get; set; }

        public string Telefoonnummer { get; set; }

        public Adres Adres { get; set; }
    }
}
