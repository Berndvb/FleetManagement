namespace FleetManagement.Framework.Models.Dtos
{
    public class ContactgegevensDto
    {
        public string Id { get; set; }

        public string EmailAdres { get; set; }

        public string GsmNummer { get; set; }

        public string Telefoonnummer { get; set; }

        public AdresDto Adres { get; set; }

        public ContactgegevensDto(
            string id,
            string emailAdres,
            string gsmNummer,
            string telefoonnummer,
            AdresDto adres)
        {
            Id = id;
            EmailAdres = emailAdres;
            GsmNummer = gsmNummer;
            Telefoonnummer = telefoonnummer;
            Adres = adres;
        }
    }
}
