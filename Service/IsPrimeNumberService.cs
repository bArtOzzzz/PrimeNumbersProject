using Repository.Abstract;
using Service.Abstract;

namespace Service
{
    public class IsPrimeNumberService : IIsPrimeNumberService
    {
        private readonly IIsPrimeNumberRepository _isPrimeNumberRepository;

        public IsPrimeNumberService(IIsPrimeNumberRepository isPrimeNumberRepository)
        {
            _isPrimeNumberRepository = isPrimeNumberRepository;
        }

        // POST
        public Task<bool> CreateNumberAsync(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return Task.FromResult(false);
            }

            _isPrimeNumberRepository.CreateNumberAsync(number);

            return Task.FromResult(true);
        }
    }
}
