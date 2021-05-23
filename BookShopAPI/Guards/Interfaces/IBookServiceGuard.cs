namespace BookShopAPI.Guards.Interfaces
{
    public interface IBookServiceGuard
    {
        void CheckBookShopExistsById(int bookShopId);
    }
}