using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1PackagesSender.Data;
using Task1PackagesSender.FluentValidation;
using Task1PackagesSender.Models;

namespace Task1PackagesSender.Interfaces
{
    public class DataConverterService : IDataConverterService
    {
        private readonly ApplicationDbContext _dbContext;
        public DataConverterService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public EmployeesData BuildData()
        {
            EmployeesData EmployeesData = new EmployeesData();
            var Employees = _dbContext.Employees.Where(x => x != null).ToList();
            var AcceptantPeople = _dbContext.AcceptingPeople.Where(x => x != null).ToList();
            EmployeesData.Employees = Employees;
            EmployeesData.AcceptingPeople = AcceptantPeople;

            return EmployeesData;
        }

    }

    public interface IDataConverterService
    {
              
       EmployeesData BuildData();

    }

   

   


}
