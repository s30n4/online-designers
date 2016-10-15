using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Common
{
    [Table("Cities", Schema = "Common")]

    public class City : TitleEntity
    {
        public virtual Province Province { get; set; }


    }
}
