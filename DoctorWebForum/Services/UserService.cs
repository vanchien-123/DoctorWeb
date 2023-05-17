using DoctorWebForum.Data;
using DoctorWebForum.Interfaces;
using DoctorWebForum.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DoctorWebForum.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context; ;
        }

        public async Task<IEnumerable<Experience>> Experiences()
        {
            return await _context.Experience.ToListAsync();
        }
       
        public async Task<IEnumerable<Qualification>> Qualifications()
        {
            return await _context.Qualification.ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers(string sTerm = "", int qualificationId = 0, int experienceId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<ApplicationUser> user = await (from ApplicationUser in _context.ApplicationUser
                                             join qualification in _context.Qualification /*join experiennce in _context.Experiennce*/
                                             on ApplicationUser.QualificationId equals qualification.Id
                                             join experiennce in _context.Experience
                                             on ApplicationUser.ExperienceId equals experiennce.Id
                                             where string.IsNullOrWhiteSpace(sTerm) || (ApplicationUser != null && ApplicationUser.Name.ToLower().StartsWith(sTerm))
                                             select new ApplicationUser
                                             {
                                                 Id = ApplicationUser.Id,
                                                 ProfilePicture = ApplicationUser.ProfilePicture,
                                                 Name = ApplicationUser.Name,
                                                 PhoneNumber = ApplicationUser.PhoneNumber,
                                                 Location = ApplicationUser.Location,
                                                 QualificationId = ApplicationUser.QualificationId,
                                                 ExperienceId= ApplicationUser.ExperienceId
                                                 //GenreName = qualification.Name
                                             }
                         ).ToListAsync();
            if (qualificationId > 0)
            {

                user = user.Where(a => a.QualificationId == qualificationId).ToList();

            }

            if (experienceId > 0)
            {

                user = user.Where(a => a.ExperienceId == experienceId).ToList();

            }
            return user;
        }

        public ApplicationUser GetUserById(string Id)
        {
            return _context.ApplicationUser.FirstOrDefault(x => x.Id == Id);
        }
    }
}
