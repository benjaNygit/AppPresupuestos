using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetAccountController : ControllerBase
    {
        public BudgetAccountController()
        {
        }

        [HttpGet(Name = "GetBudgetAccounts")]
        public IActionResult Get()
        {
            List<Presupuestos.BudgetAccount> list = Presupuestos.BudgetAccount.GetAll();

            return StatusCode(StatusCodes.Status200OK, list);
        }
    }
}
