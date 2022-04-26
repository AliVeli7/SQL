using framework.DataAccess;
using framework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace framework.Controller
{
    public class EmployeeController
    {
        private readonly AppDbContext _db;
        public EmployeeController()
        {
            _db = new AppDbContext();
        }

        public List<Employee> GetAll()
        {
            return _db.Employees.ToList();
        }
        public void GetEmployeeById(int id)
        {
            Employee employee = _db.Employees.Find(id);

            if (employee == null)
            {
                Console.WriteLine("Not found");
                return;
            }
            Console.WriteLine(employee);

        }

        public void GetAllEmployees()
        {
            List<Employee> employees = _db.Employees.ToList();
            foreach (var item in employees)
            {
                Console.WriteLine(item.FullName);
            }
        }

        public void AddEmployee(string fullname)
        {
            try
            {
                Employee emp = new Employee { FullName = fullname };
                _db.Employees.Add(emp);
                _db.SaveChanges();
                Console.WriteLine("Employee is created.");
            }
            catch (Exception)
            {
                Console.WriteLine("Some problems exists");
            }
        }

        public void DeleteEmployee(int id)
        {
            Employee emp = _db.Employees.Find(id);
            if (emp == null)
            {
                Console.WriteLine("Not Found");
            }
            _db.Employees.Remove(emp);
            Console.WriteLine("Employee is deleted.");
        }

        public void FilterByName(string str)
        {
            List<Employee> emplist = _db.Employees.ToList();
            foreach (var item in emplist)
            {
                if (item.FullName.Contains(str))
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }
    }
}
