using DataAccess.Interfaces;
using DataAccess.Models;
using DictionariesForms.DTO;
using DictionariesForms.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DictionariesForms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhaseController : ControllerBase
    {
        private const string objectName = "dbo.Phases";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionsHelper _permissionHelper;

        public PhaseController(
            IUnitOfWork unitOfWork,
            IPermissionsHelper permissionHelper)
        {
            _unitOfWork = unitOfWork;
            _permissionHelper = permissionHelper;
            _permissionHelper.PopulateUserObjectPermissions(Environment.UserName, objectName);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhaseDTO>>> GetPhaseItems()
        {
            //if(!_permissionHelper.HasReadPermission())
            //{
            //    return new ObjectResult("Недостаточно прав для выполнения операции") { StatusCode = 403 };
            //}
            //else
            //{
            var dtos = await _unitOfWork.Phases.GetAllAsync();
            return dtos.Select(x => ItemToDTO(x)).ToList();
            //}
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhaseDTO>> GetPhaseItem(int id)
        {
            //if (!_permissionHelper.HasReadPermission())
            //{
            //    return new ObjectResult("Недостаточно прав для выполнения операции") { StatusCode = 403 };
            //}
            //else
            //{
            var item = await _unitOfWork.Phases.GetAsync(id);
            if (item == null) { return NotFound(); }

            return ItemToDTO(item);
            //}
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhaseItem(int id, PhaseDTO dto)
        {
            //if (!_permissionHelper.HasUpdatePermission())
            //{
            //    return new ObjectResult("Недостаточно прав для выполнения операции") { StatusCode = 403 };
            //}
            //else
            //{
            var item = new DataAccess.Models.Phase
            {
                Name = dto.Name,
                RoleId = (int)dto.RoleId,
                IsRequiredProcessPhase = dto.IsRequiredProcessPhase == "1" ? true : false,
                PhaseOrder = int.Parse(dto.PhaseOrder),
                IsActive = dto.IsActive == "1" || dto.IsActive.ToLower() == "true" ? true : false,
                VersionNumber = (int?)dto.VersionNumber,
        };

            try
            {
                await _unitOfWork.Phases.UpdateAsync(item);
            }
            catch (Exception e)
            {
                throw e;
            }

            return NoContent();
            //}
        }

        [HttpPost]
        public async Task<ActionResult<PhaseDTO>> PostPhaseItem(PhaseDTO dto)
        {
            //if (!_permissionHelper.HasCreatePermission())
            //{
            //    return new ObjectResult("Недостаточно прав для выполнения операции") { StatusCode = 403 };
            //}
            //else
            //{
            var item = new Phase
            {
                Name = dto.Name,
                RoleId = (int)dto.RoleId,
                IsRequiredProcessPhase = dto.IsRequiredProcessPhase == "1" ? true : false,
                PhaseOrder = int.Parse(dto.PhaseOrder),
                IsActive = true,
                VersionNumber = 0,
            };

            await _unitOfWork.Phases.CreateAsync(item);

            return CreatedAtAction(
                nameof(GetPhaseItems),
                new { id = item.Id },
                ItemToDTO(item));
            //}
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhaseItem(int id)
        {
            //if (!_permissionHelper.HasDeletePermission())
            //{
            //    return new ObjectResult("Недостаточно прав для выполнения операции") { StatusCode = 403 };
            //}
            //else
            //{
            await _unitOfWork.Phases.DeleteAsync(id);

            return NoContent();
            //}
        }

        private static PhaseDTO ItemToDTO(Phase phaseItem) =>
           new()
           {
               Id = phaseItem.Id,
               Name = phaseItem.Name,
               RoleId = phaseItem.RoleId,
               RoleName = phaseItem?.Role?.Name,
               IsRequiredProcessPhase = phaseItem.IsRequiredProcessPhase.ToString(),
               PhaseOrder = phaseItem.PhaseOrder.ToString(),
               IsActive = phaseItem.IsActive.ToString(),
               VersionNumber = phaseItem.VersionNumber,
           };
    }
}