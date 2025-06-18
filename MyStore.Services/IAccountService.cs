using MyStore.Business;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace MyStore.Services
{
    public interface IAccountService
    {
        Task<AccountMember> GetAccountByIdAsync(string accountID);
        Task SaveAccountAsync(AccountMember account);
        Task UpdateAccountAsync(AccountMember account);
        Task DeleteAccountAsync(AccountMember account);
    }
}
