using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data.services
{
    public class EntryService : IEntryService
    {
        private readonly StoreContext _context;
        private readonly UserManager<User> _userManager;
        public EntryService(StoreContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Response<EntryDto>> CreateEntry(string userEmail, CreateEntryDto entryDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return new Response<EntryDto>
                {
                    Error = "User not found"
                };
            }
            var entry = new Entry
            {
                User = user,
                UserId = user.Id,
                Description = entryDto.Description,
                Title = entryDto.Title,
                CreatedAt = DateTime.UtcNow
            };

            var entryItemList = new List<EntryItem>();
            foreach (var item in entryDto.Tags)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == item);
                if (tag == null)
                {
                    tag = new Tag
                    {
                        Name = item
                    };
                }
                entryItemList.Add(new EntryItem
                {
                    Tag = tag,
                    Entry = entry
                });
            }

            entry.EntryItems = entryItemList;
            await _context.Entries.AddAsync(entry);
            var result = await _context.SaveChangesAsync() > 0;

            if (result)
            {
                return new Response<EntryDto>
                {
                    Data = MapToDto(entry)
                };
            }
            return new Response<EntryDto>
            {
                Error = "could not create"
            };

        }

        public async Task<bool> DeleteEntry(int id)
        {
            var entry = await _context.Entries.FindAsync(id);
            if (entry != null)
            {
                _context.Entries.Remove(entry);
            }
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<PagedResponse<List<EntryDto>>> GetAllEntries(int skip, int limit)
        {
            limit = limit > 10 ? 10 : limit;

            var entries = await _context.Entries
                .Include(u => u.User)
                .Include(e => e.EntryItems)
                .ThenInclude(i => i.Tag)
                .Select(e => MapToDto(e))
                .ToListAsync();

            var count = await _context.Entries.CountAsync();

            if (entries != null)
            {
                return new PagedResponse<List<EntryDto>>
                {
                    Data = entries,
                    Skip = skip,
                    Limit = limit,
                    Total = count
                };
            }
            return new PagedResponse<List<EntryDto>>
            {
                Error = "Entries can not be found"
            };
        }

        public async Task<Response<EntryDto>> GetEntryById(int id)
        {
            var entry = await _context.Entries
                .Include(u => u.User)
                .Include(t => t.EntryItems)
                .ThenInclude(t => t.Tag)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (entry != null)
            {
                return new Response<EntryDto>
                {
                    Data = MapToDto(entry)
                };
            }
            return new Response<EntryDto>
            {
                Error = "Entry can not be found"
            };

        }

        private static EntryDto MapToDto(Entry entry)
        {
            return new EntryDto
            {
                Id = entry.Id,
                Nickname = entry.User.NickName,
                Title = entry.Title,
                Description = entry.Description,
                CreatedAt = entry.CreatedAt,
                Tags = entry.EntryItems.Select(item => new TagDto
                {
                    Id = item.Tag.Id,
                    Name = item.Tag.Name
                }).ToList()
            };
        }
    }
}