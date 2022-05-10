using System.Text.Json;

namespace ApiCertificateAuthClient
{
    public interface IClientHttpService
    { 
        Task<JsonDocument> GetAsync();
    }
}
