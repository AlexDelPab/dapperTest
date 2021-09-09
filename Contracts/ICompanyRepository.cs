using System.Collections.Generic;
using System.Threading.Tasks;

namespace dapperTest {
    public interface ICompanyRepository {
        public Task<IEnumerable<Company>> GetCompanies ();
        public Task<Company> GetCompany (int id);
        public Task<Company> CreateCompany (CreateCompanyDto company);
    }
}