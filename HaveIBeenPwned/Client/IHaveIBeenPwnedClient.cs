using System.Collections.Generic;
using System.Threading.Tasks;
using HaveIBeenPwned.Model;

namespace HaveIBeenPwned.Client
{
    public interface IHaveIBeenPwnedClient
    {
        Task<Breach> GetBreach(string site);

        Task<List<Breach>> GetAllBreaches();

        Task<List<Breach>> GetAccountBreaches(string account, bool? includeUnverified = false);

        Task<bool> IsPasswordPwned(string password);

        Task<List<Paste>> GetPasteAccount(string account);
    }
}