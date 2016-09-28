using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Common
{
    public class Country : TitleEntity
    {
        public virtual ICollection<Province> Provinces { get; set; }

        public Country()
        {
            Provinces = new HashSet<Province>();
        }
    }
}
