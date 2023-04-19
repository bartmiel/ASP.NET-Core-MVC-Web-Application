using Data.Data;
using Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Models.DtoModels;
using Portal.Services;

namespace Portal.Controllers
{
    public class BaseController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly IParameterService _parameterService;
        private readonly ParametersDto parametersDto;
        private readonly BlogSectionDto blogSectionDto;
        public BaseController(ApplicationDbContext context, IParameterService parameterService)
        {
            _context = context;
            _parameterService = parameterService ??
                throw new ArgumentNullException(nameof(parameterService));
            parametersDto = new ParametersDto();
            blogSectionDto = new BlogSectionDto();
        }
        public ParametersDto GetParameters()
        {
            parametersDto.Parameters = _parameterService.GetAllParametersValue();
            return parametersDto;
        }
        public BlogSectionDto GetBlogSection()
        {
            blogSectionDto.Blog = _context.Blog.OrderBy(b => b.CreationDate).Take(3).ToList();
            blogSectionDto.ParametersDto = GetParameters();

            return blogSectionDto;
        }
    }
}