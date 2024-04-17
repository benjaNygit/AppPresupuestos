using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presupuestos;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetAccountController : ControllerBase
    {
        public BudgetAccountController()
        {
        }

        #region Get
        [HttpGet]
        public ActionResult<BudgetAccount> Get()
        {
            List<Presupuestos.BudgetAccount> list = Presupuestos.BudgetAccount.GetAll();
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet("{level}")]
        public ActionResult<BudgetAccount> Get(int level)
        {
            List<Presupuestos.BudgetAccount> list = Presupuestos.BudgetAccount.GetLevels(level);
            return StatusCode(StatusCodes.Status200OK, list);
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult<Presupuestos.BudgetAccount>> Post(Presupuestos.BudgetAccount budgetAccount)
        {
            Presupuestos.BudgetAccount model = new Presupuestos.BudgetAccount();
            using (Presupuestos.Context context = new Presupuestos.Context())
            {
                model = new Presupuestos.BudgetAccount
                {
                    Id = Guid.NewGuid(),
                    BudgetAccountId = budgetAccount.BudgetAccountId,
                    Level = budgetAccount.Level,
                    Description = budgetAccount.Description
                };
                context.Add(model);
                context.SaveChanges();
            }
            return StatusCode(StatusCodes.Status201Created, model);
        }
        #endregion
    }
}
