using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webcsm.Models
{
    public interface IWebcsmRepository
    {
        Project CreateProject(Project projectToCreate);
        Group CreateGroup(Group groupToCreate);
        
        IQueryable<Group> GetUserGroups(string userName);

        void Save();

        
        Project AddUsersToProject(Project project, IEnumerable<string> usersEmails);
        Project AddLeaderToProject(Project project, string leaderName);
        Group AddUserToGroup(Group group, string userName);

        IQueryable<string> GetAllUsersEmail(string withoutName = null);

    }
}