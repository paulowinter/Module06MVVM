using Module06MVVM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Module06MVVM.ViewModel
{

    public class EmployeeViewModel
    {

        /*public EmployeeModel EmployeeModelSet { get; set; }

        public EmployeeViewModel()
        {
            EmployeeModelSet = new EmployeeModel
            {
                Id = 1,
                Name = "Juan Dela Cruz",
                Email = "juandelacruz@auf.edu.ph",
                Address = "Angeles City",
            };
        }*/

        private Services.DatabaseContext GetContext()
        {
            return new Services.DatabaseContext();
        }

        public int InsertEmployee(EmployeeModel obj) 
        { 
            var _dbContext = GetContext();
            _dbContext.Employees.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;


        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var _dbContext = GetContext ();
            var res = await _dbContext.Employees.ToListAsync();
            return res;
        }

        public async Task<int> UpdateEmployee(EmployeeModel obj)
        {
            var _dbContext = GetContext();
            _dbContext.Employees.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int DeleteEmployee(EmployeeModel obj)
        {
            var _dbContext = GetContext();
            _dbContext.Employees.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

    }
}
