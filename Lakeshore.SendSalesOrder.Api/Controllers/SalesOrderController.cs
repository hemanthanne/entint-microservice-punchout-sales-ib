using Lakeshore.SendSalesOrder.Application.SendSalesOrder.Command.UpdateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lakeshore.SendSalesOrder.Controllers
{
    [ApiController]
    [Route("entint-microservice-punchout-sales-ib")]
    public class SalesOrderController : ControllerBase
    {       
        private readonly Serilog.ILogger _logger;

        private readonly IMediator _mediator;
       
        public SalesOrderController(  IMediator mediator, Serilog.ILogger logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("extract")]
        public async Task<ActionResult<bool>> ExtractAllSalesOrder(CancellationToken cancellationToken)
        {
            try
            {
                var extracted = await _mediator.Send(new ExtractSalesOrderCommand(), cancellationToken);
                
                return Ok(extracted);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }

           
        }

    }
}