using System.ComponentModel.DataAnnotations;

namespace VKX_API01.Service.Dto.Company
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
