using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetStoreAPICaller.Common;
using PetStoreAPICaller.Entity;
using PetStoreAPICaller.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPICaller.Controller
{

    /// <summary> 
    /// Class-StoreController
    /// Controller class to handle  order related api calls and handle  request/responses .
    /// </summary> 
    /// <remarks> 
    /// Mainly crate, ,update order and delete order functinalities 
    ///and returned server responses to clint
    /// </remarks> 
    public class StoreController
    {
        // main handler instance
        private APIHandler _apiHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreController" /> class.
        /// Mainly initialise  APIHandler class instance
        /// </summary>
        public StoreController()
        {
            _apiHandler = new APIHandler();
        }


        /// <summary> 
        /// PlaceOrder-This  method will create new order 
        /// </summary> 
        /// <param name="order"> details of new order object</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult PlaceOrder(Order order, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                //string path = PetStoreCommon.Store_Url + $"order";
                //string contentType = "application/json";

                result = _apiHandler.CallApi(path,
                                             RestSharp.Method.Post,
                                             new List<KeyValuePair<String, String>>(),
                                             order.ToJson(),
                                             PetStoreCommon.Default_HeaderParams,
                                             new Dictionary<string, string>(),
                                             new Dictionary<string, FileParameter>(),
                                             new Dictionary<string, string>(),
                                             PetStoreCommon.Header_DefaultContentType,
                                             PetStoreCommon.RequestType.ORDER);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Order creating process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// FindOrderById-This  method will find the order for given id
        /// </summary> 
        /// <param name="orderId"> id oforder object</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult FindOrderById(long orderId, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                path = path +"/"+ orderId;
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
                                             PetStoreCommon.RequestType.ORDER);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Retrieving data(order/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// DeleteOrder-This  method will delete the given order 
        /// </summary> 
        /// <param name="orderId"> id of order object</param>
        /// <param name="path">api path to be called</param>
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult DeleteOrder(long orderId, string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                path = path +"/"+ orderId;
               
                result = _apiHandler.CallApi(path,
                                             RestSharp.Method.Delete,
                                             new List<KeyValuePair<String, String>>(),
                                             new Dictionary<string, string>(),
                                             PetStoreCommon.Default_HeaderParams,
                                             new Dictionary<string, string>(),
                                             new Dictionary<string, FileParameter>(),
                                             new Dictionary<string, string>(),
                                             PetStoreCommon.Header_DefaultContentType,
                                             PetStoreCommon.RequestType.ORDER);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Deleting given order is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


        /// <summary> 
        /// GetInventory-This  method will return order inventory 
        /// </summary> 
        /// <returns> 
        /// IPetStoreResult - response converted to a readable  object
        /// </returns>
        [System.Web.Http.HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IPetStoreResult GetInventory(string path)
        {

            IPetStoreResult? result;
            try
            {
                if (_apiHandler == null) _apiHandler = new APIHandler();

                result = _apiHandler.CallApi(path,
                                             RestSharp.Method.Get,
                                             new List<KeyValuePair<String, String>>(),
                                             new Dictionary<string, string>() {{ string.Empty, string.Empty }},
                                             PetStoreCommon.Default_HeaderParams,
                                             new Dictionary<string, string>(),
                                             new Dictionary<string, FileParameter>(),
                                             new Dictionary<string, string>(),
                                             PetStoreCommon.Header_DefaultContentType,
                                             PetStoreCommon.RequestType.ORDER);

                return result;

            }
            catch (Exception exp)
            {
                throw new Exception("Error:Retrieving data(order/s) process is failed  ", exp.InnerException);
            }
            finally
            {
                result = null;
            }

        }


    }
}
