using Speridian.EMS.BusinessLayer;
using Speridian.EMS.Entities;
using Speridian.EMS.Exceptions;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Speridian.EMS.PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("^^^^^^^=====***=====-=====***=====^^^^^^^");
                    Console.WriteLine("1 #### LIST DEPARTMENTS ####");
                    Console.WriteLine("2  LIST EMPLOYEES ");
                    Console.WriteLine("3  ADD DEPARTMENTS ");
                    Console.WriteLine("4  UPDATE DEPARTMENT ");
                    Console.WriteLine("5  ADD EMPLOYEE ");
                    Console.WriteLine("6  UPDATE EMPLOYEE ");
                    Console.WriteLine("7  DELETE EMPLOYEE ");
                    Console.WriteLine("8  DELETE DEPARTMENT ");
                    Console.WriteLine("9 #### EXIT ####");
                    Console.WriteLine("#### Enter your choice ####");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int choice))
                    {
                        Console.WriteLine("INVALID INPUT");
                        return;
                    }
                    switch (choice)
                    {
                        case 1:
                            ListDepartments();
                            break;
                        case 2:
                            ListEmployee();
                            break;
                        case 3:
                            AddDepartments();
                            break;
                        case 4:
                            UpdateDepartment();
                            break;
                        case 5:
                            AddEmployee();
                            break;
                        case 6:
                            UpdateEmployee();
                            break;
                        case 7:
                            DeleteEmployee();
                            break;
                        case 8:
                            DeleteDepartment();
                            break;
                        case 9:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;

                    }

                }
                catch (EMSException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
        static void ListEmployee()
        {
            var list = EmployeeBL.GetEmployee();
            foreach (var dept in list)
            {
                Console.WriteLine(dept);
            }

        }
        private static void UpdateEmployee()
        {
            ListEmployee();
            Console.WriteLine("enter employee id to update");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int empId))
            {
                Console.WriteLine("invalid input");
            }
            var emp = EmployeeBL.GetById(empId);
            if (emp == null)
            {
                Console.WriteLine("Employee not exist");
                return;

            }
            Console.WriteLine("Enter the new Value");
            input = Console.ReadLine();


            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("invalid");
                return;
            }
            emp.Name = input;

            Console.WriteLine("Enter Employee Email:");
            input = Console.ReadLine();
            static bool IsValidEmail(string email)
            {
                // Regular expression for a simple email validation
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                // Create a Regex object
                Regex regex = new Regex(pattern);

                // Use the IsMatch method to check if the email matches the pattern
                return regex.IsMatch(email);
            }
            emp.Email = input;
            Console.WriteLine("Enter Employee Date of Birth (YYYY-MM-DD):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                if (dob > DateTime.Now)
                {
                    Console.WriteLine("Date of Birth should be in the past. Employee not added.");
                    return;
                }
                emp.DateOfBirth = dob;
            }
            else
            {
                Console.WriteLine("Invalid Date Format. Employee not added.");
                return;
            }
            Console.WriteLine("select employee Gender");
            foreach (var g in Enum.GetNames(typeof(Gender)))
            {
                Console.WriteLine(g);

            }
            if (Enum.TryParse(Console.ReadLine(), out Gender gender))
            {
                emp.Gender = gender;
            }
            else
            {
                Console.WriteLine("Invalid Gender. Employee not added.");
                return;
            }
            Console.WriteLine("Enter Employee Mobile Number:");
            if (long.TryParse(Console.ReadLine(), out long mobileNo))
            {
                string mobileString = mobileNo.ToString();
                if (mobileString.Length != 10)
                {
                    Console.WriteLine("Invalid Mobile Number. It should be 10 digits. Employee not added.");
                    return;
                }
                emp.MobileNo = mobileNo;
            }
            else
            {
                Console.WriteLine("Invalid Mobile Number. Employee not added.");
                return;
            }
            Console.WriteLine("Enter Department ID:");
            if (int.TryParse(Console.ReadLine(), out int departmentId))
            {
                emp.DepartmentId = departmentId;
            }
            else
            {
                Console.WriteLine("Invalid Department ID. Employee not added.");
                return;
            }

            bool isUpdated = EmployeeBL.Update(emp);
            if (isUpdated)
            {
                Console.WriteLine("Employe added successfully");

            }
            else
            {
                Console.WriteLine("Add Employee failed");
            }


        }
        static void DeleteDepartment()
        {
            ListDepartments();
            Console.WriteLine("enter department id to update");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int deptId))
            {
                Console.WriteLine("invalid input");
            }
            var dept = DepartmentBL.GetById(deptId);
            if (dept == null)
            {
                Console.WriteLine("Department does not exist");
                return;

            }
            Console.WriteLine("Enter Department Name:");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input) || !IsValidDepartmentName(input))
            {
                Console.WriteLine("Invalid department name");
                return;
            }
            dept.Name = input;
            bool isDeleted = DepartmentBL.Delete(dept);
            if (isDeleted)
            {
                Console.WriteLine("Department deleted successfully");

            }
            else
            {
                Console.WriteLine("delete Department failed");
            }
        }


        private static bool IsValidDepartmentName(string value)

        {

            // Check if the string contains at least one letter

            return !string.IsNullOrWhiteSpace(value) && value.Any(char.IsLetter);

        }
        private static void UpdateDepartment()
        {
            ListDepartments();
            Console.WriteLine("enter department id to update");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int deptId))
            {
                Console.WriteLine("invalid input");
            }
            var dept = DepartmentBL.GetById(deptId);
            if (dept == null)
            {
                Console.WriteLine("Department not existing");
                return;
            }
            Console.WriteLine("enter new department name");
            input = Console.ReadLine();
            //validation
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("invalid");
                return;
            }
            dept.Name = input;
            bool isUpdated = DepartmentBL.Update(dept);
            if (isUpdated)
            {
                Console.WriteLine("Department updated successfully");
            }
            else
            {
                Console.WriteLine("Department Update Failed");
            }
        }


        private static void AddEmployee()
        {
            Console.WriteLine("Enter Employee Name:");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("invalid entry");
                return;
            }
            Employee emp = new Employee();
            emp.Name = input;

            Console.Write("Enter your email address: ");
            string email = Console.ReadLine();

            if (IsValidEmail(email))
            {
                Console.WriteLine("Valid email address!");
            }
            else
            {
                Console.WriteLine("Invalid email address. Please enter a valid email.");
            }
            static bool IsValidEmail(string email)
            {
                // Regular expression for a basic email validation
                string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

                // Use Regex.IsMatch to check if the email matches the pattern
                return Regex.IsMatch(email, emailPattern);
            }

            emp.Email = input;


            Console.WriteLine("Enter Employee Date of Birth (YYYY-MM-DD):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                if (dob > DateTime.Now)
                {
                    Console.WriteLine("Date of Birth should be in the past. Employee not added.");
                    return;
                }
                emp.DateOfBirth = dob;
            }
            else
            {
                Console.WriteLine("Invalid Date Format. Employee not added.");
                return;
            }
            Console.WriteLine("select employee Gender");
            foreach (var g in Enum.GetNames(typeof(Gender)))
            {
                Console.WriteLine(g);

            }
            if (Enum.TryParse(Console.ReadLine(), out Gender gender))
            {
                emp.Gender = gender;
            }
            else
            {
                Console.WriteLine("Invalid Gender. Employee not added.");
                return;
            }
            Console.WriteLine("Enter Employee Mobile Number:");
            if (long.TryParse(Console.ReadLine(), out long mobileNo))
            {
                string mobileString = mobileNo.ToString();
                if (mobileString.Length != 10)
                {
                    Console.WriteLine("Invalid Mobile Number. It should be 10 digits. Employee not added.");
                    return;
                }
                emp.MobileNo = mobileNo;
            }
            else
            {
                Console.WriteLine("Invalid Mobile Number. Employee not added.");
                return;
            }
            Console.WriteLine("Enter Department ID:");
            if (int.TryParse(Console.ReadLine(), out int departmentId))
            {
                emp.DepartmentId = departmentId;
            }
            else
            {
                Console.WriteLine("Invalid Department ID. Employee not added.");
                return;
            }
            bool isAdded = EmployeeBL.Add(emp);

            if (isAdded)
            {
                Console.WriteLine("Employee Successfully Added");
            }
            else
            {
                Console.WriteLine("Failed to Add Employee");
            }


        }


        private static void AddDepartments()

        {

            Console.WriteLine("Enter Department Name:");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || !IsValidDepartmentName(input))

            {

                Console.WriteLine("Invalid department name");

                return;

            }

            Department dept = new Department();

            dept.Name = input;

            bool isAdded = DepartmentBL.Add(dept);

            if (isAdded)

            {

                Console.WriteLine("Department added successfully");

            }

            else

            {

                Console.WriteLine("Add Department failed");

            }

        }
        static void ListDepartments()
        {
            var list = DepartmentBL.GetDepartments();
            foreach (var dept in list)
            {
                Console.WriteLine(dept);
            }
        }

        static void DeleteEmployee()
        {
            ListEmployee();
            Console.WriteLine("enter Employee id to update");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int empid))
            {
                Console.WriteLine("invalid input");
            }
            var emp = EmployeeBL.GetById(empid);
            if (emp == null)
            {
                Console.WriteLine("Employee does not exist");
                return;

            }
            bool isDeleted = EmployeeBL.Delete(emp);
            if (isDeleted)
            {
                Console.WriteLine("Employee deleted successfully");

            }
            else
            {
                Console.WriteLine("delete Employee failed");
            }
        }
    }
}