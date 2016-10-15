using System.ComponentModel.DataAnnotations.Schema;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Profile
{
    [Table("ProfileHobbies", Schema = "Profile")]
    public class ProfileHobby : Entity
    {
        public virtual Profile Profile { get; set; }
        public virtual Hobby Hoby { get; set; }
    }
}
