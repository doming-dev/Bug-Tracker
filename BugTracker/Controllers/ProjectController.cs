using System;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models;
using BugTracker.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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

            var projectsViewModel = new ProjectsViewModel();
            projectsViewModel.Projects = projects;
            projectsViewModel.Project = new Project();

            return View(projectsViewModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new Project());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            project.CreateDate = System.DateTime.Now;

            context.Add(project);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            string id = HttpContext.Request.Form["id"];

            var projectToDelete = context
                .Projects
                .FirstOrDefault(x => x.Id == Convert.ToInt32(id));

            if (projectToDelete != null)
                context.Remove(projectToDelete);

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}