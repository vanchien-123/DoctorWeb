using Microsoft.AspNetCore.Identity;

namespace DoctorWebForum.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int? QualificationId { get; set; }
        public Qualification Qualification { get; set; }
        public int? ExperienceId { get; set; }
        public Experience Experience { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
