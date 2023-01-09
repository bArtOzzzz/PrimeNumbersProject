namespace Service.Abstract
{
    public interface IIsPrimeNumberService
    {
        // POST
        Task<bool> CreateNumberAsync(int number);
    }
}
