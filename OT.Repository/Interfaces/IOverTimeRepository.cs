using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OT.Core.Dto;
using OT.Core.Entities;

namespace OT.Repositories.Interfaces
{
    public interface IOverTimeRepository
    {
        Task<List<string>> GetLines(string mst, string phongban, string macongty);

        Task<IEnumerable<OverTime>> GetOverTime(DateOnly date, string macongty, List<string>? lines);

        Task<(IEnumerable<OverTime> data, int totalPages)> GetOverTimeWithTotal(DateOnly date, string macongty, int page, int size, int filter, List<string>? lines, string? searchMST);

        Task<(int status, string message)> UpdateHRByID(int id, string? status);

        Task<(int status, string message)> UpdateOTTime(int id, TimeSpan? time, string column);

        Task<(int status, string message)> ImportOT(List<OverTime> listOvertime);

        Task<(int status, string message)> ImportOTByHR(List<DOT_HR> listHR);

        Task<(int status, string message)> AcceptAllStatusOT(DateOnly date, string macongty, string? status, List<string>? lines);
    }
}
