using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.UM
{
    [Table("Users", Schema = "UM")]
    public class ApplicationUser : Entity<Guid>
    {
        #region Ctor

        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        public ApplicationUser()
        {
            // EmailConfirmed = true;
            RegisterDate = DateTime.Now;
            IsApproved = false;
            IsBanned = false;
            AuditLogs = new HashSet<AuditLog>();
            UserTokens = new List<UserToken>();
        }

        #endregion Ctor

        #region Properties

        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid username")]
        [Required]
        [MinLength(4), MaxLength(30)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// نشاندهنده قفل بودن کاربر است
        ///
        /// </summary>
        public bool IsBanned { get; set; }

        /// <summary>
        /// تاریخ آخرین ورود کاربر
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        public bool IsApproved { get; set; }

        /// <summary>
        /// gets or sets the last Date that password was changed
        /// </summary>
        public DateTime? LastPasswordChangedDate { get; set; }

        /// <summary>
        /// gets or sets date that this user was banned
        /// </summary>
        public DateTime? BannedDate { get; set; }

        /// <summary>
        /// gets or sets the reason of ban
        /// </summary>
        [MaxLength(500)]
        public string BannedReason { get; set; }

        /// <summary>
        /// gets or sets That Date of User's Last Activity
        /// </summary>
        public DateTime? LastActivityOn { get; set; }

        /// <summary>
        /// gets or sets Name Of User For Show in System
        /// </summary>
        [MaxLength(100)]
        public string DisplayName { get; set; }

        /// <summary>
        /// gets or sets date that this user registerd
        /// </summary>
        public DateTime RegisterDate { get; set; }


        public virtual ICollection<AuditLog> AuditLogs { get; set; } // AuditLogs.FK_Core.AuditLogs_Core.Users_OperantId
        public virtual ICollection<UserToken> UserTokens { get; set; } // UserTokens.FK_Core.UserTokens_Core.Users_OwnerUserId


        #endregion Properties
    }
}
