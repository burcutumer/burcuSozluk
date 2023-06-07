using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.services
{
    public class TagService : ITagService
    {
        private readonly StoreContext _context;
        public TagService(StoreContext context)
        {
            _context = context;

        }

        public async Task<Response<TagDto>> CreateTag(CreateTagDto tagDto)
        {
            var tag = new Tag
            {
                Name = tagDto.Name
            };
            await _context.Tags.AddAsync(tag);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
            {
                return new Response<TagDto>
                {
                    Error = "couldnt create Tag"
                };
            }
            return new Response<TagDto>
            {
                Data = MapTagDto(tag)
            };
        }

        public async Task<PagedResponse<List<TagDto>>> GetAllTags(int skip, int limit)
        {
            limit = limit > 10 ? 10 : limit;

            var allTags = await _context.Tags.Select(t => MapTagDto(t)).Skip(skip).Take(limit).ToListAsync();
            var count = await _context.Tags.CountAsync();

            return new PagedResponse<List<TagDto>>
            {
                Data = allTags,
                Limit= limit,
                Skip = skip,
                Total = count
            };
        }

        public async Task<Response<TagDto>> GetTagById(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(n => n.Id == id);
            if (tag != null)
            {
                return new Response<TagDto>
                {
                    Data = MapTagDto(tag)
                };
            }
            return new Response<TagDto>
            {
                Error = "Tag can not be found"
            };
        }

        private static TagDto MapTagDto(Tag tag)
        {
            return new TagDto
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }
    }
}