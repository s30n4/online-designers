using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Project
{
    [Table("Projects", Schema = "Core")]

    public class Project : Entity
    {
    }
}
