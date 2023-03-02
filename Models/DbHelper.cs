using api.EfCore;
using System.Data;

namespace api.Models
{
    public class DbHelper
    {
        private DataContext _context;
        public DbHelper(DataContext context)
        {
            _context = context;
        }
        // Get 
        public List<EmployeesModel> GetEmployees()
        {
            List<EmployeesModel> response = new List<EmployeesModel>();
            var dataList = _context.Employees.ToList();
            dataList.ForEach(row => response.Add(new EmployeesModel()
            {
                ID =row.ID,
                Name =row.Name,
                Email =row.Email,
                Phone = row.Phone,
                Salary = row.Salary,
                Department = row.Department,


            }));
            return response;
        }
        public EmployeesModel GetEmployeeById(int id)
        {
           EmployeesModel response = new EmployeesModel();
            var dataList = _context.Employees.Where(d=> d.ID.Equals(id)).FirstOrDefault();
            return new EmployeesModel()
            {
                ID = dataList.ID,
                Name = dataList.Name,
                Email = dataList.Email,
                Phone = dataList.Phone,
                Salary = dataList.Salary,
                Department = dataList.Department,
            };  
            
        }
        // PUT/POST/PATCH
        public void SaveEmployees(EmployeesModel employeesModel)
        {
            Employees dbTable = new Employees();
            if (employeesModel.ID > 0)
            {
                //PUT
                dbTable = _context.Employees.Where(d => d.ID.Equals(employeesModel.ID)).FirstOrDefault();
                if(dbTable != null)
                {
                    dbTable.Name = employeesModel.Name;
                    dbTable.Department = employeesModel.Department;
                    dbTable.Email = employeesModel.Email;
                    dbTable.Phone = employeesModel.Phone;
                    dbTable.Salary = employeesModel.Salary;

                }

            }
            else
            {    // POST
                dbTable.Name = employeesModel.Name;
                dbTable.Department = employeesModel.Department;
                dbTable.Email = employeesModel.Email;
                dbTable.Phone = employeesModel.Phone;
                dbTable.Salary = employeesModel.Salary;
                _context.Employees.Add(dbTable);
            }


            _context.SaveChanges();



        }

        // Delete 
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Where(d => d.ID.Equals(id)).FirstOrDefault();
           
         if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges(); 
            }
        
        }
    }
  
}
