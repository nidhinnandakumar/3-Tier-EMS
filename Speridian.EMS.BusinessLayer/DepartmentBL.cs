using Speridian.EMS.DAL;
using Speridian.EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speridian.EMS.BusinessLayer
{
    public class DepartmentBL
    {
        public static List<Department> GetDepartments()
        {
            var list = DepartmentDAL.GetDepartments();
            return list;
        }
        public static bool Add(Department department)
        {
            var isAdded=DepartmentDAL.Add(department);
            return isAdded;
        }

        public static Department GetById(int id)
        {
            var dept=DepartmentDAL.GetById(id);
            return dept;
        }

        public static bool Update(Department dept)
        {
            var isAdded = DepartmentDAL.Update(dept);
            return isAdded;
        }

        public static bool Delete(Department department)
        {
            var isDeleted = DepartmentDAL.Delete(department);
            return isDeleted;
        }
    }
}
