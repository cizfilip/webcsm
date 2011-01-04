using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace webcsm.Models
{
    public class EntityWebcsmRepository : IWebcsmRepository
    {
        private webcsmEntities db = new webcsmEntities();

        public Project CreateProject(Project projectToCreate)
        {
            db.AddToProjects(projectToCreate);
            return projectToCreate;
        }

        public Group CreateGroup(Group groupToCreate)
        {
            db.AddToGroups(groupToCreate);
            return groupToCreate;
        }

        public IQueryable<Group> GetUserGroups(string userName)
        {
            return db.Groups.Where(g => g.User.UserName.Equals(userName));
        }


        public void Save()
        {
            db.SaveChanges();
        }


        public IQueryable<string> GetAllUsersEmail(string withoutName = null)
        {
            if (string.IsNullOrEmpty(withoutName))
            {
              return (from u in Membership.GetAllUsers().Cast<MembershipUser>() select u.Email).AsQueryable<string>();
            }
            else
            {
                
                return (from u in Membership.GetAllUsers().Cast<MembershipUser>() where !u.UserName.Equals(withoutName) select u.Email).AsQueryable<string>();
            }
            
        }




        #region IWebcsmRepository Members


        public Project AddUsersToProject(Project project, IEnumerable<string> usersEmails)
        {
            var users = db.Users.Where(u => usersEmails.Contains(u.Email)).Distinct();
            project.Users.Clear();
            foreach (var item in users)
            {
                project.Users.Add(item);
            }
            return project;
        }

        public Project AddLeaderToProject(Project project, string leaderName)
        {
            project.LeaderId = (int)Membership.GetUser(leaderName).ProviderUserKey;
            return project;
        }

        public Group AddUserToGroup(Group group, string userName)
        {
            group.UserId = (int)Membership.GetUser(userName).ProviderUserKey;
            return group;
        }

        #endregion
    }
}