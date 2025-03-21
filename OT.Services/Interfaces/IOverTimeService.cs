using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OT.Core.Dto;
using OT.Core.Entities;

namespace OT.Services.Interfaces
{
    public interface IOverTimeService
    {
        Task<List<string>> GetLines(string mst, string phongban, string macongty);

        Task<(IEnumerable<OverTime> data, int totalPages)> GetOverTimeWithTotal(DateOnly date, string macongty, int page, int size, int filter, List<string> lines, string searchMST);
    
        Task<(int status, string message)> UpdateHrByID(int id, string? status);

        Task<(int status, string message)> UpdateOTTime(int id, string timeString, string column);

        Task ExportExcel(DateOnly date, string macongty, List<string> lines);

        Task<(int status, string message)> ImportOT(List<OverTime> listOvertime);
        
        Task<(int status, string message)> ImportOTByHR(List<DOT_HR> listHR);

        Task<(int status, string message)> AcceptAllStatusOT(DateOnly date, string macongty, string? status, List<string>? lines);
    }
}
