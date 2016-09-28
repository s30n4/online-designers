using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OD.DomainClasses.Entities.Common;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Profile
{
    public class ProfileFavorite : Entity
    {
        public virtual Profile Profile { get; set; }
        public virtual Favorite Favorite { get; set; }
    }
}
