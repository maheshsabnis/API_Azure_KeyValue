using Azure.Security.KeyVault.Secrets;

namespace API_Azure_KeyValue.Repositories
{
    public class KeyVaultStoreManager : IKeyVaultStoreManager
    {
        private readonly SecretClient _secretClient;
        public KeyVaultStoreManager(SecretClient secretClient)
        {
            _secretClient = secretClient;
        }
        public async Task<string> GetVaultSecret(string secretName)
        {
            try
            {
                KeyVaultSecret keyValueSecret = await
                _secretClient.GetSecretAsync(secretName);
                return keyValueSecret.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
