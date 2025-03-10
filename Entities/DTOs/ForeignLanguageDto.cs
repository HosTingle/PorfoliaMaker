using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ForeignLanguageDto:IDto
    {
        public int UserId { get; set; }

        public List<ForeignLanguage> ForeignLanguages { get; set; }
    }
}
