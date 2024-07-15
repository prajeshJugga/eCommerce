using eCommerceDatabase.Models;

namespace eCommerceApi.Repositories
{
    public interface IActiveSpecialRepository
    {
        List<ActiveSpecial> GetActiveSpecials();

        List<ActiveSpecial> GetActiveSpecialsByProductIds(List<int> productIds);
        ActiveSpecial? GetActiveSpecialById(int activeSpecialId);
    }
}
