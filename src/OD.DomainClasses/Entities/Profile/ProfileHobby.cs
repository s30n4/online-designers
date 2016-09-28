using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Profile
{
    public class ProfileHobby : Entity
    {
        public virtual Profile Profile { get; set; }
        public virtual Hoby Hoby { get; set; }
    }
}
