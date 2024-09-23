using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDropDownMenu.Models;
using CarDropDownMenu.Data;
using Microsoft.EntityFrameworkCore;

namespace CarDropDownMenu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarRentalController : ControllerBase
    {
        private readonly CarRentalDbContext _context;

        public CarRentalController(CarRentalDbContext context)
        {
            _context = context;
        }

        // GET: api/CarRental/GetCarBrand
        [HttpGet("GetCarBrand")]
        public async Task<ActionResult<IEnumerable<CarBrand>>> GetCarBrands()
        {
            // Fetch only the car brands where ActiveFlag is true
            var carBrands = await _context.CarBrands
                                          .Where(brand => brand.ActiveFlag == true)
                                          .ToListAsync();

            if (carBrands == null || carBrands.Count == 0)
            {
                return NotFound("No active car brands found.");
            }

            return Ok(carBrands);
        }

        // GET: api/CarRental/GetCarMake/{brand}
   [HttpGet("GetCarMake/{brand}")]
public async Task<ActionResult<IEnumerable<CarMake>>> GetCarMake(string brand)
{
    if (string.IsNullOrEmpty(brand))
    {
        return BadRequest("Brand name is required.");
    }

    // Find the active car brand by brand name
    var carBrand = await _context.CarBrands
        .FirstOrDefaultAsync(b => b.BrandName.ToLower() == brand.ToLower() && b.ActiveFlag == true);

    if (carBrand == null)
    {
        return NotFound($"Active car brand '{brand}' not found.");
    }

    // Fetch car makes where both the brand and the make are active
    var carMake = await _context.CarBrandCarMakeMatrix
        .Where(matrix => matrix.CarBrandId == carBrand.CarBrandId)
        .Select(matrix => matrix.CarMakeId)
        .Join(_context.CarMake,
              makeId => makeId,
              make => make.CarMakeId,
              (makeId, make) => make)
        .Where(make => make.ActiveFlag == true)  // Only select active car makes
        .ToListAsync();

    if (carMake == null || carMake.Count == 0)
    {
        return NotFound($"No active car makes found for the brand '{brand}'.");
    }

    return Ok(carMake);
}

        // POST: api/CarRental/PostSubmit
        [HttpPost("PostSubmit")]
        public async Task<ActionResult> PostSubmit([FromBody] Submit submission)
        {
            if (string.IsNullOrEmpty(submission.CarBrandID) || string.IsNullOrEmpty(submission.CarMakeID))
            {
                return BadRequest("Missing required submission data.");
            }

            // Save the submission to the Submit table
            _context.Submit.Add(submission);  // Use the Submit DbSet
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Submission saved successfully",
                Submission = submission
            });
        }
    }
}
