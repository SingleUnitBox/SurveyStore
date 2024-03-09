using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Shared.Infrastructure.Api
{
    public class ProducesDefaultContentTypeAttribute : ProducesAttribute
    {
        public ProducesDefaultContentTypeAttribute(Type type) : base(type)
        {
        }

        public ProducesDefaultContentTypeAttribute(params string[] additionalContentTypes)
            : base("application/json", additionalContentTypes)
        {
        }
    }
}
