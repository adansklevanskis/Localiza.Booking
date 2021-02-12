using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Vehicles.API.Infraestructure;
using Vehicles.API.IntegrationEvents;
using Vehicles.API.Model;
using Vehicles.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehicles.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        // GET: api/<VehiclesController>
        private readonly VehicleContext _vehicleContext;
        private readonly ICatalogIntegrationEventService _vehicleIntegrationEventService;

        public VehiclesController(VehicleContext context, ICatalogIntegrationEventService catalogIntegrationEventService)
        {
            _vehicleContext = context ?? throw new ArgumentNullException(nameof(context));
            _vehicleIntegrationEventService = catalogIntegrationEventService ?? throw new ArgumentNullException(nameof(catalogIntegrationEventService));

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        // GET api/v1/[controller][?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Vehicle>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<Vehicle>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> VehiclesAsync([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var totalItems = await _vehicleContext.Vehicles
               .LongCountAsync();

            var itemsOnPage = await _vehicleContext.Vehicles
                .OrderBy(c => c.Id)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            var model = new PaginatedItemsViewModel<Vehicle>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }
    }
}
