using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProducrCQRS.CQRS.Command;
using ProducrCQRS.CQRS.Query;
using ProducrCQRS.Profiles;

namespace ProducrCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        
        private readonly IMediator _mediator;
        private readonly AppSettingsProfile _appSettings;
        public ProductController(IMediator mediator, 
            IOptions<AppSettingsProfile> options)
        {
            _mediator = mediator;
            _appSettings = options.Value;
        }

        [HttpGet("config")]
        public IActionResult GetConfig()
        {
            return Ok(new
            {
                AppName = _appSettings.ApplicationName,
                MaxProducts = _appSettings.MaxProductsPerPage
            });
        }
        /*
         Зробити конфігурацію для адмін прав(3 конфігурації)
            1.username
            2.password
            3.role
        зробити ендпоінт для перевірки прав
         */
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator
                .Send(new GetAllProductsQueryRequest());
            return Ok(result);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequst request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
