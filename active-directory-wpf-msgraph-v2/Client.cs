using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace active_directory_wpf_msgraph_v2
{
    public class Client
    {
        public string AccessToken { get; set; }  

        public Client(string accessToken)
        {
            AccessToken = accessToken;
        }

        #region MoneyHolder


        public async Task<bool> UploadFile(string url, string fullFileName)
        {
            var client = new HttpClient();
           
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + AccessToken);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/octet-stream");
            var content = File.ReadAllBytes(fullFileName);

            var response = await client.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new ByteArrayContent(content)
            });

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("response: {0}", responseContent);
            return false;
        }

        //public async Task<GetTransactionOutputDto> GetTransactionList(string type)
        //{
        //    var loginResponse = await Login();
        //    var client = new HttpClient();

        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + loginResponse.access_token);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("x-account-holder-id", HolderAccountId);

        //    var response = await client.SendAsync(new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri(BaseUrl + $"/transactions?type={type}")
        //    });

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        var httpResponse = JsonConvert.DeserializeObject<GetTransactionOutputDto>(await response.Content.ReadAsStringAsync());
        //        return httpResponse;
        //    }
        //}

        //public async Task CreateOpenPaydWebhook(CreateWebHookInputDto request)
        //{
        //    var loginResponse = await Login();
        //    var client = new HttpClient();

        //    var requestJson = JsonConvert.SerializeObject(request);
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + loginResponse.access_token);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("x-account-holder-id", HolderAccountId);

        //    var response = await client.SendAsync(new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(BaseUrl + "/webhooks"),
        //        Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        //    });

        //    if (!response.IsSuccessStatusCode)
        //    {}
        //}

        //public async Task<CreateInitialTransferOutputDto> CreateInternalTransfer(CreateInitialTransferInputDto request)
        //{
        //    var loginResponse = await Login();
        //    var client = new HttpClient();

        //    var requestJson = JsonConvert.SerializeObject(request);
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + loginResponse.access_token);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("x-account-holder-id", HolderAccountId);

        //    var response = await client.SendAsync(new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(BaseUrl + "/transactions"),
        //        Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        //    });

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        var error =  JsonConvert.DeserializeObject<InitialTransferError>(await response.Content.ReadAsStringAsync());
        //        return new CreateInitialTransferOutputDto { 
        //            FailureReason = error.ErrorCode                    
        //        };
        //    }

        //    var httpResponse = JsonConvert.DeserializeObject<CreateInitialTransferOutputDto>(await response.Content.ReadAsStringAsync());

        //    return httpResponse;
        //}

        //public async Task<CreateBeneficiaryPayoutOutputDto> CreateBeneficiaryPayout(CreateBeneficiaryPayoutInputDto request)
        //{
        //    var loginResponse = await Login();
        //    var client = new HttpClient();

        //    var requestJson = JsonConvert.SerializeObject(request);
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + loginResponse.access_token);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("x-account-holder-id", HolderAccountId);

        //    var response = await client.SendAsync(new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(BaseUrl + "/transactions/beneficiaryPayout"),
        //        Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        //    });

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new BaseAPIResponseException(1036, await response.Content.ReadAsStringAsync());
        //    }

        //    var httpResponse = JsonConvert.DeserializeObject<CreateBeneficiaryPayoutOutputDto>(await response.Content.ReadAsStringAsync());

        //    return httpResponse;
        //}

        //public async Task<CreateBeneficiaryOutputDto> CreateBeneficiary(CreateBeneficiaryInputDto request)
        //{
        //    var loginResponse = await Login();
        //    var client = new HttpClient();

        //    var requestJson = JsonConvert.SerializeObject(request);
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + loginResponse.access_token);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("x-account-holder-id", HolderAccountId);

        //    var response = await client.SendAsync(new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(BaseUrl + "/beneficiaries"),
        //        Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        //    });

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new BaseAPIResponseException(1036, await response.Content.ReadAsStringAsync());
        //    }

        //    var httpResponse = JsonConvert.DeserializeObject<CreateBeneficiaryOutputDto>(await response.Content.ReadAsStringAsync());

        //    return httpResponse;
        //}

        //public async Task<CreateAccountOutputDto> CreateAccount(CreateAccountInputDto request)
        //{
        //    var loginResponse = await Login();
        //    var client = new HttpClient();

        //    var requestJson = JsonConvert.SerializeObject(request);
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + loginResponse.access_token);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("x-account-holder-id", HolderAccountId);

        //    var response = await client.SendAsync(new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(BaseUrl + "/accounts"),
        //        Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        //    });

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new BaseAPIResponseException(1036, await response.Content.ReadAsStringAsync());
        //    }

        //    var httpResponse = JsonConvert.DeserializeObject<CreateAccountOutputDto>(await response.Content.ReadAsStringAsync());

        //    return httpResponse;
        //}

        //public async Task<GetAccountOutputDto> GetAccountAsync(string accountId)
        //{
        //    var loginResponse = await Login();
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + loginResponse.access_token);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("x-account-holder-id", HolderAccountId);

        //    var response = await client.SendAsync(new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri(BaseUrl + $"/accounts/{accountId}")
        //    });

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return null;
        //        //throw new BaseAPIResponseException(1036, await response.Content.ReadAsStringAsync());
        //    }

        //    var httpResponse = JsonConvert.DeserializeObject<GetAccountOutputDto>(await response.Content.ReadAsStringAsync());

        //    return httpResponse;
        //}

        //public async Task<GetAccountsOutputDto> GetAccountsAsync()
        //{
        //    var loginResponse = await Login();
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + loginResponse.access_token);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("x-account-holder-id", HolderAccountId);

        //    var response = await client.SendAsync(new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri(BaseUrl + $"/accounts")
        //    });

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new BaseAPIResponseException(1036, await response.Content.ReadAsStringAsync());
        //    }

        //    var httpResponse = JsonConvert.DeserializeObject<GetAccountsOutputDto>(await response.Content.ReadAsStringAsync());

        //    return httpResponse;
        //}

        //public async Task<Object> CreateBankBeneficiary(Guid parentBeneficiaryId, OpenPayd.Entity.Request.BankBeneficiary request)
        //{
        //    var loginResponse = await Login();
        //    var client = new HttpClient();

        //    //var setting = new JsonSerializerSettings()
        //    //{
        //    //    NullValueHandling = NullValueHandling.Ignore
        //    //};
        //    var requestJson = JsonConvert.SerializeObject(request); //, setting
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + loginResponse.access_token);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("x-account-holder-id", HolderAccountId);
        //    var url = BaseUrl + $"/beneficiaries/{parentBeneficiaryId}/bank-beneficiaries";
        //    var response = await client.SendAsync(new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(url),
        //        Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        //    });

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new BaseAPIResponseException(1036, await response.Content.ReadAsStringAsync());
        //    }

        //    var httpResponse = JsonConvert.DeserializeObject<object>(await response.Content.ReadAsStringAsync());

        //    return httpResponse;
        //}
        
        #endregion
    }
}
