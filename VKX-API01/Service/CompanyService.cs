using VKX_API01.Help.Reponse;
using VKX_API01.Models;

namespace VKX_API01.Service
{
    public class CompanyService
    {
        private readonly IReponsitory _repository;
        public CompanyService(IReponsitory reponsitory)
        {
                _repository = reponsitory;
        }

        public async Task<List<Company>> getAll()
        {
            var lstCompany = await _repository.GetAllAsync<Company>();
            return lstCompany;
        }
        public async Task<Company> GetById(int Id)
        {
            var company = await _repository.GetByIdAsync<Company>(Id);
            return company;
        }
        public async Task<Company> Create(Company model)
        {
            var companyCreate = await _repository.AddAsync<Company>(model);
            return companyCreate;
        }
        public async Task<bool> Update(int Id, Company model)
        {
            var companyUpdate = await _repository.UpdateAsync<Company>(Id, model);
            return companyUpdate;
        }
        public async Task<bool> Delete(int Id)
        {
            var IdDelete = await _repository.DeleteAsync<Company>(Id);
            return IdDelete;
        }

    }
}
