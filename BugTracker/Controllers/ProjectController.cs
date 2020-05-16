using System.Linq;
using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProjectController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var projects = context
                .Projects
                .Include(proj => proj.WorkItems)
                .ToList();

            return View(projects);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new Project());
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            System.Console.WriteLine(project);

            return RedirectToAction("Index");
        }
    }
}