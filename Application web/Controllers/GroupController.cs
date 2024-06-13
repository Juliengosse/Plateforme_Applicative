using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Application_web.Models;
using Application_web.Service;

namespace Application_web.Controllers
{
    public class GroupController : Controller
    {

        private readonly ApiService _apiService;

        public GroupController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> GroupList()
        {
            // Vérifiez si l'utilisateur est connecté
            var role = HttpContext.Session.GetString("Role");
            if (string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "Login");
            }

            // Vérifiez si l'utilisateur a le rôle approprié
            if (role != "admin")
            {
                return Unauthorized();
            }

            // Obtenir le token
            var token = await _apiService.GetTokenAsync();
            _apiService.SetAuthorizationHeader(token);

            // Appeler l'API pour obtenir la liste des groupes
            var groups = await _apiService.GetGroupsAsync();

            // Ajouter la liste des groupes à ViewData
            ViewData["Groups"] = groups;

            // Renvoie la vue correspondante
            return View();
        }

        public async Task<IActionResult> GroupPage(int id)
        {
            // Vérifiez si l'utilisateur est connecté
            var role = HttpContext.Session.GetString("Role");
            if (string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "Login");
            }

            // Vérifiez si l'utilisateur a le rôle approprié
            if (role != "admin")
            {
                return Unauthorized();
            }

            // Obtenir le token
            var token = await _apiService.GetTokenAsync();
            _apiService.SetAuthorizationHeader(token);

            // Appeler l'API pour obtenir les détails du groupe et la liste des étudiants
            var group = await _apiService.GetGroupByIdAsync(id);
            var students = await _apiService.GetAllStudentsAsync();

            // Filtrer les étudiants appartenant au groupe spécifié
            var studentList = new List<Student>();
            foreach (var student in students)
            {
                if (student.GroupId == id)
                    studentList.Add(student);
            }

            // Ajouter le groupe et la liste d'étudiants à ViewData
            ViewData["Group"] = group;
            ViewData["Students"] = studentList;

            // Renvoie la vue correspondante
            return View();
        }
    }
}
