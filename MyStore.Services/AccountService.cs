using MyStore.Business;
using MyStore.IRepository;
using System.Threading.Tasks;
using MyStore.IRepository;
namespace MyStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // Lấy thông tin tài khoản theo ID
        public async Task<AccountMember> GetAccountByIdAsync(string accountID)
        {
            try
            {
                return await _accountRepository.GetAccountByIdAsync(accountID);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while retrieving the account: {e.Message}");
            }
        }

        // Lưu tài khoản mới
        public async Task SaveAccountAsync(AccountMember account)
        {
            try
            {
                await _accountRepository.SaveAccountAsync(account);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while saving the account: {e.Message}");
            }
        }

        // Cập nhật tài khoản
        public async Task UpdateAccountAsync(AccountMember account)
        {
            try
            {
                await _accountRepository.UpdateAccountAsync(account);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while updating the account: {e.Message}");
            }
        }

        // Xóa tài khoản
        public async Task DeleteAccountAsync(AccountMember account)
        {
            try
            {
                await _accountRepository.DeleteAccountAsync(account);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while deleting the account: {e.Message}");
            }
        }
    }
}
