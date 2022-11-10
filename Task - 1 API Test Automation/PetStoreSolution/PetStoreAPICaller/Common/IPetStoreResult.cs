// IPetStoreResult.cs 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreAPICaller.Entity;

namespace PetStoreAPICaller.Common
{
    /// <summary> 
    /// Interface-IPetStoreResult
    /// This  interface contained all the required properties of  api response returned.
    /// </summary> 
    /// <remarks> 
    /// Mainly hold the error information such as code ,description. Also contained user,pets,order list if available 
    /// </remarks> 
    public interface IPetStoreResult
    {

        
        public bool IsSuccessful => IsSuccessful;
        public int ErrorCode => ErrorCode;
        public string? ErrorMessage => ErrorMessage;

        public string? ErrorType => ErrorType;
        public List<User>? UserList => UserList;
        public List<Pet>? PetsList => PetsList;
        public List<Order>? OrderList => OrderList;
    }
}
