using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Data.Entities;

namespace API.Data.services
{
    public interface ITagService
    {
        Task<PagedResponse<List<TagDto>>> GetAllTags(int skip, int limit);
        Task<Response<TagDto>> GetTagById(int id);
        Task<Response<TagDto>> CreateTag(CreateTagDto tag);
    }
}