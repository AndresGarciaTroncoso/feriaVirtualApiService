using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FrutosMaipo.Feria.Service.Config;
using FrutosMaipo.Feria.Service.Infrastructure.Interfaces;
using FrutosMaipo.Feria.Service.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Net;
using Microsoft.Extensions.Logging;
using System.IO;

namespace FrutosMaipo.Feria.Service.Services
{
    public class AuthUserManagementService : IAuthUserManangementServices
    {
        private readonly HttpClient _httpClient;
        private readonly Auth0ManagementApiConfig _auth0ManagementApiConfig;
        private readonly ILogger<AuthUserManagementService> _logger;
        private static Stopwatch _timer;
        private readonly PasswordHistory _passwordHistory;

        public AuthUserManagementService(HttpClient httpClient, IOptions<Auth0ManagementApiConfig> auth0ManagementApiConfig,
            ILogger<AuthUserManagementService> logger, IOptions<PasswordHistory> passwordHistory)
        {
            _httpClient = httpClient;
            _auth0ManagementApiConfig = auth0ManagementApiConfig.Value;
            _logger = logger;
            _passwordHistory = passwordHistory.Value;
        }

        private async Task<bool> CreateUser(Auth0UserModel createUser, ManagementApiResultModel responseToken)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string parameters = JsonConvert.SerializeObject(new
                {
                    user_id = "",
                    connection = _auth0ManagementApiConfig.Connection,
                    email = createUser.Email,
                    username = createUser.Username,
                    password = _auth0ManagementApiConfig.TemporaryPass,
                    user_metadata = new object { },
                    email_verified = true,
                    verify_email = true,
                    app_metadata = new object { },
                });

                var content = new StringContent(parameters, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", responseToken.AccessToken);
                response = await _httpClient.PostAsync(new Uri(_auth0ManagementApiConfig.Auth0Domain + _auth0ManagementApiConfig.CreateUserEndpoint), content);
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.Conflict)
                {
                    //
                }
                else
                {
                    if (response.StatusCode.Equals(HttpStatusCode.BadRequest))
                    {
                        _logger.LogInformation(string.Format("** Error auth0. Usuario {0} no creado | Detalle: {1} **", createUser.Username, await response.Content.ReadAsStringAsync()));
                        _logger.LogError(string.Format("** Error auth0. Usuario {0} no creado | Detalle: {1} **", createUser.Username, await response.Content.ReadAsStringAsync()));
                    }
                }
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception= " + ex + " Message= " + ex.Message);
            }
            return response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.Conflict;
        }

        public async Task<bool> CreateUser(Auth0UserModel UserAdd)
        {
            ManagementApiResultModel responseToken = await GetAccessToken();
            return await CreateUser(UserAdd, responseToken);
        }
        private async Task<ManagementApiResultModel> GetAccessToken()
        {
            ManagementApiResultModel responseToken = null;
            try
            {
                HttpResponseMessage response;
                string parameters = JsonConvert.SerializeObject(new
                {
                    client_id = _auth0ManagementApiConfig.ClientId,
                    client_secret = _auth0ManagementApiConfig.ClientSecret,
                    audience = _auth0ManagementApiConfig.Audience,
                    grant_type = "client_credentials"
                });

                StringContent content = new StringContent(parameters, Encoding.UTF8, "application/json");

                response = await _httpClient.PostAsync(_auth0ManagementApiConfig.Auth0Domain + _auth0ManagementApiConfig.TokenEndpoint, content);
                responseToken = response.Content.ReadAsAsync<ManagementApiResultModel>().Result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception= " + ex + " Message= " + ex.Message);
            }
            return responseToken;
        }
    }
}
