using Speridian.EMS.Entities;
using Speridian.EMS.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Speridian.EMS.DAL
{
    public class EmployeeDAL
    {
        static List<Employee> list = new List<Employee>
        {
            new Employee {Id=1,Name="Ketaki",
                DateOfBirth=new DateTime(2000,1,1),
                Email="ketaki@speridian.com",
                Gender=Gender.Female,
                MobileNo=9987564513,
                DepartmentId=1
            },
            new Employee
            {
                Id=2, Name="Akash",
                DateOfBirth=new DateTime(2000,1,1),
                Email="akash@speridian.com",
                Gender=Gender.Male,
                MobileNo=9987347813,
                DepartmentId=2

            }
        };
        static int counter = 2;

        public static List<Employee> GetEmployee()
        {
            return list;
        }
        public static bool Add(Employee employee)
        {
            bool isExists = list.Exists(e => e.Name == employee.Name 
            && e.DateOfBirth.Date == employee.DateOfBirth.Date
            && e.Gender == employee.Gender); 
            if (isExists)
            {
                throw new EMSException("Employee already Exists");
            }
            employee.Id = ++counter;
            list.Add(employee);
            return true;
        }
     
        public static Employee GetById(int id)

        {

            var employee = list.Find(d => d.Id == id);

            return employee;

        }

        public static bool Update(Employee employee)

        {

            list.Append(employee);

            return true;

        }

        public static bool Delete(Employee employee)

        {

            list.Remove(employee);

            return true;

        }
    }
}
