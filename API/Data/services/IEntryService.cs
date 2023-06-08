using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;

namespace API.Data.services
{
    public interface IEntryService
    {
        Task<PagedResponse<List<EntryDto>>> GetAllEntries(int skip, int limit);
        Task<Response<EntryDto>> GetEntryById(int id);
        Task<bool> DeleteEntry(int id);
        Task<Response<EntryDto>> CreateEntry(string userEmail, CreateEntryDto entryDto);
    }
}