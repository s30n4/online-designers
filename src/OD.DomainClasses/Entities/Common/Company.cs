using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Common
{
    [Table("Companies", Schema = "Common")]
    public class Company : TitleContactEntity
    {
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }


    }
}
