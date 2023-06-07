using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.DTOs;
using API.Data.Entities;
using API.Data.services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TagsController: BaseApiController
    {
        private readonly ITagService _tagService;
        public TagsController(ITagService tagService)
        {
            _tagService = tagService;

        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<List<TagDto>>>> GetAllTags(int skip, int limit)
        {
            var result = await _tagService.GetAllTags(skip, limit);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<TagDto>>> GetTagById(int id)
        {
            var result = await _tagService.GetTagById(id);

            if (result.Error != null) return BadRequest(result);

            if (result.Data == null) return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Response<Tag>>> CreateTag([FromBody]CreateTagDto tagDto)
        {
            var result = await _tagService.CreateTag(tagDto);

            if (result.Data != null)   return Ok(result);

            return BadRequest(result);
        }
    }
}