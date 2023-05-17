namespace DoctorWebForum.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int? ChildId { get; set; }
        public int Level { get; set; }
        public bool IsRoot { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
