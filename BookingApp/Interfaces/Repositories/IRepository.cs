namespace BookingApp.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        void Add (T data);
        void Remove (T data);
        void Update (T data);
        T Get(int id);
    }
}
