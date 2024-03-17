using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Core.Entities;

namespace SurveyStore.Modules.Equipment.Core.Repositories
{
    public interface ISurveyorRepository
    {
        Task AddAsync(Surveyor surveyor);
    }
}
