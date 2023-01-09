using System.Diagnostics.CodeAnalysis;

namespace Repository.Entities
{
    [ExcludeFromCodeCoverage]
    public class PrimeNumberEntity
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
