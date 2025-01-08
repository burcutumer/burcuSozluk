using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;

namespace API.Data.Services
{
    public interface ICommentService
    {
        Task<PagedResponse<List<CommentDto>>> GetAllComments(int skip, int limit,int entryId);
        Task<Response<CommentDto>> CreateComment(string userEmail, CreateCommentDto commentDto, int entryId);
    }
}