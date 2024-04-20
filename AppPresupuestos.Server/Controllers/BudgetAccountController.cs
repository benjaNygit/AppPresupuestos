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
        public ActionResult<BudgetAccount> Get(byte level)
        {
            List<Presupuestos.BudgetAccount> list = Presupuestos.BudgetAccount.GetLevels(level);
            return StatusCode(StatusCodes.Status200OK, list);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult<Presupuestos.BudgetAccount> Post(Presupuestos.BudgetAccount budgetAccount)
        {
            try
            {
                Presupuestos.BudgetAccount model = budgetAccount;
                using (Presupuestos.Context context = new Presupuestos.Context())
                {
                    decimal numberAccount = Presupuestos.BudgetAccount.GenerateNumberAccount(model);
                    if (Presupuestos.BudgetAccount.Get(numberAccount) is not null)
                        throw new Exception(string.Format("Ya existe una cuenta presupuestaria con el número de cuenta {0}", numberAccount));

                    model.NumberAccount = numberAccount;
                    context.BudgetAccounts.Add(model);
                    context.SaveChanges();
                }

                return StatusCode(StatusCodes.Status201Created, model);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
        }
        #endregion
    }
}
