using DoctorWebForum.Models;

namespace DoctorWebForum.DTOs
{
    public class UserDisplayModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();/*để tránh lỗi Referent*/
        public IEnumerable<Qualification> Qualifications{ get; set; } = new List<Qualification>(); /*để tránh lỗi Referent*/
        public IEnumerable<Experience> Experiences { get; set; } = new List<Experience>();/*để tránh lỗi Referent*/
        public string STerm { get; set; } = "";
        public int QualificationId { get; set; } = 0;
        public int ExperienceId { get; set; } = 0;
    }
}
