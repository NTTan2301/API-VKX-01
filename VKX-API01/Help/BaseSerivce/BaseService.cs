
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using VKX_API01.Help.Paging;
using VKX_API01.Help.Reponse;

namespace VKX_API01.Help.BaseSerivce
{
    public class BaseService : IBaseService
    {
        private readonly IReponsitory _repository;
        private readonly IMapper _mapper;

        public BaseService(IReponsitory repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Generic method cho GetAll
        public async Task<List<TDto>> GetAll<TEntity, TDto>()
            where TEntity : class
            where TDto : class
        {
            // Lấy danh sách entities từ repository
            var entities = await _repository.GetAllAsync<TEntity>();

            // Ánh xạ từ Entity sang DTO
            return _mapper.Map<List<TDto>>(entities);
        }

        // Generic method cho GetById
        public async Task<TDto?> GetById<TEntity, TDto>(object id)
            where TEntity : class
            where TDto : class
        {
            // Lấy entity từ repository
            var entity = await _repository.GetByIdAsync<TEntity>(id);

            // Ánh xạ từ Entity sang DTO
            return entity == null ? null : _mapper.Map<TDto>(entity);
        }

        // Generic method cho Add
        public async Task<TDto> Create<TEntity, TDto>(TDto dto)
            where TEntity : class
            where TDto : class
        {
            // Ánh xạ DTO thành Entity
            var entity = _mapper.Map<TEntity>(dto);

            // Thêm entity vào DB
            var addedEntity = await _repository.AddAsync(entity);

            // Trả về DTO
            return _mapper.Map<TDto>(addedEntity);
        }

        // Generic method cho Update
        public async Task<bool> Update<TEntity, TDto>(object id, TDto dto)
            where TEntity : class
            where TDto : class
        {
            // Tìm entity gốc
            var existingEntity = await _repository.GetByIdAsync<TEntity>(id);
            if (existingEntity == null)
                return false;

            // Ánh xạ dto vào entity đã tồn tại (chứ không tạo entity mới)
            _mapper.Map(dto, existingEntity);

            // Lưu thay đổi
            await _repository.SaveAsync();
            return true;
        }

        // Generic method cho Delete
        public async Task<bool> Delete<TEntity>(object id)
            where TEntity : class
        {
            // Xóa entity từ DB
            return await _repository.DeleteAsync<TEntity>(id);
        }

        public async Task<PagedResult<TDto>> GetAllPagedAsync<TEntity, TDto>(PagingParams<TDto> pagingParams)
             where TEntity : class
             where TDto : class
        {
            IQueryable<TEntity> query = _repository.Query<TEntity>();

            var dtoPredicates = pagingParams.GetPredicates();
            foreach (var dtoPredicate in dtoPredicates)
            {
                var entityPredicate = _mapper.MapExpression<Expression<Func<TEntity, bool>>>(dtoPredicate);
                query = query.Where(entityPredicate);
            }

            var totalCount = await query.CountAsync();

            var skip = (pagingParams.PageNumber - 1) * pagingParams.PageSize;
            var entities = await query.Skip(skip).Take(pagingParams.PageSize).ToListAsync();

            var dtos = _mapper.Map<List<TDto>>(entities);

            return new PagedResult<TDto>
            {
                Items = dtos,
                TotalCount = totalCount,
                PageNumber = pagingParams.PageNumber,
                PageSize = pagingParams.PageSize
            };
        }
    }
}
