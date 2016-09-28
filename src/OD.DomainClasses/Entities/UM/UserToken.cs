using System;
using System.ComponentModel.DataAnnotations.Schema;
using SGE.Framework.Authorization;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.UM
{
    [Table("UserTokens", Schema = "UM")]
    public class UserToken : Entity, IUserToken
    {
        public int OwnerUserId { get; set; }

        public ApplicationUser OwnerUser { get; set; }

        public string AccessTokenHash { get; set; }

        public DateTime AccessTokenExpirationDateTime { get; set; }

        public string RefreshTokenIdHash { get; set; }

        public string Subject { get; set; }

        public DateTime RefreshTokenExpiresUtc { get; set; }

        public string RefreshToken { get; set; }
    }
}
