using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetStoreAPICaller.Common;
using PetStoreAPICaller.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetStoreAPICaller.Helper
{
    public class APIHandler
    {

        private readonly RestClient _client;
        public APIHandler()
        {
            _client = new RestClient(PetStoreCommon.Home_Url);
        }

        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };

       

        /// <summary>
        /// Method- Creates and sets up a RestRequest for app client call
        /// </summary>
        /// <param name="path">path.</param>
        /// <param name="method">method.</param>
        /// <param name="queryParams">queryParams.</param>
        /// <param name="postBody">postBody.</param>
        /// <param name="headerParams">headerParams.</param>
        /// <param name="formParams">formParams.</param>
        /// <param name="fileParams">fileParams.</param>
        /// <param name="pathParams">pathParams</param>
        /// <param name="contentType">contentType</param>
        private RestRequest CreateAPIRequest(
            String path, RestSharp.Method method, List<KeyValuePair<String, String>> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType)
        {
            var request = new RestRequest(path, method) ;
           
            // add path parameter, if any
            foreach (var param in pathParams)
                request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);

            // add header parameter, if any
            foreach (var param in headerParams)
                request.AddHeader(param.Key, param.Value);

            // add query parameter, if any
            foreach (var param in queryParams)
                request.AddQueryParameter(param.Key, param.Value);

            

            // add form parameter, if any
            foreach (var param in formParams)
                request.AddParameter(param.Key, param.Value);

            // add file parameter, if any
            foreach (var param in fileParams)
            {
                request.AddFile(param.Value.Name, param.Value.GetFile, param.Value.FileName, param.Value.ContentType);
            }

            if (postBody != null ) // http body (model or byte[]) parameter
            {
                //request.AddBody(postBody, contentType);
                request.AddJsonBody(postBody);
            }

            request.CompletionOption = HttpCompletionOption.ResponseContentRead;
            request.RequestFormat = DataFormat.Json;
            request.Timeout = 100000;

            return request;
        }


        /// <summary>
        /// Makes the HTTP request (Sync).
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP/https method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content Type of the request</param>
        /// <returns>Object</returns>
        public IPetStoreResult CallApi(
            String path, RestSharp.Method method, List<KeyValuePair<String, String>> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType, PetStoreCommon.RequestType requestType)
        {
            var request = CreateAPIRequest(
                path, method, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, contentType);

            var response = _client.Execute(request);
  
            return GetPetStoreResult(response,requestType);
        }

        /// <summary>
        ///  the asynchronous api call request.
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content type.</param>
        /// <returns>The Task instance.</returns>
        public async Task<IPetStoreResult> CallApiAsync(
            String path, RestSharp.Method method, List<KeyValuePair<String, String>> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType, PetStoreCommon.RequestType requestType)
        {
            var request = CreateAPIRequest(
                path, method, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, contentType);
            var response = await _client.ExecuteAsync(request);
            return GetPetStoreResult(response,requestType);
        }



        private IPetStoreResult GetPetStoreResult(RestResponse response, PetStoreCommon.RequestType requestType)
        {
            IPetStoreResult? result;
            try
            {
                
                if (!response.IsSuccessful)
                {
                    if (response.Content != null && response.Content.Length>0)
                    {
                        var statusResult = System.Text.Json.JsonSerializer.Deserialize<Entity.Status>(json: response.Content,
                                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        if (response.StatusCode == System.Net.HttpStatusCode.NotFound 
                            && statusResult!=null && statusResult.Code == 1) statusResult.Code = 400;
                        if (statusResult != null)
                        {
                            result = new PetStoreResult(false, statusResult.Code,
                                            (statusResult.Message != null) ? statusResult.Message : String.Empty,
                                            (statusResult.Type != null) ? statusResult.Type : String.Empty,
                                            String.Empty);
                            return (PetStoreResult)result;
                        }
                        else return new PetStoreResult(false, 400, "Request is failed.", "error", String.Empty);
                    }
                    else return new PetStoreResult(false, 400, "Request is failed.", "error", String.Empty);

                }

                if (response.Content != null)
                {
                    if (requestType.Equals(PetStoreCommon.RequestType.USER))
                    {
                        //var statusResult = System.Text.Json.JsonSerializer.Deserialize<Entity.Status>(json: response.Content,
                        //           new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        var userDetails = System.Text.Json.JsonSerializer.Deserialize<User>(json: response.Content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        var users = new List<User>();
                        if (userDetails != null) users.Add(userDetails);

                        result = new PetStoreResult(true, Convert.ToInt32(response.StatusCode),
                                            response.ResponseStatus.ToString(), String.Empty, users);
                        return (PetStoreResult)result;


                    }
                    if (requestType.Equals(PetStoreCommon.RequestType.PET))
                    {
                        var pets = new List<Pet>();
                        try
                        {
                            var petDetails = System.Text.Json.JsonSerializer.Deserialize<List<Pet>>(json: response.Content,
                                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                            if (petDetails != null) pets = petDetails;

                        }
                        catch
                        {
                            var petDetails = System.Text.Json.JsonSerializer.Deserialize<Pet>(json: response.Content,
                                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                            if (petDetails != null) pets.Add(petDetails);
                        }
                        result = new PetStoreResult(true, Convert.ToInt32(response.StatusCode),
                                                                   response.ResponseStatus.ToString(), String.Empty, pets);
                        return (PetStoreResult)result;


                    }

                    if (requestType.Equals(PetStoreCommon.RequestType.ORDER))
                    {
                        var orderDetails = System.Text.Json.JsonSerializer.Deserialize<Order>(json: response.Content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        if (orderDetails!=null &&  orderDetails.Id > 0)
                        {
                            var orders = new List<Order>();
                            if (orderDetails != null) orders.Add(orderDetails);

                            result = new PetStoreResult(true, Convert.ToInt32(response.StatusCode),
                                            response.ResponseStatus.ToString(), String.Empty, orders);
                            return (PetStoreResult)result;

                        }
                        else
                        {
                            object inventory = response.Content;
                            result = new PetStoreResult(true, Convert.ToInt32(response.StatusCode),
                                           response.ResponseStatus.ToString(), String.Empty, inventory) ;
                            return (PetStoreResult)result;

                        }

                       

                       

                    }
                    return new PetStoreResult(false, 404, "Data not found.", "error",
                       (response.StatusDescription != null) ? response.StatusDescription.ToString() : String.Empty);



                }
                else return new PetStoreResult(false, 404, "User not found.", "error",
                        (response.StatusDescription != null) ? response.StatusDescription.ToString() : String.Empty);


            }
            catch (Exception exp)
            {

                throw new Exception("Error Code 500 : Response is null.", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }





    }
}
