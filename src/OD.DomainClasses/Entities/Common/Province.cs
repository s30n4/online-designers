using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Common
{
    [Table("Provinces", Schema = "Common")]

    public class Province : TitleEntity
    {
        public virtual ICollection<City> Cities { get; set; }
        public Province()
        {
            Cities = new HashSet<City>();
        }
    }
}
