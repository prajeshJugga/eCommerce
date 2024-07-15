using eCommerceApi.Exceptions;
using eCommerceDatabase.Models;
using System.Collections.Generic;

namespace eCommerceApi.Repositories
{
    public class ActiveSpecialsRepository : IActiveSpecialRepository
    {
        private readonly ECommerceContext _context;
        private readonly ILogger<ActiveSpecialsRepository> _logger;

        public ActiveSpecialsRepository(ECommerceContext context, ILogger<ActiveSpecialsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public ActiveSpecial? GetActiveSpecialById(int activeSpecialId)
        {
            ActiveSpecial activeSpecial = _context.ActiveSpecials
                .SingleOrDefault(i => i.Id == activeSpecialId);
            //if (activeSpecial == null)
            //{
            //    throw new SpecialNotFoundException();
            //}
            return activeSpecial;
        }

        public List<ActiveSpecial> GetActiveSpecials()
        {
            List<ActiveSpecial> activeSpecials = new List<ActiveSpecial>();
            activeSpecials = _context.ActiveSpecials
                .Where(i => i.EndDate >= DateTime.UtcNow)
                .ToList();
            return activeSpecials;
        }

        public List<ActiveSpecial> GetActiveSpecialsByProductIds(List<int> uniqueProductIds)
        {
            List<ActiveSpecial> allSpecials = GetActiveSpecials();
            //List
            List <ActiveSpecial> relatedSpecials = new List<ActiveSpecial>();
            foreach (int id in uniqueProductIds)
            {
                foreach (var item in allSpecials)
                {
                    if (item.ProductsOnSpecial.Select(i => i.ProductId).Contains(id))
                    {
                        relatedSpecials.Add(item);
                    }
                }
            }

            return relatedSpecials;
        }
    }
}
