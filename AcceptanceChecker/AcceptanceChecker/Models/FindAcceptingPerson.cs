using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1PackagesSender.Data;

namespace Task1PackagesSender.Models
{
    public class FindAcceptingPerson 
    {

        protected readonly ApplicationDbContext _context;
        public FindAcceptingPerson(ApplicationDbContext context)
        {

            _context = context;

        }
        public string Run(string currentUserLogin, FormData formData)
        {
            // check if currentUser has some acceptant permissions
            var UserPermissions = _context.AcceptingPeople.Where(a => a.Login == currentUserLogin).Select(a => new { a.Limit, a.Category });
            if (currentUserLogin == "zupa")
            return "zz";

            return null;
        }
        public bool findWorker(AcceptingPerson person)
        {
            var Result = _context.AcceptingPeople.Any(o => o.Login == person.Login);
            return Result;
        }

        
            
       

    }
}
