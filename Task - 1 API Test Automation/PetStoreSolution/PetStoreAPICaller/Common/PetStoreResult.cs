using PetStoreAPICaller.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPICaller.Common
{
    public class PetStoreResult : IPetStoreResult
    {
        private bool _isSuccessful;
        private int _errorCode;
        private string? _errorMessage;
        private string? _errorType;
        private string? _exception;
        private List<User>? _userList;
        private List<Pet>? _petList;
        private List<Order>? _orderList;
        private string? _inventoryJson;

        /// <summary> 
        /// Main constructor of PetStoreResult  class. This is object  always return to client  callers.
        /// </summary> 
        /// <param name="successful">indicate whether api call is completed ot not</param>
        /// <param name="ecode">indicate status code returned from api</param>
        /// <param name="eMessage">indicate status description returned from api</param>
        /// <param name="errException">indicate inner exception which returned from api</param>
        /// <param name="errType">indicate error type which returned from api</param>
        /// <param name="users">returned user information (zero or more)</param>
        /// <param name="pets">returned pets information (zero or more)</param>  
        /// <param name="orders">returned order information (zero or more)</param>
        /// <param name="inventory">returned inventory information (zero or more)</param>
        /// <value> 
        /// _isSuccessful : initialize api call status. 
        /// _errorCode : returned error/status code. 
        /// _errorMessage : returned error/status description.
        /// _exception: returned innner exception if any
        /// _errorType : returned error type where is it error or warning.
        /// _userList: returned zero or more users from the api call(if any)
        /// _petList: returned zero or more pets from the api call(if any)
        /// _orderList: returned zero or more orders from the api call(if any)
        /// _inventoryJson: returned zero or more inventories as a jsonstring from the api call(if any)
        /// </value> 
        public PetStoreResult(bool successful, 
                              int ecode, 
                              string eMessage, 
                              string  errException,
                              string errType,
                              List<User> users,
                              List<Pet> pets,
                              List<Order> orders,
                              string inventory)
        {
            _isSuccessful = successful;
            _errorCode = ecode;
            _errorMessage = eMessage;
            _errorType = errType;
            _exception = errException;
            _userList = users;
            _petList = pets;
            _orderList = orders;
            _inventoryJson=inventory;
        }


        /// <summary> 
        /// Main constructor of PetStoreResult  class. This object always return users(if any) with status.
        /// </summary> 
        /// <param name="successful">indicate whether api call is completed ot not</param>
        /// <param name="ecode">indicate status code returned from api</param>
        /// <param name="eMessage">indicate status description returned from api</param>
        /// <param name="errType">indicate error type which returned from api</param>
        /// <param name="users">returned user information (zero or more)</param>
        /// <value> 
        /// _isSuccessful : initialize api call status. 
        /// _errorCode : returned error/status code. 
        /// _errorMessage : returned error/status description.
        /// _errorType : returned error type where is it error or warning.
        /// _userList: returned zero or more users from the api call(if any)
        /// </value> 
        public PetStoreResult(bool successful,
                              int ecode,
                              string eMessage,
                              string errType,
                              List<User> users)
        {
            _isSuccessful = successful;
            _errorCode = ecode;
            _errorMessage = eMessage;
            _errorType = errType;
            _userList = users;            
        }


        /// <summary> 
        /// Main constructor of PetStoreResult class. This object always return pets(if any) with status.
        /// </summary> 
        /// <param name="successful">indicate whether api call is completed ot not</param>
        /// <param name="ecode">indicate status code returned from api</param>
        /// <param name="eMessage">indicate status description returned from api</param>
        /// <param name="errType">indicate error type which returned from api</param>
        /// <param name="pets">returned pets information (zero or more)</param>  
        /// <value> 
        /// _isSuccessful : initialize api call status. 
        /// _errorCode : returned error/status code. 
        /// _errorMessage : returned error/status description.
        /// _errorType : returned error type where is it error or warning.
        /// _petList: returned zero or more pets from the api call(if any)
        /// </value> 
        public PetStoreResult(bool successful,
                              int ecode,
                              string eMessage,
                              string errType,
                              List<Pet> pets)
        {
            _isSuccessful = successful;
            _errorCode = ecode;
            _errorMessage = eMessage;
            _errorType = errType;
            _petList = pets;
        }


        /// <summary> 
        /// Main constructor of PetStoreResult  class. This object always return orders(if any) with status.
        /// </summary> 
        /// <param name="successful">indicate whether api call is completed ot not</param>
        /// <param name="ecode">indicate status code returned from api</param>
        /// <param name="eMessage">indicate status description returned from api</param>
        /// <param name="errType">indicate error type which returned from api</param>
        /// <param name="orders">returned order information (zero or more)</param>
        /// <value> 
        /// _isSuccessful : initialize api call status. 
        /// _errorCode : returned error/status code. 
        /// _errorMessage : returned error/status description.
        /// _errorType : returned error type where is it error or warning.
        /// _orderList: returned zero or more orders from the api call(if any)
        /// </value> 
        public PetStoreResult(bool successful,
                              int ecode,
                              string eMessage,
                              string errType,
                              List<Order> orders)
        {
            _isSuccessful = successful;
            _errorCode = ecode;
            _errorMessage = eMessage;
            _errorType = errType;
            _orderList = orders;
        }

        /// <summary> 
        /// Main constructor of PetStoreResult  class. This object always return unsuccessful api call with error details.
        /// </summary> 
        /// <param name="successful">indicate whether api call is completed ot not</param>
        /// <param name="ecode">indicate status code returned from api</param>
        /// <param name="eMessage">indicate status description returned from api</param>
        /// <param name="errType">indicate error type which returned from api</param>
        /// <param name="errException">indicate inner exception which returned from api</param>
        /// <value> 
        /// _isSuccessful : initialize api call status. 
        /// _errorCode : returned error/status code. 
        /// _errorMessage : returned error/status description.
        /// _errorType : returned error type where is it error or warning.
        /// _exception: returned innner exception if any
        /// </value> 
        public PetStoreResult(bool successful,
                              int ecode,
                              string eMessage,
                              string errType,
                              string errException)
        {
            _isSuccessful = successful;
            _errorCode = ecode;
            _errorMessage = eMessage;
            _errorType = errType;
            _exception = errException;
        }

        /// <summary> 
        /// Main constructor of PetStoreResult  class. This is object  always return to client  callers.
        /// </summary> 
        /// <param name="successful">indicate whether api call is completed ot not</param>
        /// <param name="ecode">indicate status code returned from api</param>
        /// <param name="eMessage">indicate status description returned from api</param>
        /// <param name="errException">indicate inner exception which returned from api</param>
        /// <param name="errType">indicate error type which returned from api</param>
        /// <param name="inventory">returned inventory information (zero or more)</param>
        /// <value> 
        /// _isSuccessful : initialize api call status. 
        /// _errorCode : returned error/status code. 
        /// _errorMessage : returned error/status description.
        /// _exception: returned innner exception if any
        /// _errorType : returned error type where is it error or warning.
        /// _inventoryJson: returned zero or more inventories as a jsonstring from the api call(if any)
        /// </value> 
        public PetStoreResult(bool successful,
                              int ecode,
                              string eMessage,
                              string errType,
                              object inventory)
        {
            _isSuccessful = successful;
            _errorCode = ecode;
            _errorMessage = eMessage;
            _errorType = errType;
            _inventoryJson = inventory.ToString();
        }


        public bool IsSuccessful=> _isSuccessful;
        public int ErrorCode => _errorCode;
        public string? ErrorMessage => _errorMessage;

        public string? ErrorType => _errorType;
        public List<User>? UserList => _userList;
        public List<Pet>? PetsList => _petList;
        public List<Order>? OrderList => _orderList;

        public string? InvetoryJson => _inventoryJson;


    }
}
