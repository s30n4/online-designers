using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Profile
{
    public class ProfileProject : Entity
    {
        public virtual Profile Profile { get; set; }
        public virtual Project.Project Project { get; set; }
    }
}
