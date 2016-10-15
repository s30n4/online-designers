using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OD.DomainClasses.Entities.Common;
using SGE.Framework.Domain.Entities;

namespace OD.DomainClasses.Entities.Profile
{
    [Table("Profiles", Schema = "Profile")]
    public class Profile : Entity
    {
        [MaxLength(200)]
        public string DisplayName { get; set; }

        [MaxLength(500)]
        public string JobHeadline { get; set; }

        [MaxLength(500)]
        public string Avatar { get; set; }

        public string Summary { get; set; }

        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? IndustryId { get; set; }
        public int? EducationDegreeId { get; set; }
        public int? EducationPlaceId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        //رشته کاری
        [ForeignKey("IndustryId")]
        public virtual Industry Industry { get; set; }

        //مدرک تحصیلی
        [ForeignKey("EducationDegreeId")]
        public virtual EducationDegree EducationDegree { get; set; }

        //محل تحصیل
        [ForeignKey("EducationPlaceId")]
        public virtual EducationPlace EducationPlace { get; set; }

        //تفریحات
        public ICollection<ProfileHobby> Hobbies { get; set; }
        //تجربیات کاری
        public ICollection<Experience> Experiences { get; set; }
        //علاقه مندی ها
        public ICollection<ProfileFavorite> Favorites { get; set; }
        //توانایی ها
        public ICollection<ProfileSkill> Skills { get; set; }

        //پروژه ها
        public ICollection<ProfileProject> Projects { get; set; }


    }
}
