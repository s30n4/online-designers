using System.ComponentModel.DataAnnotations.Schema;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Common
{
    [Table("Skills", Schema = "Common")]
    public class Skill : TitleEntity
    {
    }
}
