using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1PackagesSender.Data;
using Task1PackagesSender.FluentValidation;
using Task1PackagesSender.Models;

namespace Task1PackagesSender.Interfaces
{
    
    public class MainComponent : IMainComponent
    {
        private EmployeesData _EmployeesData;
        public MainComponent(EmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;           
        }
                                   
        public string Run(string currentUser, FormData formData)
        {
            FormDataValidation validation = new FormDataValidation();

            var result = validation.Validate(formData);

            var CurrentEmployee = _EmployeesData.Employees.FirstOrDefault(a => a.Login == currentUser);

            int? manager = null;

            if (CurrentEmployee!=null)
            {
              manager = CurrentEmployee.ORG_ManagerID;
            }
            

            Employees GetManager;

            List<AcceptingPerson> CheckThatMangerCanAcceptTheAsk;

            AcceptingPerson SubstituteWithLowerOpportunity = null;

            string error="Unidentified error";

            if (result.IsValid &&   CurrentEmployee!= null && CurrentEmployee.ORG_ManagerID != null)
            {
                do
                {
                   
                     GetManager = _EmployeesData.Employees.FirstOrDefault(a => a.EmoplyeeID == manager);

                     CheckThatMangerCanAcceptTheAsk = _EmployeesData.AcceptingPeople.Where(a => a.Category == formData.Category && a.Login == GetManager.Login && a.Limit >= formData.TotalValue).ToList();

                     manager = GetManager.ORG_ManagerID;

                } while (CheckThatMangerCanAcceptTheAsk.Count == 0);

                if (CheckThatMangerCanAcceptTheAsk.Count > 0)
                {
                    var min = CheckThatMangerCanAcceptTheAsk.Where(x => x.SubstituteLimit > formData.TotalValue).Min(entry => entry.SubstituteLimit);

                    SubstituteWithLowerOpportunity = CheckThatMangerCanAcceptTheAsk.FirstOrDefault(x => x.SubstituteLimit == min);

                    formData.AcceptingPerson = CheckThatMangerCanAcceptTheAsk[0].Login;
                }

                if (CheckThatMangerCanAcceptTheAsk.Count > 0 && SubstituteWithLowerOpportunity != null && SubstituteWithLowerOpportunity.SubstituteLogin != null)
                {
                    formData.SubstituteAcceptingPerson = SubstituteWithLowerOpportunity.SubstituteLogin;
                  
                }

                return null;

            }
            else if (CurrentEmployee == null)
            {
                error = "There is no user like this";
            }
            else if (CurrentEmployee.ORG_ManagerID == null)
            {
                formData.AcceptingPerson = CurrentEmployee.Login;
                return null;
            }         
            else
            {
                
                if (formData.TotalValue <= 0)
                {
                    error = "You have to write value greather than 0";
                }
                else
                {
                    error = $"Your value is too big for ask";
                }

                return error;
            }

            return error;
                      
        }

        public Employees GetEmployee(string login)
        {
            return _EmployeesData.Employees.FirstOrDefault(a => a.Login == login);
        }

        public bool FindUser(string id)
        {
            return _EmployeesData.Employees.Any(o => o.Login == id);
        }
       
    }


    public interface IMainComponent
    {
        string Run(string currentUser, FormData formData);
        
        Employees GetEmployee(string id);
        bool FindUser(string id);
     
    }
}
