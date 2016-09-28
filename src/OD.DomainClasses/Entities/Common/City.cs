using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Common
{
    public class City : TitleEntity
    {
        public virtual Province Province { get; set; }


    }
}
