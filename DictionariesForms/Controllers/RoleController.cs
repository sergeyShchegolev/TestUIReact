using DataAccess.Interfaces;
using DataAccess.Models;
using DictionariesForms.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DictionariesForms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoleItems()
        {
            var dtos = await _unitOfWork.Roles.GetAllAsync();
            return dtos.Select(x => ItemToDTO(x)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRoleItem(int id)
        {
            var item = await _unitOfWork.Roles.GetAsync(id);
            if (item == null) { return NotFound(); }

            return ItemToDTO(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleItem(int id, RoleDTO dto)
        {
            var item = new DataAccess.Models.Role
            {
                Id = (int)dto.Id,
                Name = dto.Name,
            };

            try
            {
                await _unitOfWork.Roles.UpdateAsync(item);
            }
            catch (Exception e)
            {
                throw e;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> PostRoleItem(RoleDTO dto)
        {
            var item = new Role
            {
                Name = dto.Name
            };

            await _unitOfWork.Roles.CreateAsync(item);

            return CreatedAtAction(
                nameof(GetRoleItems),
                new { id = item.Id },
                ItemToDTO(item));
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRoleItem(int id)
        {
            await _unitOfWork.Roles.DeleteAsync(id);

            return NoContent();
        }

        private static RoleDTO ItemToDTO(Role roleItem) =>
           new()
           {
               Id = roleItem.Id,
               Name = roleItem.Name,

               value = roleItem.Id,
               label = roleItem.Name,
           };
    }
}