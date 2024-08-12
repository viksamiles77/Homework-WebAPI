using Homework_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Beverage>> Get() //https://localhost:7268/api/beverage
        {
            try
            {
                return Ok(StaticDb.Beverages);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured! Contact the admin!");
            }
        }

        [HttpGet("{index}")]
        public ActionResult<Beverage> GetByIndex(int index) // https://localhost:7268/api/beverage/1
        {
            try
            {
                if (index < 0)
                    return BadRequest("Index must have positive value!");
                if (index > StaticDb.Beverages.Count)
                    return NotFound($"Cannot find resource on index {index}");

                return StaticDb.Beverages[index - 1];
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured! Contact the admin!");
            }
        }

        [HttpGet("brandOrType")]
        public ActionResult<List<Beverage>> GetByBrandOrType(string? brand, string? type) // https://localhost:7268/api/Beverage/brandOrType?type=soda
        {
            try
            {
                if (string.IsNullOrEmpty(brand) && string.IsNullOrEmpty(type))
                    return BadRequest("You have to send at least one parameter");

                if (!string.IsNullOrEmpty(brand) && string.IsNullOrEmpty(type))
                {
                    List<Beverage> filteredBeverages = StaticDb.Beverages
                        .Where(x => x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    return Ok(filteredBeverages);
                }

                if (!string.IsNullOrEmpty(type) && string.IsNullOrEmpty(brand))
                {
                    List<Beverage> filteredBeverages = StaticDb.Beverages
                        .Where(x => x.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    return Ok(filteredBeverages);
                }

                var beverages = StaticDb.Beverages
            .Where(x => x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                        x.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
            .ToList();
                return Ok(beverages);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured! Contact the admin!");
            }
        }

        [HttpPost("addBeverage")]
        public ActionResult<Beverage> PostBeverage([FromBody] Beverage newBeverage)
        {
            StaticDb.Beverages.Add(newBeverage);
            return Ok("Beverage added");
        }

        [HttpPost("addBeverageList")]
        public ActionResult<List<Beverage>> PostListOfBeverages([FromBody] List<Beverage> newListBeverage)
        {
            foreach (var beverage in newListBeverage)
                StaticDb.Beverages.Add(beverage);

            return Ok($"{newListBeverage.Count} beverages added successfully!");
        }
    }
}
