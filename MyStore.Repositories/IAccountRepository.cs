using MyStore.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStore.IRepository
{
    public interface IAccountRepository
    {
        // Lấy thông tin tài khoản dựa trên ID
        Task<AccountMember> GetAccountByIdAsync(string accountID);
        
        // Lưu tài khoản mới
        Task SaveAccountAsync(AccountMember account);
        
        // Cập nhật tài khoản
        Task UpdateAccountAsync(AccountMember account);
        
        // Xóa tài khoản
        Task DeleteAccountAsync(AccountMember account);
    }
}
