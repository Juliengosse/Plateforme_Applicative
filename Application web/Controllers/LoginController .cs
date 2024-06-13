using Application_web.Models;
using Application_web.Service;
using Microsoft.AspNetCore.Mvc;


public class LoginController : Controller
{
    private readonly ApiService _apiService;
    public LoginController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Authenticate(string username, string password)
    {
        if (ModelState.IsValid)
        {
            var token = await _apiService.GetTokenAsync();
            if (token != null)
            {
                _apiService.SetAuthorizationHeader(token);
                var user = await _apiService.ValidateUserAsync(username, password);

                if (user != null)
                {
                    HttpContext.Session.SetString("Token", token);
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Role", user.Role);

                    if (user.Role == "admin")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Vous n'avez pas les droits administratifs.");
                        return View("Index", "Login");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Nom d'utilisateur ou mot de passe incorrect.");
                    return View("Index", "Login");
                }
            }
            ModelState.AddModelError(string.Empty, "Vous n'avez pas acces à l'application.");
        }
        return View("Index", "Login");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Login");
    }

}