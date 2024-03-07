using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Modules
{
    public record ModuleInfo(string Name, string Path, IEnumerable<string> Policies);
}
