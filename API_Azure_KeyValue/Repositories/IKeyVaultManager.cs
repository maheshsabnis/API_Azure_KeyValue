namespace API_Azure_KeyValue.Repositories
{
    public interface IKeyVaultManager
    {
        public Task<string> GetSecret(string secretName);
    }
}
