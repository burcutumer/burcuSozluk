using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Data.Entities;
using API.Data.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Services
{
    public class CommentService : ICommentService
    {
        private readonly StoreContext _context;
        private readonly UserManager<User> _userManager;
        public CommentService(StoreContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Response<CommentDto>> CreateComment(string userEmail, CreateCommentDto commentDto, int entryId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return new Response<CommentDto>
                {
                    Error = "User not found"
                };
            }

            var comment = new Comment
            {
                Text = commentDto.Text,
                CreatedAt = DateTime.UtcNow,
                EntryId = entryId,
                User = user,
            };

            await _context.Comments.AddAsync(comment);
            var result = await _context.SaveChangesAsync() > 0;

            if (result)
            {
                return new Response<CommentDto>
                {
                    Data = MapToDto(comment)
                };
            }

            return new Response<CommentDto>
            {
                Error = "could not create"
            };
        }

        public async Task<PagedResponse<List<CommentDto>>> GetAllComments(int skip, int limit, int entryId)
        {
            limit = limit > 10 ? 10 : limit;

            var comments = await _context.Comments
              .Include(u => u.User)
              .Where(u => u.EntryId == entryId)
              .Select(e => MapToDto(e))
              .ToListAsync();

            var count = await _context.Comments.CountAsync();
            if (comments != null)
            {
                return new PagedResponse<List<CommentDto>>
                {
                    Data = comments,
                    Skip = skip,
                    Limit = limit,
                    Total = count
                };
            }

            return new PagedResponse<List<CommentDto>>
            {
                Error = "Comments can not be found"
            };
        }

        private static CommentDto MapToDto(Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                CreatedAt = comment.CreatedAt,
                Text = comment.Text,
                User = new UserDto{
                    Id = comment.User.Id,
                    Email = comment.User.Email!,
                    NickName = comment.User.NickName
                },
            };
        }
    }
}