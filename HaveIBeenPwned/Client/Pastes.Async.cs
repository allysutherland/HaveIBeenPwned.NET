using System.Collections.Generic;
using System.Threading.Tasks;
using HaveIBeenPwned.Model;
using RestSharp;

namespace HaveIBeenPwned.Client
{
    public partial class HaveIBeenPwnedClient
    {
        private const string PASTES_RESOURCE = "pasteaccount";

        public async Task<List<Paste>> GetPasteAccount(string account)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"{PASTES_RESOURCE}/{account}";
            return await ExecuteTaskAsync<List<Paste>>(request);
        }
    }
}