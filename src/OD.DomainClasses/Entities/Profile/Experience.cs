using System.ComponentModel.DataAnnotations.Schema;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Profile
{
    [Table("Experiences", Schema = "Profile")]
    public class Experience : TitleStartEndTimeEntity
    {

    }
}
