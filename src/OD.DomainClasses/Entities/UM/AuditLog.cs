using System;
using System.ComponentModel.DataAnnotations.Schema;
using SGE.Framework.Domain.Entities;
using SGE.Framework.Enums;

namespace OD.DomainClasses.Entities.UM
{
    [Table("AuditLogs", Schema = "UM")]
    public class AuditLog : Entity
    {
        #region Ctor

        /// <summary>
        ///     Create One Instance Of <see cref="AuditLog" />
        /// </summary>
        protected AuditLog()
        {
            OperatedOn = DateTime.Now;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        ///     gets or sets Type of  Modification(create,softDelet,Delete,update)
        /// </summary>
        public AuditAction Action { get; set; }

        /// <summary>
        ///     sets or gets description of Log
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     sets or gets when log is operated
        /// </summary>
        public DateTime OperatedOn { get; set; }

        /// <summary>
        ///     sets or gets Type Of Entity
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        ///     gets or sets  Old value of  Properties before modification
        /// </summary>
        public string OldValue { get; set; }

        /// <summary>
        ///     gets or sets XML Base OldValue of Properties (NotMapped)
        /// </summary>
        public string NewValue { get; set; }

        /// <summary>
        ///     gets or sets Identifier Of Entity
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        ///     gets or sets user agent information
        /// </summary>
        public string Agent { get; set; }

        /// <summary>
        ///     gets or sets user's ip address
        /// </summary>
        public string OperantIp { get; set; }


        #endregion Properties

        #region NavigationProperties

        /// <summary>
        ///     sets or gets log's creator
        /// </summary>
        public ApplicationUser Operant { get; set; }

        /// <summary>
        ///     sets or gets identifier of log's creator
        /// </summary>
        public int OperantId { get; set; }

        #endregion NavigationProperties
    }
}
