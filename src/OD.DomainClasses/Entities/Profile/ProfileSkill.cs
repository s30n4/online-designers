using System.ComponentModel.DataAnnotations.Schema;
using OD.DomainClasses.Entities.Common;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Profile
{
    [Table("ProfileSkills", Schema = "Profile")]
    public class ProfileSkill : Entity
    {
        public virtual Profile Profile { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
