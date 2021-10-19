using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Commands;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FleetManagement.BLL.Features.DriverZone.UpdateContactInfo
{
    public class UpdateContactInfoCommand : ICommand<UpdateContactInfoCommandResult>
    {
        [JsonIgnore]
        public int DriverId { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }

        public UpdateContactInfoCommand WithId(int id)
        {
            DriverId = id;
            return this;
        }
    }
}
