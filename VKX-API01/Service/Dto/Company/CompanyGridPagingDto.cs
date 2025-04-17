using System.Linq.Expressions;
using VKX_API01.Help.Paging;

namespace VKX_API01.Service.Dto.Company
{
    public class CompanyGridPagingDto : PagingParams<CompanyGridDto>
    {
        public string? filterName { get; set; }

        public override List<Expression<Func<CompanyGridDto,bool>>> GetPredicates()
        {
            var predicates = new List<Expression<Func<CompanyGridDto, bool>>>();

            if (!string.IsNullOrEmpty(filterName))
            {
                predicates.Add(x => x.Name.Contains(filterName));
            }

            return predicates;
        }
    }
}
