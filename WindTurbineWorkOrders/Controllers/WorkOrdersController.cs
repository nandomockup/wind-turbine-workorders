using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// Testing auto-documentation system workflows
namespace WindTurbineWorkOrders.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkOrdersController : ControllerBase
    {
        private static readonly List<WorkOrder> WorkOrders = Enumerable.Range(1, 15).Select(i => new WorkOrder
        {
            WorkOrderNumber = $"WTWO-{i:0000}",
            TurbineId = $"TURB-{i:000}",
            Description = $"Maintenance for wind turbine {i}",
            Status = i % 2 == 0 ? "Open" : "Closed"
        }).ToList();

        [HttpGet]
        public ActionResult<IEnumerable<WorkOrder>> GetAll()
        {
            return Ok(WorkOrders);
        }

        [HttpGet("{workOrderNumber}")]
        public ActionResult<WorkOrder> GetByNumber(string workOrderNumber)
        {
            var order = WorkOrders.FirstOrDefault(w => w.WorkOrderNumber == workOrderNumber);
            if (order == null)
                return NotFound();
            return Ok(order);
        }
    }

    public class WorkOrder
    {
        public string WorkOrderNumber { get; set; }
        public string TurbineId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
