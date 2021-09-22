namespace FleetManagement.Framework.Models.Dtos
{
    public class GarageDto
    {
        public string Id { get; set; }

        public string Naam { get; set; }

        public ContactgegevensDto Contactgegevens { get; set; }

        public string Ondernemingsnummer { get; set; }

        public string Bankrekeningnummer { get; set; }

        public GarageDto(
            string id,
            string naam,
            ContactgegevensDto contactgegevens,
            string ondernemingsnummer,
            string bankrekeningnummer)
        {
            Id = id;
            Naam = naam;
            Contactgegevens = contactgegevens;
            Ondernemingsnummer = ondernemingsnummer;
            Bankrekeningnummer = bankrekeningnummer;
        }
    }
}
