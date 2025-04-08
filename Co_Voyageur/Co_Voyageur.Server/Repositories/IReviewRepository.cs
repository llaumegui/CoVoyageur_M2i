namespace Co_Voyageur.Server.Repositories
{
    public interface IReviewRepository<T, Tid> where T : new()
    {
        T? Add(T item);
        T? GetById(Tid id);
        IEnumerable<T> GetAll();
        T? Update(Tid id, T item);
        bool Delete(Tid id);
    }
}
