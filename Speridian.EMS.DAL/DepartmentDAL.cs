using Speridian.EMS.Entities;
using Speridian.EMS.Exceptions;

namespace Speridian.EMS.DAL
{
    public class DepartmentDAL
    {
        static List<Department> list = new List<Department>
        {
            new Department{Id=1,Name="HR"},
            new Department{Id=2,Name="Legal"}

        };
        static int counter = 2;
        public static List<Department> GetDepartments()
        {
            return list;
        }
        public static bool Add(Department department)
        {
            bool isExists = list.Exists(d=>d.Name == department.Name);
            if (isExists)
            {
                throw new EMSException("Department already Exists");
            }
            department.Id = ++counter;
            list.Add(department); 
            return true;
        }

        public static Department GetById(int id)
        {
            var dept=list.Find(d=>d.Id == id);
            return dept;
        }

       /* public static bool Update(Department department)
        {

            list.Append(department);
            return true;
        } */

        public static bool Update(Department department) 
        {
            bool isExists = list.Exists(d => d.Name == department.Name);
            if (isExists)
            {
                throw new EMSException("Department already Exists");
            }
            var existingDept=list.Find(d=>d.Id==department.Id);
            existingDept = existingDept;
            return true;
        }

        public static bool Delete(Department department)
        {
            list.Remove(department);
            return true;
        }

    }
}