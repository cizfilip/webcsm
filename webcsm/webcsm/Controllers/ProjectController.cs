using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webcsm.Models;
using webcsm.ViewModels;
using System.Web.Security;

namespace webcsm.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private webcsmEntities db = new webcsmEntities();
        //
        // GET: /Project/

        public ActionResult Index()
        {
            List<GroupWithProjects> groups = new List<GroupWithProjects>();

            List<Group> usersGroups = (from g in db.Groups where g.UserName == User.Identity.Name select g).ToList<Group>();

            foreach (var item in usersGroups)
	        {
		        groups.Add(new GroupWithProjects { Group = item, Projects = item.Projects.ToList<Project>() });

        	}

            var returnModel = new ProjectViewModel
            {
                Groups = groups
                
                //Projects = (from p in db.Projects where p.LeaderName == User.Identity.Name select p).ToList<Project>()
            };
            return View(returnModel);
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
            ViewData["Groups"] = (from g in db.Groups where g.UserName == User.Identity.Name select g).ToList<Group>();
            MembershipUserCollection users = Membership.GetAllUsers();
            users.Remove(User.Identity.Name);
            ViewData["AvailableUsers"] = new SelectList(users,"UserName", "Email");
            ViewData["SelectedUsers"] = new SelectList(new List<MembershipUser>(), "UserName", "Email");
 

            return View();
        } 

        //
        // POST: /Project/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id,LeaderName")] Project projectToCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                string groupId = Request["GroupID"];
                var groupids = groupId.Split(',');
                foreach (var item in groupids)
                {
                    int id = int.Parse(item);
                    Group group = db.Groups.Where(g => g.Id == id).First();
                    projectToCreate.Groups.Add(group);                    
                }


                projectToCreate.LeaderName = User.Identity.Name;
                
                db.AddToProjects(projectToCreate);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        public ActionResult CreateGroup([Bind(Exclude = "Id,UserName")] Group groupToCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                groupToCreate.UserName = User.Identity.Name;
                db.AddToGroups(groupToCreate);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

        //
        // GET: /Project/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
