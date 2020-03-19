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
    public class BankAccountController : Controller
    {
        [HttpGet]
        public ActionResult<List<BankAccount>> Get([FromServices] IBankAccountRepository repository)
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
        public IActionResult Get([FromServices] IBankAccountRepository repository, int id)
        {
            try
            {
                BankAccount BankAccount = repository.Get().Include(x=>x.Transactions).AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (User == null)
                    return NotFound(new { message = "Conta inválida" });
                return Ok(User);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult<BankAccount> Create(
            [FromServices] IBankAccountRepository repository,
            [FromBody]BankAccount model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Add(model);
                    return Ok(new { message = "Conta adicionada" });
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public ActionResult<BankAccount> Update(
            [FromServices] IBankAccountRepository repository,
            [FromBody]BankAccount model)
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
        public ActionResult<BankAccount> Delete(
          [FromServices] IBankAccountRepository repository, int id)
        {
            try
            {
                BankAccount ca = repository.Get().AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (User == null)
                {
                    return NotFound(new { message = "Conta inválida" });
                }
                repository.Delete(ca);
                return Ok(new { message = "Conta excluida" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
