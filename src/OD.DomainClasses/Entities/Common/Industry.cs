using System.ComponentModel.DataAnnotations.Schema;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Common
{
    [Table("Industries", Schema = "Common")]
    public class Industry : TitleEntity
    {
    }
}
