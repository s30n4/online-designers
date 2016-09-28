using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Common
{
    public class Province : TitleEntity
    {
        public virtual ICollection<City> Cities { get; set; }
        public Province()
        {
            Cities = new HashSet<City>();
        }
    }
}
