using Microsoft.AspNetCore.Mvc;
using TaskMangement.Constants;
using TaskMangement.Data;
using TaskMangement.Models;
using TaskMangement.ViewModels;

namespace TaskMangement.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TasksController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            var Tasks = _context.doLists.ToList();
            return View(Tasks);
        }
        public async Task<IActionResult> Add()
        {
            var model = new TaskViewModel();
            return View(model);



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TaskViewModel model)
        {
            
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
            var result = new DoList
            {
                Title=model.Title,
                Description=model.Description,
                dueDate=model.dueDate,
                status=$"{StatusConsts.notStarted}"

            };
            _context.Add(result);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> edit(int id)
        {
            var Task = _context.doLists.Find(id);
            var result = new TaskViewModel
            {
                ID = Task.ID,
                Title = Task.Title,
                Description = Task.Description,
                status = Task.status,
                dueDate = Task.dueDate
            };
            if (Task == null)
                return NotFound();
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
