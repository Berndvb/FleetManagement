﻿using System;
using FleetManagement.Framework.Models.Enums;
using MediatR.Cqrs.Commands;

namespace FleetManagement.BLL.Features.DriverZone.UpdateAppealInfo
{
    public class UpdateAppealInfoCommand : ICommand<UpdateAppealInfoCommandResult>
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int AppealId { get; set; }

        public AppealType AppealType { get; set; }

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