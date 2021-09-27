using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FleetManagement.Framework.Models.Dtos.ShowDtos.ShowDriverDetails;
using static FleetManagement.Framework.Models.Dtos.ShowVehicleInfoDto;

namespace FleetManagement.BLL.Services
{
    public class DriverService 
    {
        public IUnitOfWork _unitOfWork { get; set; } //telkens saven en disposen?

        public DriverService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ShowDriverOverviewDto>> GetDriverOverviews() 
        {
            var readDrivers = await _unitOfWork.Drivers.Include(x => x.Identity.Name);

            var driverDtos = new List<ShowDriverOverviewDto>();
            foreach (var driver in readDrivers)
            {
                var name = driver.Identity.FirstName + driver.Identity.Name;
                var driverDto = new ShowDriverOverviewDto(
                    driver.Id, name, 
                    driver.DriversLicenseType, 
                    driver.InService);

                driverDtos.Add(driverDto);
            }

            return driverDtos;
        }

        public async Task<ShowDriverDetailsDto> GetDriverDetails(string driverId) // all details: id, identity, contactinfo, driverslicensetype, inservice (not fuelcards, vehicles and appeals)
        {
            var readDriver = await _unitOfWork.Drivers.GetByIdWithIncludes(int.Parse(driverId), x => new { x.Identity, x.Contactinfo });

            var identity = new IdentityPersonDto(
                readDriver.Identity.Id,
                readDriver.Identity.Name,
                readDriver.Identity.FirstName,
                readDriver.Identity.NationalInsurancenumber,
                readDriver.Identity.DateOfBirth);

            var contactInfo = new ContactInfoDto(
                readDriver.Contactinfo.Id,
                readDriver.Contactinfo.EmailAddress,
                readDriver.Contactinfo.CellPhoneNumber,
                readDriver.Contactinfo.TelephoneNumber,
                new AddressDto(
                    readDriver.Contactinfo.Address.Id,
                    readDriver.Contactinfo.Address.Street,
                    readDriver.Contactinfo.Address.City,
                    readDriver.Contactinfo.Address.Postcode));

            var driverDetailsDto = new ShowDriverDetailsDto(
                driverId,
                identity,
                contactInfo,
                readDriver.DriversLicenseType,
                readDriver.InService);
            
            return driverDetailsDto;
        }

        public async Task<List<ShowVehicleInfoDto>> GetAllVehicleInfoForDriver(string driverId) 
        {

            var driverVehicles = await _unitOfWork.DriverVehicles.FindMultiple(x => x.Driver.Id == driverId);
            var vehicleIds = driverVehicles.Select(x => x.Vehicle.Id).ToList();

            var vehicleInfoDtos = new List<ShowVehicleInfoDto>();
            foreach (var vehicleId in vehicleIds)
            {
                var vehicleInfoDto = GetSingleVehicleInfoForDriver(vehicleId, driverId);
            }

            return vehicleInfoDtos;
        }

        public async Task<ShowVehicleInfoDto> GetSingleVehicleInfoForDriver(string vehicleId, string driverId)
        {
            //drivervehicle
            var driverVehicle = await _unitOfWork.DriverVehicles.FindSingle(x => x.Driver.Id == driverId);
            var driverVehicleDto = new DriverVehicleDto(
                driverVehicle.Id,
                driverVehicle.Active,
                driverVehicle.CreationDate,
                driverVehicle.ClosureDate);

            //vehicle
            var vehicle = (await _unitOfWork.Vehicles.FindWithIncludes(x => x.Id == vehicleId, x => x.Identity)).FirstOrDefault();

            //identity
            var vehicleIdentity = await _unitOfWork.IdentityVehicles.FindSingle(x => x.Id == vehicle.Identity.Id);
            var vehicleIdentityDto = new VehicleIdentityDto(
                        vehicleIdentity.Id,
                        vehicleIdentity.FuelType,
                        vehicleIdentity.Brand,
                        vehicleIdentity.Model);

            //reparations 
            var reparationInfo = await _unitOfWork.Reparations.FindAndSelect(x => x.Id == vehicleId, x => new { x.Id, x.ReparationStatus, x.IncidentDate, x.InvoiceDate });
            var reparationDtos = new List<VehicleReparationDto>();
            foreach (var reparation in reparationInfo)
            {
                var reparationDto = new VehicleReparationDto(
                    reparation.Id, 
                    reparation.ReparationStatus, 
                    reparation.IncidentDate,
                    reparation.InvoiceDate);
                reparationDtos.Add(reparationDto);
            }

            //maintenance
            var maintenanceInfo = await _unitOfWork.Maintenance.FindAndSelect(x => x.Id == vehicleId, x => new { x.Id, x.InvoiceDate }); ; ;
            var maintenanceDtos = new List<VehicleMaintenanceDto>();
            foreach (var maintenance in maintenanceInfo)
            {
                var maintenanceDto = new VehicleMaintenanceDto(
                    maintenance.Id, 
                    maintenance.InvoiceDate);
                maintenanceDtos.Add(maintenanceDto);
            }

            //Appeals
            var appealInfo = await _unitOfWork.Appeals.FindAndSelect(x => x.Id == vehicleId, x => new { x.Id, x.AppealType, x.Status, x.CreationDate });
            var appealDtos = new List<VehicleAppealDto>();
            foreach (var appeal in appealInfo)
            {
                var aanvraagDto = new VehicleAppealDto(
                    appeal.Id,
                    appeal.AppealType, 
                    appeal.Status, 
                    appeal.CreationDate);
                appealDtos.Add(aanvraagDto);
            }

            //vehicleDto
            var vehicleDto = new VehicleDto(
                   vehicle.Id,
                   vehicleIdentityDto,
                    vehicle.Mileage,
                    maintenanceDtos,
                    reparationDtos,
                    appealDtos);

            var VehicleInfoDto = new ShowVehicleInfoDto(driverVehicleDto, vehicleDto);

            return VehicleInfoDto;
        }

            #region Basic CRUD - VEROUDERD
            public async Task<ShowDriverDto> GetById(string id)
        {
            var readChauffeur = await _unitOfWork.Drivers.GetById(int.Parse(id)); //!! validate the parse? + Does it include the classes in included entities?

            if (readChauffeur != null)
            {
                var chauffeurDto = new DriverDtp(
                readChauffeur.Id,
                readChauffeur.Identity.ConvertIdentiteitPersoon(),
                readChauffeur.Contactgegevens.ConvertContactgegevens(),
                readChauffeur.RijbewijsType,
                readChauffeur.InDienst,
                readChauffeur.Tankkaarten.ConvertTankkaartChauffeurs(),
                readChauffeur.Voertuigen.ConvertChauffeurVoertuigen(),
                readChauffeur.Aanvragen.ConvertReadAanvragen());

                return chauffeurDto;
            }

            return null;
        }
    }
}
