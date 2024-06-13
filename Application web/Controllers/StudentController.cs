using Microsoft.AspNetCore.Mvc;
using Application_web.Models;
using Newtonsoft.Json;
using Application_web.Service;

namespace Application_web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApiService _apiService;

        public StudentController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> StudentPage(int id, string selectedMonth, string selectedYear)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "admin")
            {
                return Unauthorized();
            }

            var token = await _apiService.GetTokenAsync();
            _apiService.SetAuthorizationHeader(token);

            var student = await _apiService.GetStudentByIdAsync(id);
            var presences = await _apiService.GetAllStudentPresenceAsync();
            var group = await _apiService.GetGroupByIdAsync(student.GroupId);

            var studentPresence = new List<StudentPresence>();
            foreach (var presence in presences)
            {
                if (presence.StudentId == id)
                    studentPresence.Add(presence);
            }

            ViewData["Student"] = student;
            ViewData["Presences"] = studentPresence;
            ViewData["Group"] = group;
            ViewData["selectedYear"] = selectedYear ?? DateTime.Now.Year.ToString();
            ViewData["selectedMonth"] = selectedMonth ?? DateTime.Now.Month.ToString();

            return View();
        }

        public async Task<IActionResult> StudentList()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "admin")
            {
                return Unauthorized();
            }

            var token = await _apiService.GetTokenAsync();
            _apiService.SetAuthorizationHeader(token);

            var students = await _apiService.GetAllStudentsAsync();
            var groups = await _apiService.GetAllGroupsAsync();

            ViewData["Students"] = students;
            ViewData["Groups"] = groups;

            return View();
        }
    }
}
