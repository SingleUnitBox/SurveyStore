﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.DTO;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Queries
{
    public record GetSurveyEquipmentBySerialNumber(string SerialNumber) : IQuery<SurveyEquipmentDto>;
}
