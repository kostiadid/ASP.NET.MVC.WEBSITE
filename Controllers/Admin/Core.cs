using Microsoft.AspNetCore.Mvc;
using MyAspNetApp.Domain;
using Microsoft.AspNetCore.Authorization;
using MyAspNetApp.Domain.Enums;
using System.Text.Json;

namespace MyAspNetApp.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    // [Authorize]
  public partial class AdminController: Controller
  {
    private readonly DataManager _dataManager;
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly ILogger<AdminController> _logger;
    public AdminController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, ILogger<AdminController> logger)
    {
      _dataManager = dataManager;
      _hostingEnvironment = hostingEnvironment;
      _logger = logger;
    }
 
    public async Task<IActionResult> Index()
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\n=====================");
      Console.WriteLine("AdminController.Index() called!");
      Console.WriteLine("=====================\n");
      Console.ResetColor();
      ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
      ViewBag.Services = await _dataManager.Services.GetServicesAsync();
      return View();
    }

    //Save img in file system
    public async Task<string> SaveImg(IFormFile img)
    {
      string path = Path.Combine(_hostingEnvironment.WebRootPath, "img/", img.FileName);
      await using FileStream stream = new FileStream(path,FileMode.Create);
      await img.CopyToAsync(stream);
      
      return path;
    }
    
    //Save img from editor
    public async Task<string> SaveEditorImg()
    {
      IFormFile img = Request.Form.Files[0];
      await SaveImg(img);
      return JsonSerializer.Serialize(new{location = Path.Combine("/img/",img.FileName)});
    }
  }
}


// https://www.youtube.com/watch?v=DIEGhDmBw6E
