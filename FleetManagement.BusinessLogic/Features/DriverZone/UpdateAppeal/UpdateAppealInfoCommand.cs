using FleetManagement.Framework.Models.Enums;
using MediatR.Cqrs.Commands;
using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace FleetManagement.BLL.Features.DriverZone.UpdateAppeal
{
    public class UpdateAppealInfoCommand : ICommand<UpdateAppealInfoCommandResult>
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int AppealId { get; set; }

        public AppealType AppealType { get; set; }

        [JsonProperty(PropertyName = "FirstDatePlanning", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public string Message { get; set; }

        public UpdateAppealInfoCommand WithId(int id)
        {
            AppealId = id;
            return this;
        }

    }
}
