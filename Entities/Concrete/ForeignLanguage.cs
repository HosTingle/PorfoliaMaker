using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ForeignLanguage:IEntity
    {
        public int ForeignLanguageId {  get; set; }

        public string? Rating {  get; set; }

        public string? WhereDidYouLearn {  get; set; }

        public int UserId { get; set; }

    }
}
