using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetAccountController : ControllerBase
    {
        private readonly Presupuestos.Context context;

        public BudgetAccountController(Presupuestos.Context context)
        {
            this.context = context;
        }

        [HttpGet(Name = "GetBudgetAccounts")]
        public IActionResult Get()
        {
            List<Presupuestos.BudgetAccount> list = this.context.BudgetAccounts.ToList();

            return StatusCode(StatusCodes.Status200OK, list);
        }
    }
}
