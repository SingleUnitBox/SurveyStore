﻿using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Domain.Collections.Policies
{
    public interface ICollectionPolicy
    {
        bool IsCalibrationDue(Collection collection, string CalibrationStatus);
    }
}