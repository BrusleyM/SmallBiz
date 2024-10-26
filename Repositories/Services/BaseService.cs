using SmallBizAPI.Data;
namespace SmallBizAPI.Repositories.Services{
public class BaseService
    {
        protected readonly SmallBizDBContext _context;

        public BaseService(SmallBizDBContext context)
        {
            _context = context;
        }
    }
}