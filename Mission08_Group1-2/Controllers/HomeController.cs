using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission08_Group1_2.Models;

namespace Mission08_Group1_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //the connection to the context file
        private TaskAdditionsContext _TAContext { get; set; }
        public HomeController(ILogger<HomeController> logger, TaskAdditionsContext tacontext)
        {
            _logger = logger;
            _TAContext = tacontext;
        }

        //Home Page
        public IActionResult Index()
        {
            return View();
        }

        //Show the different Quadrants and passes the Quadrants.cshtml page a list of incomplete tasks
        public IActionResult Quadrants()
        {
            var tasks = _TAContext.Additions
                .Where(x => x.Completed == true)
                .ToList();

            return View(tasks);
        }

        //When the form gets initially rendered to add a new task, pass it the Categories ViewBag
        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = _TAContext.Categories.ToList();
            return View();
        }

        //When the Add Form is submitted
        [HttpPost]
        public IActionResult TaskForm(TaskAddition taskAdd)
        {
            //if no errors then add the new task and redirect to the quadrant view
            if (ModelState.IsValid)
            {
                _TAContext.Add(taskAdd);
                _TAContext.SaveChanges();

                return RedirectToAction("Quadrants");
            }
            else
            {
                //if there were errors then re-render the form
                ViewBag.Categories = _TAContext.Categories.ToList();
                return View();
                //could also do return View("TaskForm", taskAdd);?
            }
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = _TAContext.Categories.ToList();

            //query the tables for the listed taskId
            var task = _TAContext.Additions.Single(x => x.TaskId == taskid);
            return View("TaskForm", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskAddition taskAdd)
        {
            //make sure updated data is valid
            if (ModelState.IsValid)
            {
                _TAContext.Update(taskAdd);
                _TAContext.SaveChanges();

                return RedirectToAction("Quadrants");
            }
            else
            {
                //redirect to the GET request for the render page if there was an error,
                //this should only be called if values are changed through inspect Element
                return RedirectToAction("Edit", new { taskid = taskAdd.TaskId });
            }
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            //find the row to delete
            var task = _TAContext.Additions.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskAddition taskAdd)
        {
            //if delete was confirmed on Delete.cshtml then remove the task
            _TAContext.Additions.Remove(taskAdd);
            _TAContext.SaveChanges();
            return RedirectToAction("Quadrants");
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
}
