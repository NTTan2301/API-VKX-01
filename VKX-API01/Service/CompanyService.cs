using VKX_API01.Help.BaseSerivce;
using VKX_API01.Help.Paging;
using VKX_API01.Help.Reponse;
using VKX_API01.Models;
using VKX_API01.Service.Dto.Company;

namespace VKX_API01.Service
{
    public class CompanyService
    {
        private readonly IReponsitory _repository;
        private readonly IBaseService _baseService;
        public CompanyService(IReponsitory reponsitory, IBaseService baseService)
        {
                _repository = reponsitory;
                 _baseService = baseService;
        }

        public async Task<PagedResult<CompanyGridDto>> GetPagingAsync(CompanyGridPagingDto pagingParams)
        {
            var result = await _baseService.GetAllPagedAsync<Company, CompanyGridDto>(pagingParams);

            return result;
        }

        public async Task<List<CompanyGridDto>> getAll()
        {
            var lstCompany = await _baseService.GetAll<Company, CompanyGridDto>();
                return lstCompany;
        }
        public async Task<CompanyDetailDto> GetById(int Id)
        {
            var company = await _baseService.GetById<Company,CompanyDetailDto>(Id);
            return company;
        }
        public async Task<CompanyCreateDto> Create(CompanyCreateDto model)
        {
            var companyCreate = await _baseService.Create<Company, CompanyCreateDto>(model);
            return companyCreate;
        }
        public async Task<bool> Update(int Id, CompanyUpdateDto model)
        {
            var companyUpdate = await _baseService.Update<Company,CompanyUpdateDto>(Id, model);
            return companyUpdate;
        }
        public async Task<bool> Delete(int Id)
        {
            var IdDelete = await _repository.DeleteAsync<Company>(Id);
            return IdDelete;
        }

    }
}
