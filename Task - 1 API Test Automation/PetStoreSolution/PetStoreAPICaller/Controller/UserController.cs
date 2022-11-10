using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetStoreAPICaller.Common;
using PetStoreAPICaller.Entity;
using PetStoreAPICaller.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PetStoreAPICaller.Controller
{

    /// <summary> 
    /// Class-UserController
    /// Controller class to hansle  api calls and handle  request/responses .
    /// </summary> 
    /// <remarks> 
    /// Mainly crate, create as list,creatre as  array,update user and delete user functinalities 
    ///and returned server responses to clint
    /// </remarks> 
    public class UserController
    {
        // main handler instance
        private APIHandler _apiHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// Mainly initialise  APIHandler class instance
        /// </summary>
        public UserController()
        {
            _apiHandler = new APIHandler();
        }


        /// <summary> 
        /// CreateUsersByArray-This  method will create users given by array and return
        /// output response.
        /// </summary> 
        /// <param name="users">array of user object</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult CreateUsersByArray(User[] users,string path)
        {
            IPetStoreResult? result;
            try
            {
                if (_apiHandler==null) _apiHandler = new APIHandler();

                // string path = PetStoreCommon.User_Url+ $"createWithArray";
                //  string contentType = "application/json";
                result = _apiHandler.CallApi(path,
                                             RestSharp.Method.Post,
                                             new List<KeyValuePair<String, String>>(),
                                             JsonConvert.SerializeObject(users),
                                             PetStoreCommon.Default_HeaderParams,
                                             new Dictionary<string, string>(),
                                             new Dictionary<string, FileParameter>(),
                                             new Dictionary<string, string>(),
                                             PetStoreCommon.Header_DefaultContentType,
                                             PetStoreCommon.RequestType.USER);


                //result = _apiHandler.CallApi(path, RestSharp.Method.Post, new List<KeyValuePair<String, String>>()
                //            , JsonConvert.SerializeObject(users),
                //            new Dictionary<string, string>(),new Dictionary<string, string>(), 
                //            new Dictionary<string, FileParameter>(),new Dictionary<string, string>(),
                //            contentType, PetStoreCommon.RequestType.USER);

                return result;

            }
            catch(Exception exp)
            {
                throw new Exception("Error:While creating user/s ", exp.InnerException);
            }
            finally
            {
                result = null;
            }
            
        }


        /// <summary> 
        /// CreateUsersByList-This  method will create users given by list and return
        /// output response.
        /// </summary> 
        /// <param name="users">list of user object</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult CreateUsersByList(List<User> users, string path)
        {
            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                // string path = PetStoreCommon.User_Url + $"createWithList";
                // string contentType = "application/json";

                result = _apiHandler.CallApi(path,
                                             RestSharp.Method.Post,
                                             new List<KeyValuePair<String, String>>(),
                                             JsonConvert.SerializeObject(users),
                                             PetStoreCommon.Default_HeaderParams,
                                             new Dictionary<string, string>(),
                                             new Dictionary<string, FileParameter>(),
                                             new Dictionary<string, string>(),
                                             PetStoreCommon.Header_DefaultContentType,
                                             PetStoreCommon.RequestType.USER);

                //result = _apiHandler.CallApi(path, RestSharp.Method.Post, new List<KeyValuePair<String, String>>()
                //            , JsonConvert.SerializeObject(users),
                //            new Dictionary<string, string>(), new Dictionary<string, string>(),
                //            new Dictionary<string, FileParameter>(), new Dictionary<string, string>(),
                //            contentType, PetStoreCommon.RequestType.USER);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:While creating user/s ", exp.InnerException);
            }
            finally
            {
                result = null;
            }
        }


        /// <summary> 
        /// GetUserByName-This  method will get user details for  the given username
        /// </summary> 
        /// <param name="username">username which will used to get user details</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult GetUserByName(string username, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                // string path = PetStoreCommon.User_Url+username;
                // string contentType = "application/json";
                path= path+"/"+username;


                result = _apiHandler.CallApi(path,
                                             RestSharp.Method.Get,
                                             new List<KeyValuePair<String, String>>(),
                                            new List<KeyValuePair<String, String>>(),
                                             PetStoreCommon.Default_HeaderParams,
                                             new Dictionary<string, string>(),
                                             new Dictionary<string, FileParameter>(),
                                             new Dictionary<string, string>(),
                                             PetStoreCommon.Header_DefaultContentType,
                                             PetStoreCommon.RequestType.USER);




                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Retrieving data(user/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// CreateUser-This  method will create new user by using  given api
        /// </summary> 
        /// <param name="user">new user object with user details</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult CreateUser(User user, string path)
        {
            
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                //string path = $"user";
               // string contentType = "application/json";

               // var headerParams = new Dictionary<String, String>();
               // headerParams.Add("Accept", "application/json");
               // headerParams.Add("Content-Type", "application/json");
               // headerParams.Add("authority", "petstore.swagger.io");
              
                
                var result = _apiHandler.CallApi(path, 
                                             RestSharp.Method.Post, 
                                             new List<KeyValuePair<String, String>>(),
                                             user.ToJson(),
                                             PetStoreCommon.Default_HeaderParams, 
                                             new Dictionary<string, string>(),
                                             new Dictionary<string, FileParameter>(), 
                                             new Dictionary<string, string>(),
                                             PetStoreCommon.Header_DefaultContentType, 
                                             PetStoreCommon.RequestType.USER);

                return (IPetStoreResult)result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:User creating process is failed  ", exp.InnerException);
            }
           

        }



        /// <summary> 
        /// UpdateUser-This  method will selected update user 
        /// </summary> 
        /// <param name="username"> username of the user who has to be updated</param>
        /// <param name="user">user object with user details</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult UpdateUser(string username, string path,User user)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                path = path +"/"+ username;
               // string contentType = "application/json";

                result = _apiHandler.CallApi(path,
                                           RestSharp.Method.Put,
                                           new List<KeyValuePair<String, String>>(),
                                          JsonConvert.SerializeObject(user),
                                           PetStoreCommon.Default_HeaderParams,
                                           new Dictionary<string, string>(),
                                           new Dictionary<string, FileParameter>(),
                                           new Dictionary<string, string>(),
                                           PetStoreCommon.Header_DefaultContentType,
                                           PetStoreCommon.RequestType.USER);


                //result = _apiHandler.CallApi(path, RestSharp.Method.Put, new List<KeyValuePair<String, String>>(),
                //            JsonConvert.SerializeObject(user),
                //            new Dictionary<string, string>(), new Dictionary<string, string>(),
                //            new Dictionary<string, FileParameter>(), new Dictionary<string, string>(),
                //            contentType, PetStoreCommon.RequestType.USER);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Updating data(user/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }

        /// <summary> 
        /// DeleteUser-This  method will selected update user 
        /// </summary> 
        /// <param name="username"> username of the user who has to be deleted</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>

        [System.Web.Http.HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult DeleteUser(string username, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

               path = path + "/" + username;
               // string contentType = "application/json";

                result = _apiHandler.CallApi(path,
                           RestSharp.Method.Delete,
                           new List<KeyValuePair<String, String>>(),
                           new List<KeyValuePair<String, String>>(),
                           PetStoreCommon.Default_HeaderParams,
                           new Dictionary<string, string>(),
                           new Dictionary<string, FileParameter>(),
                           new Dictionary<string, string>(),
                           PetStoreCommon.Header_DefaultContentType,
                           PetStoreCommon.RequestType.USER);


                //result = _apiHandler.CallApi(path, RestSharp.Method.Delete, new List<KeyValuePair<String, String>>(),
                //            new List<KeyValuePair<String, String>>(),
                //            new Dictionary<string, string>(), new Dictionary<string, string>(),
                //            new Dictionary<string, FileParameter>(), new Dictionary<string, string>(),
                //            contentType, PetStoreCommon.RequestType.USER);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Deleting given user is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }

        /// <summary> 
        /// LoginUser-This  method will let user to login to the system 
        /// </summary> 
        /// <param name="username"> username of the user who wants to login</param>
        /// <param name="password"> passows of the user</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult LoginUser(string username,string password,string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                //path = path + $"login";
                //string contentType = "application/json";

                List<KeyValuePair<String, String>> queryParam = new List<KeyValuePair<string, string>>();
                queryParam.Add(new KeyValuePair<string,string>("username", username));
                queryParam.Add(new KeyValuePair<string, string>("password", password));

                result = _apiHandler.CallApi(path,
                          RestSharp.Method.Get,
                          queryParam,
                          new List<KeyValuePair<String, String>>(),
                          PetStoreCommon.Default_HeaderParams,
                          new Dictionary<string, string>(),
                          new Dictionary<string, FileParameter>(),
                          new Dictionary<string, string>(),
                          PetStoreCommon.Header_DefaultContentType,
                          PetStoreCommon.RequestType.USER);


                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:login proces is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// LogoutUser-This  method will let user to logout from the system 
        /// </summary> 
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult LogoutUser(string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

               // path = path + $"logout";
               // string contentType = "application/json";

                result = _apiHandler.CallApi(path,
                         RestSharp.Method.Get,
                         new List<KeyValuePair<String, String>>(),
                         new List<KeyValuePair<String, String>>(),
                         PetStoreCommon.Default_HeaderParams,
                         new Dictionary<string, string>(),
                         new Dictionary<string, FileParameter>(),
                         new Dictionary<string, string>(),
                         PetStoreCommon.Header_DefaultContentType,
                         PetStoreCommon.RequestType.USER);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:logout proces is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


    }
}
