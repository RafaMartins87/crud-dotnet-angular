using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositorys;
using WebAPI.UseCases;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralCostController: ControllerBase
    {
        private readonly IGeneralCostRepository _GeneralCost;
        private readonly IUseCase<GeneralCost> _useCase;
        public GeneralCostController(IGeneralCostRepository GeneralCost, IUseCase<GeneralCost> useCase)
        {
            _GeneralCost = GeneralCost ??
                throw new ArgumentNullException(nameof(GeneralCost));

            _useCase = useCase ?? throw new ArgumentNullException(nameof(_useCase));

        }

        [HttpGet]
        [Route("GetGeneralCost")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _GeneralCost.GetGeneralCost());
        }
        [HttpGet]
        [Route("GetGeneralCostByID/{Id}")]
        public async Task<IActionResult> GetEmpByID(int Id)
        {
            return Ok(await _GeneralCost.GetGeneralCostByID(Id));
        }
        [HttpPost]
        [Route("AddGeneralCost")]
        public async Task<IActionResult> Post(GeneralCost objGeneralCost)
        {
            var objToInsert = await _useCase.Execute(objGeneralCost);

            var result = await _GeneralCost.InsertGeneralCost(objToInsert);
            if (result.GeneralId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateGeneralCost")]
        public async Task<IActionResult> Put(GeneralCost emp)
        {
            await _GeneralCost.UpdateGeneralCost(emp);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteGeneralCost")]
        public JsonResult Delete(int id)
        {
            var result = _GeneralCost.DeleteGeneralCost(id);
            return new JsonResult("Deleted Successfully");
        }


    }
}
