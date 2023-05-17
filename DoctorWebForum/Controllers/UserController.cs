using DoctorWebForum.DTOs;
using DoctorWebForum.Interfaces;
using DoctorWebForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWebForum.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> Member(string sTerm = "", int qualificationId = 0, int experienceId = 0)
        {
            IEnumerable<ApplicationUser> users = await _userService.GetUsers(sTerm, qualificationId, experienceId);
            IEnumerable<Qualification> qualifications = await _userService.Qualifications();
            IEnumerable<Experience> experiences = await _userService.Experiences();
            UserDisplayModel userModel = new UserDisplayModel
            {
                Users = users,
                Qualifications = qualifications,
                STerm = sTerm,
                QualificationId = qualificationId,
                Experiences = experiences, // ngưng đổ lỗi
                ExperienceId = experienceId
                
            };
            return View(userModel);
        }

        public IActionResult Details(string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}
