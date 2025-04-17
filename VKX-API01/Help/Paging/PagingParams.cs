using System.Linq.Expressions;

namespace VKX_API01.Help.Paging
{
    public class PagingParams<TDto>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual List<Expression<Func<TDto,bool>>> GetPredicates()
        {
            return new List<Expression<Func<TDto, bool>>>();
        }
    }
}
