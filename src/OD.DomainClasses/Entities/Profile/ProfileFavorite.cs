using System.ComponentModel.DataAnnotations.Schema;
using OD.DomainClasses.Entities.Common;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Profile
{
    [Table("ProfileFavorites", Schema = "Profile")]
    public class ProfileFavorite : Entity
    {
        public virtual Profile Profile { get; set; }
        public virtual Favorite Favorite { get; set; }
    }
}
