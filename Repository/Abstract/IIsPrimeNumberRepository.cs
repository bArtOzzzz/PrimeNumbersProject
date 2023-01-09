namespace Repository.Abstract
{
    public interface IIsPrimeNumberRepository
    {
        // POST
        Task<bool> CreateNumberAsync(int number);
    }
}
