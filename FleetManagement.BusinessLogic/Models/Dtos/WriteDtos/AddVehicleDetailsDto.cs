namespace FleetManagement.BLL.Models.Dtos.WriteDtos
{
    public class AddVehicleDetailsDto
    {
        public int Id { get; set; }

        public AddIdentityVehicleDto Identity { get; set; }

        public int Mileage { get; set; }
    }
}
