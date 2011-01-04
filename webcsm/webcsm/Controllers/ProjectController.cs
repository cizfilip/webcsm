using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webcsm.Models;
using System.Web.Security;
using webcsm.Helpers;

namespace webcsm.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        IWebcsmRepository webcsmRepository;

        //
        // Dependency Injection enabled constructors

        public ProjectController() : this(new EntityWebcsmRepository()) { }

        public ProjectController(IWebcsmRepository repository)
        {
            webcsmRepository = repository;
        }
        
        //
        // GET: /Project/

        public ActionResult Index()
        {
            IQueryable<Group> usersGroups = webcsmRepository.GetUserGroups(User.Identity.Name);
            
            return View(usersGroups);
        }


        public JsonResult FindUsers(string searchText, int maxResults = 10)
        {
            var result = webcsmRepository.GetAllUsersEmail(User.Identity.Name);


            return Json(result.Take(maxResults).ToList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Project/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            ProjectFormViewModel projectForm = new ProjectFormViewModel()
            {
                UserGroups = new SelectList(webcsmRepository.GetUserGroups(User.Identity.Name), "Id", "Name")
            };


            return View(projectForm);
        } 

        //
        // POST: /Project/Create
        [HttpPost]
        public ActionResult Create([Bind(Prefix = "Project")]Project projectToCreate, string usersList)
        {
            
            if (ModelState.IsValid)
            {
                webcsmRepository.AddLeaderToProject(projectToCreate, User.Identity.Name);
                webcsmRepository.AddUsersToProject(projectToCreate, CommaSerializator.Deserialize(usersList));
                webcsmRepository.CreateProject(projectToCreate);
                webcsmRepository.Save();

                return RedirectToAction("Index");
            }

            ProjectFormViewModel projectForm = new ProjectFormViewModel()
            {
                UserGroups = new SelectList(webcsmRepository.GetUserGroups(User.Identity.Name), "Id", "Name"),
                Project = projectToCreate
            };


            return View(projectForm);
        }

        //
        // GET: /Project/CreateGroup

        public ActionResult CreateGroup()
        {
            return View();
        }

        //
        // POST: /Project/CreateGroup

        [HttpPost]
        public ActionResult CreateGroup(Group groupToCreate)
        {
            if (ModelState.IsValid)
            {
                webcsmRepository.AddUserToGroup(groupToCreate, User.Identity.Name);
                webcsmRepository.CreateGroup(groupToCreate);
                webcsmRepository.Save();

                return RedirectToAction("Index");
            }


            return View(groupToCreate);
        }
        
        //
        // GET: /Project/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // TODO: Delete projects and groups
        ////
        //// GET: /Project/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Project/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
