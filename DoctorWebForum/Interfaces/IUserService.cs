using DoctorWebForum.Models;

namespace DoctorWebForum.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetUsers(string sTerm = "", int qualificationId = 0, int experienceId  = 0);
        Task<IEnumerable<Qualification>> Qualifications();
        Task<IEnumerable<Experience>> Experiences();
        ApplicationUser GetUserById(string Id);
    }
}
