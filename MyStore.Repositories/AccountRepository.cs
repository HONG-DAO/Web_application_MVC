using MyStore.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Business;
using System.Linq;

namespace MyStore.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyStoreDbContext _context;

        public AccountRepository(MyStoreDbContext context)
        {
            _context = context;
        }

        // Lấy tài khoản theo ID
        public async Task<AccountMember> GetAccountByIdAsync(string accountID)
        {
            try
            {
                return await _context.AccountMembers
                    .FirstOrDefaultAsync(c => c.MemberId.Equals(accountID));
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
                _context.AccountMembers.Add(account);
                await _context.SaveChangesAsync();
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
                _context.Entry(account).State = EntityState.Modified;
                await _context.SaveChangesAsync();
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
                _context.AccountMembers.Remove(account);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while deleting the account: {e.Message}");
            }
        }
    }
}
