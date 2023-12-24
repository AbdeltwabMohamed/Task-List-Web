using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMangement.Constants;
using TaskMangement.Data;
using TaskMangement.Models;
using TaskMangement.ViewModels;

namespace TaskMangement.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<SystemUser> _userManager;
        
        public TasksController(ApplicationDbContext context, UserManager<SystemUser> userManager)
        {

            _context = context;
            _userManager= userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser =await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
            var Tasks = _context.doLists.Include(r=>r.systemUser).Where(d=>d.systemUser.Id==currentUser.Id).ToList();

            return View(Tasks);
            }
            return View(new List<DoList>());
            
        }
        public async Task<IActionResult> Add()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var model = new TaskViewModel() { UserId = user.Id };
                return View(model);
            }
            else
            {
                return View(new TaskViewModel());
            }



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TaskViewModel model)
        {
            var user =await _userManager.GetUserAsync(User);
            
            if (!ModelState.IsValid)
                return View(model);

            
            if(model.dueDate <= DateTime.Now)
            {
                ModelState.Clear();
                ModelState.AddModelError("dueDate", "Invalid Task Time Make it bigger from now");
                return View(model);
            }
            if(model.Title==string.Empty)
            {
                ModelState.Clear();
                ModelState.AddModelError("Title", "Title Required");
                return View(model);
            }
            
           
            if (model.UserId ==null)
            {
                ModelState.AddModelError("UserId", "You have to sign in to add tasks");
                return View(model);
            }
            var result = new DoList
            {
                Title = model.Title,
                Description = model.Description,
                dueDate = model.dueDate,
                status = $"{StatusConsts.notStarted}",
                systemUser = user,
                

            };
            _context.Add(result);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> edit(int id)
        {
            var Task = _context.doLists.Find(id);
            if (Task == null)
                return NotFound();
            var result = new TaskViewModel
            {
                ID = Task.ID,
                Title = Task.Title,
                Description = Task.Description,
                status = Task.status,
                dueDate = Task.dueDate
            };
            return View("Add", result);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> edit(TaskViewModel model)
        {
            var task = _context.doLists.Find(model.ID);

            if (!ModelState.IsValid)
                return View("add",model);


            if (model.dueDate <= DateTime.Now)
            {
                ModelState.Clear();
                ModelState.AddModelError("dueDate", "Invalid Task Time Make it bigger from now");
                return View("add", model);
            }
            if (model.Title == string.Empty)
            {
                ModelState.Clear();
                ModelState.AddModelError("Title", "Title Required");
                return View("add", model);
            }
            task.Title = model.Title;
            task.Description=model.Description;
            task.status = model.status;
            task.dueDate = model.dueDate;
            

            _context.Update(task);
           
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> details(int id)
        {
            var task =await _context.doLists.FindAsync(id);
            if (task == null)
                return NotFound();

            return View(task);

        }
        public async Task<IActionResult> Delete(int id)
        {
            var task = _context.doLists.Find(id);
            if (task == null) return NotFound();

            _context.Remove(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

  
    }

}
