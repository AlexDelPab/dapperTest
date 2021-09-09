using System.Collections.Generic;
using System.Threading.Tasks;

namespace dapperTest {
    public interface IEmployeeRepository {
        public Task<IEnumerable<Employee>> GetEmployees ();
        public Task<Employee> GetEmployee (int id);
        public Task<Employee> GetEmployeeWithoutRelations (int id);
    }

}