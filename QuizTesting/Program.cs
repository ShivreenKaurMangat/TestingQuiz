using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTesting
{
    class Program
    {
        public interface IDataAccess
        {
            double GetSalaryOfEmployee(int id);
            List<Employee> GetTopThreePaidEmployees();
            Employee GetEmployee(int id);
        }

        public class DataAccess : IDataAccess
        {
            Employee_DatabaseEntities db = new Employee_DatabaseEntities();
            public double GetSalaryOfEmployee(int id)
            {
                var employeeSalary = Convert.ToDouble(db.Employees.Find(id).Salary);
                return employeeSalary;
            }

            public List<Employee> GetTopThreePaidEmployees()
            {
                var paidEmployee = db.Employees.OrderByDescending(e => e.Salary).Take(3).ToList();
                return paidEmployee;
            }

            public Employee GetEmployee(int id)
            {
                return db.Employees.Find();
            }
        }

        public class BusinessLogic
        {
            IDataAccess dta;
            public BusinessLogic(IDataAccess dta)
            {
                this.dta = dta;
            }

            public List<Employee> GetTopThreePaidEmployees()
            {
                return dta.GetTopThreePaidEmployees();
            }

            public double GetSalaryOfEmployee(int id)
            {
                return dta.GetSalaryOfEmployee(id);
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
