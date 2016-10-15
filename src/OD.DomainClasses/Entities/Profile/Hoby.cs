using System.ComponentModel.DataAnnotations.Schema;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Profile
{
    [Table("Hobbies", Schema = "Profile")]

    public class Hobby : TitleEntity
    {
    }
}
