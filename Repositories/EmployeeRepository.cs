using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace dapperTest {

    public class EmployeeRepository : IEmployeeRepository {

        private readonly DapperContext _context;

        public EmployeeRepository (DapperContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees () {
            var query = "SELECT * FROM Employees e left join Companies c on c.Id = e.CompanyId";

            using (var connection = _context.CreateConnection ()) {
                var employees = await connection.QueryAsync<Employee, Company, Employee> (query, (employee, company) => { employee.Company = company; return employee; });
                return employees;
            }

        }

        public async Task<Employee> GetEmployee (int id) {
            var query = "SELECT * FROM Employees e left join Companies c on c.Id = e.CompanyId WHERE e.Id = @Id";

            using (var connection = _context.CreateConnection ()) {
                var employees = await connection.QueryAsync<Employee, Company, Employee> (query, (employee, company) => { employee.Company = company; return employee; }, new { id });
                return employees.First();
            }
        }

        public async Task<Employee> GetEmployeeWithoutRelations (int id) {
            var query = "SELECT * FROM Employees e WHERE e.Id = @Id";

            using (var connection = _context.CreateConnection ()) {
                var employee = await connection.QueryFirstOrDefaultAsync<Employee> (query, new { id });
                return employee;
            }

        }
    }

}