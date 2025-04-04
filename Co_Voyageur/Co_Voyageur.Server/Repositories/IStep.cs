namespace Co_Voyageur.Server.Repositories
{
    public interface IStep<T, Tid> where T : new()
    {
        T? Add(T item);
        T? GetById(Tid id);
        IEnumerable<T> GetAll();
        T? Update(Tid id, T item);
        bool Delete(Tid id);
    }
}
