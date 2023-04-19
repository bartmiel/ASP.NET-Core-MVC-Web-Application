using Data.Data;
using Data.Data.CMS;
using Microsoft.EntityFrameworkCore;

namespace Portal.Services
{
    public interface IParameterService
    {
        Task<string> GetParameterValue(string kod);
        List<KeyValuePair<string, string>> GetAllParametersValue();
    }
    public class ParameterService : IParameterService
    {
        private readonly ApplicationDbContext _context;

        public ParameterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> GetParameterValue(string kod)
        {
            var parameter = await _context.Parameter.Where(pv => pv.Code == kod).FirstAsync();
            return parameter.Value;
        }
        public List<KeyValuePair<string, string>> GetAllParametersValue()
        {
            var parameters =  _context.Parameter.ToList();
            var list = new List<KeyValuePair<string, string>>();
            foreach(var parameter in parameters)
            {
                list.Add(new KeyValuePair<string, string>(parameter.Name, parameter.Value));
            }
            return list;
        }
    }
}