using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace PrimeNumbersProject.Controllers
{
    [Route("prime")]
    [ApiController]
    public class PrimeNumberController : Controller
    {
        private readonly IIsPrimeNumberService _isPrimeNumberService;

        public PrimeNumberController(IIsPrimeNumberService isPrimeNumberService)
        {
            _isPrimeNumberService = isPrimeNumberService;
        }

        [HttpPost("IsThisAPrimeNumber")]
        public async Task<ActionResult> IsThisAPrimeNumber(int number)
        {
            bool isPrime = await _isPrimeNumberService.CreateNumberAsync(number);

            if(isPrime)
            {
                return Ok("This number is prime");
            }
            else
            {
                return BadRequest("This number is non-prime");
            }
        }
    }
}
