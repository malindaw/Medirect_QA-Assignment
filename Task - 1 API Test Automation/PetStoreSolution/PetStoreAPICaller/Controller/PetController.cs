using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetStoreAPICaller.Common;
using PetStoreAPICaller.Entity;
using PetStoreAPICaller.Helper;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace PetStoreAPICaller.Controller
{

    /// <summary> 
    /// Class-PetController
    /// Controller class to handle  pet related api calls and handle  request/responses .
    /// </summary> 
    /// <remarks> 
    /// Mainly crate,update pet and delete pet functinalities 
    ///and returned server responses to clint
    /// </remarks> 
    public class PetController
    {
        // main handler instance
        private APIHandler _apiHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetController" /> class.
        /// Mainly initialise  APIHandler class instance
        /// </summary>
        public PetController()
        {
            _apiHandler = new APIHandler();
        }


        /// <summary> 
        /// UploadPetImage-This  method will upload image file for  given pet 
        /// </summary> 
        /// <param name="file"> file/byte array obejct as parameter</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult UploadPetImage(FileParameter file,string path)
        {
            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                var fileParam = new Dictionary<string, FileParameter>();
                fileParam.Add("file", file);

                // string path = PetStoreCommon.Pet_Url;
                // string contentType = "application/json";
                result = _apiHandler.CallApi(path,
                                RestSharp.Method.Post,
                                new List<KeyValuePair<String, String>>(),
                                new Dictionary<string, string>(),
                                PetStoreCommon.Default_HeaderParams,
                                new Dictionary<string, string>(),
                                fileParam,
                                new Dictionary<string, string>(),
                                PetStoreCommon.Header_DefaultContentType,
                                PetStoreCommon.RequestType.PET);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Updating data(pet/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// CreatePet-This  method will add new pet to the system 
        /// </summary> 
        /// <param name="pet"> new pet object which need to be created</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult CreatePet(Pet pet,string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

      

               result = _apiHandler.CallApi(path,
                                RestSharp.Method.Post,
                                new List<KeyValuePair<String, String>>(),
                                pet.ToJson().ToLower(),
                                PetStoreCommon.Default_HeaderParams,
                                new Dictionary<string, string>(),
                                new Dictionary<string,FileParameter>(),
                                new Dictionary<string, string>(),
                                PetStoreCommon.Header_DefaultContentType,
                                PetStoreCommon.RequestType.PET);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Updating data(pet/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// UpdatePet-This  method will update the given pet 
        /// </summary> 
        /// <param name="pet"> pet object which contained updated properties</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult UpdatePet(Pet pet, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

               // path = path +"/"+ pet.Id;
               // string contentType = "application/json";

                result = _apiHandler.CallApi(path,
                                RestSharp.Method.Put,
                                new List<KeyValuePair<String, String>>(),
                                pet.ToJson(),
                                PetStoreCommon.Default_HeaderParams,
                                new Dictionary<string, string>(),
                                new Dictionary<string, FileParameter>(),
                                new Dictionary<string, string>(),
                                PetStoreCommon.Header_DefaultContentType,
                                PetStoreCommon.RequestType.PET);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Updating data(pet/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// UpdatePetFormData-This  method will update the given pet using form data 
        /// </summary> 
        /// <param name="petId"> id of the pet</param>
        /// <param name="name"> name of the pet</param>
        /// <param name="status"> status of the pet</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult UpdatePetFormData(long petId,string name,string status, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                path = path + petId;
               // string contentType = "application/json";
                List<KeyValuePair<String, String>> queryParam = new List<KeyValuePair<String, String>>();
                queryParam.Add(new KeyValuePair<string, string>("name", name));
                queryParam.Add(new KeyValuePair<string, string>("status", status));

                result = _apiHandler.CallApi(path,
                               RestSharp.Method.Post,
                               queryParam,
                               new Dictionary<string, string>(),
                               PetStoreCommon.Default_HeaderParams,
                               new Dictionary<string, string>(),
                               new Dictionary<string, FileParameter>(),
                               new Dictionary<string, string>(),
                               PetStoreCommon.Header_DefaultContentType,
                               PetStoreCommon.RequestType.PET);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Updating data(pet/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// FindPetById-This  method will find pet/s using given id 
        /// </summary> 
        /// <param name="petId"> pet id to besearched</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult FindPetById(long petId, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                path = path+"/"+petId.ToString();
                //string contentType = "application/json";

                result = _apiHandler.CallApi(path,
                               RestSharp.Method.Get,
                               new List<KeyValuePair<String, String>>(),
                               new Dictionary<string, string>(),
                               PetStoreCommon.Default_HeaderParams,
                               new Dictionary<string, string>(),
                               new Dictionary<string, FileParameter>(),
                               new Dictionary<string, string>(),
                               PetStoreCommon.Header_DefaultContentType,
                               PetStoreCommon.RequestType.PET);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Retrieving data(pet/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }

        /// <summary> 
        /// FindPetByStatus-This  method will find pet/s using given status 
        /// </summary> 
        /// <param name="status"> pet status to be searched</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult FindPetByStatus(string status, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                //path = path + ;
               // string contentType = "application/json";

                List<KeyValuePair<String, String>> queryParam =new  List<KeyValuePair<String, String>>();
                queryParam.Add(new KeyValuePair<string, string>("status", status));

                result = _apiHandler.CallApi(path,
                               RestSharp.Method.Get,
                               queryParam,
                               new Dictionary<string, string>(),
                               PetStoreCommon.Default_HeaderParams,
                               new Dictionary<string, string>(),
                               new Dictionary<string, FileParameter>(),
                               new Dictionary<string, string>(),
                               PetStoreCommon.Header_DefaultContentType,
                               PetStoreCommon.RequestType.PET);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Retrieving data(pet/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// DeletePet-This  method will delete given pet 
        /// </summary> 
        /// <param name="petId"> pet id to be deleted </param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult DeletePet(long petId, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                path = path + "/" + petId;
                //string contentType = "application/json";

                result = _apiHandler.CallApi(path,
                        RestSharp.Method.Get,
                        new List<KeyValuePair<String, String>>(),
                        new Dictionary<string, string>(),
                        PetStoreCommon.Default_HeaderParams,
                        new Dictionary<string, string>(),
                        new Dictionary<string, FileParameter>(),
                        new Dictionary<string, string>(),
                        PetStoreCommon.Header_DefaultContentType,
                        PetStoreCommon.RequestType.PET);


                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Deleting given pet is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }



    }
}