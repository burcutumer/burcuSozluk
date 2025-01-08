using API.Data.DTOs;
using API.Data.Entities;
using API.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CommentController : BaseApiController
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{entryId}")]
        public async Task<ActionResult<PagedResponse<List<Comment>>>>
        GetAllComments(int skip, int limit, int entryId)
        {
            var result = await _commentService.GetAllComments(skip, limit, entryId);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("{entryId}")]
        public async Task<ActionResult<Response<Comment>>> CreateComment([FromBody] CreateCommentDto dto,int entryId)
        {
            var userEmail = User.Identity?.Name;
            var result = await _commentService.CreateComment(userEmail,dto,entryId);
            if (result.Error != null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}