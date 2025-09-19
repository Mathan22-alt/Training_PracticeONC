using System;
using System.Threading.Tasks;
using NewBankingProject_1.Models.Dtos;

namespace NewBankingProject_1.Services
{
    public interface IStatementService
    {
        Task<AccountStatementDto> GetStatementAsync(int accountId, DateTime startDate, DateTime endDate);
        Task<byte[]> GenerateExcelAsync(int accountId, DateTime startDate, DateTime endDate);
        Task<byte[]> GeneratePdfAsync(int accountId, DateTime startDate, DateTime endDate);
    }
}
