namespace FleetManagement.Framework.Models.Dtos
{
    public class AdresDto
    {
        public string Id { get; set; }

        public string Straat { get; set; }

        public string Stad { get; set; }

        public string Postcode { get; set; }

        public AdresDto(
            string id, 
            string straat, 
            string stad, 
            string postcode)
        {
            Id = id;
            Straat = straat;
            Stad = stad;
            Postcode = postcode;
        }
    }
}
