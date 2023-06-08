using API.Data.DTOs;
using API.Data.Entities;
using API.Data.services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EntryController : BaseApiController
    {
        private readonly IEntryService _entryService;

        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }


        [HttpGet]
        public async Task<ActionResult<PagedResponse<List<Entry>>>> GetAllEntry(int skip, int limit)
        {
            var result = await _entryService.GetAllEntries(skip,limit);

            return Ok(result);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<PagedResponse<List<Entry>>>> GetEntryById(int id)
        {
            var result = await _entryService.GetEntryById(id);
            if (result.Error != null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEntry(int id)
        {
            var result = await _entryService.DeleteEntry(id);

            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "problem deleting Entry" });
        }

        [HttpPost]
        public async Task<ActionResult<Response<EntryDto>>> CreateEntry([FromBody] CreateEntryDto entryDto)
        {
            var userEmail = User.Identity?.Name;
            var result = await _entryService.CreateEntry(userEmail,entryDto);

            if (result.Error != null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}