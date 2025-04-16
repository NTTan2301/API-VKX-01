namespace VKX_API01.Help.BaseSerivce
{
    public interface IBaseService
    {
        Task<List<TDto>> GetAll<TEntity, TDto>()
         where TEntity : class
         where TDto : class;

        Task<TDto?> GetById<TEntity, TDto>(object id)
            where TEntity : class
            where TDto : class;

        Task<TDto> Create<TEntity, TDto>(TDto dto)
            where TEntity : class
            where TDto : class;

        Task<bool> Update<TEntity, TDto>(object id, TDto dto)
            where TEntity : class
            where TDto : class;

        Task<bool> Delete<TEntity>(object id)
            where TEntity : class;
    }
}
