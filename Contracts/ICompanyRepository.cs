using System.Collections.Generic;
using System.Threading.Tasks;

namespace dapperTest {
    public interface ICompanyRepository {
        public Task<IEnumerable<Company>> GetCompanies ();
        public Task<Company> GetCompany (int id);
        public Task<Company> CreateCompany (CreateCompanyDto company);
        public Task UpdateCompany (int id, UpdateCompanyDto company);
        public Task DeleteCompany (int id);
        public Task<Company> GetCompanyByEmployeeId (int employeeId);
        public Task<Company> GetCompanyEmployeesMultipleResults (int id);
        public Task<List<Company>> GetCompaniesEmployeesMultipleMapping ();

    }
}