using Microsoft.AspNetCore.Mvc;
using SamplePOC.Domain.Aggregates;
using SamplePOC.Domain.Entities;
using SamplePOC.Domain.Interfaces;

namespace SamplePOC.Application.Controller
{
    [Route("api/biller")]
    public class BillerController : ControllerBase
    {
        private readonly IBillerRepository _billerRepository;

        public BillerController(IBillerRepository billerRepository)
        {
            _billerRepository = billerRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Biller> GetBiller(int id)
        {
            var customer = _billerRepository.GetBillerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateBiller([FromBody] Biller biller)
        {
            _billerRepository.AddBiller(biller);
            return CreatedAtAction(nameof(GetBiller), new { id = biller.BillerId }, biller);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBiller(int id, [FromBody] Biller biller)
        {
            if (id != biller.BillerId)
            {
                return BadRequest();
            }
            _billerRepository.UpdateBiller(biller);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBiller(int id)
        {
            var biller = _billerRepository.GetBillerById(id);
            if (biller == null)
            {
                return NotFound();
            }
            _billerRepository.RemoveBiller(biller);
            return NoContent();
        }
    }
}
