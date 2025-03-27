using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementApp.Migrations;
using UserManagementApp.Models;
using UserManagementApp.ViewModels;

namespace UserManagementApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<Users> _userManager;
    private readonly SignInManager<Users> _signInManager;

    public HomeController(ILogger<HomeController> logger, UserManager<Users> userManager, SignInManager<Users> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();

        var model = users.Select(user => new DashboardViewModel
        {
            Name = user.FullName,
            Designation = user.Designation,
            Email = user.Email,
            LastLoginTIme = user.LoginTime,
            LockoutEnd = user.LockoutEnd,
            IsBlocked = user.IsBlocked
        })
            .OrderByDescending(vm => vm.LastLoginTIme)
            .ToList();
        //sort by lastlogin desending
        return View(model);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> BlockUsers(List<string> userIds)
    {
        if(userIds == null || !userIds.Any())
        {
            return BadRequest("No users selected.");
        }
 
        var usersToBlock = await _userManager.Users
            .Where(user => userIds.Contains(user.Email))
            .ToListAsync();
        _logger.LogInformation("Users found to block: " + usersToBlock.Count);
        var currentUserEmail = User.FindFirstValue(ClaimTypes.Email);

        foreach (var user in usersToBlock)
        {
            user.LockoutEnd = DateTimeOffset.UtcNow.AddYears(100);
            user.IsBlocked = true;
            user.LockoutEnabled = true;
            await _userManager.UpdateAsync(user);
            if (user.Email.Equals(currentUserEmail, StringComparison.OrdinalIgnoreCase))
            {
                await _signInManager.SignOutAsync();
            }
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UnBlockUsers(List<string> userIds)
    {
        if (userIds == null || !userIds.Any())
        {
            return BadRequest("No users selected.");
        }
        _logger.LogInformation("User IDs to block: " + string.Join(", ", userIds));

        var usersToUnBlock = await _userManager.Users
            .Where(user => userIds.Contains(user.Email))
            .ToListAsync();
        _logger.LogInformation("Users found to block: " + usersToUnBlock.Count);

        foreach (var user in usersToUnBlock)
        {
            user.LockoutEnd = null;
            user.IsBlocked = false;
            user.LockoutEnabled = true;
            await _userManager.UpdateAsync(user);
        }
        TempData["SuccessMessage"] = $"{usersToUnBlock.Count} user(s) unblocked successfully.";
        return RedirectToAction(nameof(Index));
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
