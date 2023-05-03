using Fruityvice.Model.RequestModel;
using Fruityvice.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Fruityvice.Controllers
{
    [Route("api/Fruit")]
    [ApiController]
    public class FruityVoiceController : ControllerBase
    {
        public readonly IFruityVoiceService _fruityVoiceService;
        public FruityVoiceController(IFruityVoiceService fruityVoiceService) 
        {
            _fruityVoiceService = fruityVoiceService;
        }

        /// <summary>
        /// Get List of Fruity Details
        /// </summary>
        /// <returns>List of Fruity List</returns>
        [SwaggerOperation(Summary = "Fruity List", Description = "Get List of Fruity Details")]
        [HttpGet,Route("All")]
        public async Task<IActionResult> GetFruityDetailList()
        {
            return Ok(_fruityVoiceService.GetFruityDetailList());
        }

        /// <summary>
        /// Get list of Fruity details based on Family name
        /// </summary>
        /// <param name="fruitySearchRequestModel"></param>
        [SwaggerOperation(Summary = "Fruity List Family", Description = "Get list of Fruity details based on Family name")]
        [HttpPost,Route("Family")]
        public async Task<IActionResult> GetFruityDetailsByFamily(FruitySearchRequestModel fruitySearchRequestModel)
        {
            return Ok(_fruityVoiceService.GetFruityDetailsByFamily(fruitySearchRequestModel));
        }
    }
}
