using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccountService.Domain.Model;
using BankAccountService.Domain.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BankAccountService.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class TransactionController : Controller
    {
        [HttpGet]
        public ActionResult<List<Transaction>> Get([FromServices] ITransactionRepository repository)
        {
            try
            {
                return Ok(repository.Get().AsNoTracking().ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromServices] ITransactionRepository repository, int id)
        {
            try
            {
                Transaction Transaction = repository.Get().AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (User == null)
                    return NotFound(new { message = "Transação inválida" });
                return Ok(User);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult<Transaction> Create(
            [FromServices] ITransactionRepository transactionRepository,
            [FromServices] IBankAccountRepository bankRepository,
            [FromBody]Transaction model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    switch (model.Operation)
                    {
                        case OperationType.Withdraw:
                            model.MainAccount.MakeWithdrawal(model.Amount, model.Date);
                            bankRepository.Update(model.MainAccount);
                            break;
                        case OperationType.Deposit:
                            model.MainAccount.MakeDeposit(model.Amount, model.Date);
                            bankRepository.Update(model.MainAccount);
                            break;
                        case OperationType.Transfer:
                            model.SourceAccount.MakeTransfer(model.Amount, model.DestinationAccount);
                            bankRepository.Update(model.SourceAccount);
                            bankRepository.Update(model.DestinationAccount);
                            break;
                        default:
                            break;
                    }
                    transactionRepository.Add(model);
                    return Ok(new { message = "Transação adicionada" });
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public ActionResult<Transaction> Update(
            [FromServices] ITransactionRepository repository,
            [FromBody]Transaction model)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(repository.Update(model));

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Transaction> Delete(
          [FromServices] ITransactionRepository repository, int id)
        {
            try
            {
                Transaction ca = repository.Get().AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (User == null)
                {
                    return NotFound(new { message = "Transação inválida" });
                }
                repository.Delete(ca);
                return Ok(new { message = "Transação excluida" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
