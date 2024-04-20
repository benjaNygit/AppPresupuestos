using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presupuestos;
using System.Runtime.CompilerServices;

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
        public ActionResult<Presupuestos.BudgetAccount> Post(Presupuestos.BudgetAccount budgetAccount)
        {
            Guid id = Guid.NewGuid();
            Presupuestos.BudgetAccount model = budgetAccount;
            using(Presupuestos.Context context = new Presupuestos.Context())
            {
                model.NumberAccount = 1;
                context.BudgetAccounts.Add(model);
                context.SaveChanges();
            }

            return StatusCode(StatusCodes.Status201Created, model);
        }
        #endregion
    }
}
