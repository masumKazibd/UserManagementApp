using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Models;
using UserManagementApp.ViewModels;

namespace UserManagementApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<Users> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<Users> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }
    [Authorize]
    public async Task<IActionResult> Index()
    {
        // Fetch all users from UserManager
        var users = _userManager.Users.ToList();

        // Create a list of DashboardViewModel containing user data
        var model = users.Select(user => new DashboardViewModel
        {
            Name = user.UserName,
            Designation = user.Designation,
            Email = user.Email,
            LastLoginTIme = user.LoginTime  // Assuming LoginTime is stored in the Users model
        }).ToList();

        // Pass the model (List<DashboardViewModel>) to the view
        return View(model);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
