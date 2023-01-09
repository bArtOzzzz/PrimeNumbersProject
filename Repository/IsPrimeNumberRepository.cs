using Repository.Abstract;
using Repository.Context;
using Repository.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Repository
{
    [ExcludeFromCodeCoverage]
    public class IsPrimeNumberRepository : IIsPrimeNumberRepository
    {
        private readonly DataContext _context;

        public IsPrimeNumberRepository(DataContext context) => _context = context;

        public async Task<bool> CreateNumberAsync(int number)
        {
            PrimeNumberEntity primeNumberEntity = new PrimeNumberEntity()
            {
                Number = number
            };

            await _context.PrimeNumber.AddAsync(primeNumberEntity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
