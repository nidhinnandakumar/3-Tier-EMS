using Speridian.EMS.DAL;
using Speridian.EMS.Entities;
using System.Runtime.InteropServices;

namespace Speridian.EMS.BusinessLayer
{
    public class EmployeeBL
    {
        public static List<Employee> GetEmployee()
        {
            var list = EmployeeDAL.GetEmployee();
            return list;
        }
        public static bool Add(Employee employee)
        {
            var isAdded = EmployeeDAL.Add(employee);
            return isAdded;
        }

    
public static Employee GetById(int d)

        {

            var emp = EmployeeDAL.GetById(d);

            return emp;

        }

        public static bool Update(Employee employee)

        {

            var isUpdated = EmployeeDAL.Update(employee);

            return isUpdated;

        }

        public static bool Delete(Employee employee)

        {

            var isDeleted = EmployeeDAL.Delete(employee);

            return isDeleted;

        }

    }
}