namespace API_Azure_KeyValue.Repositories
{
    public interface IKeyVaultStoreManager
    {
        public Task<string> GetVaultSecret(string secretName);
    }
}
