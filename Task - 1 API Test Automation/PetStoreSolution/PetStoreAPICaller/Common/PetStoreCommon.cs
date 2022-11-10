using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPICaller.Common
{
    public class PetStoreCommon
    {
        public static string Home_Url = "https://petstore.swagger.io/v2/";
        public static string Pet_Url = "https://petstore.swagger.io/v2/pet/";
        public static string Store_Url = "https://petstore.swagger.io/v2/store/";
        public static string User_Url = "https://petstore.swagger.io/v2/user/";

        public static string Header_DefaultContentType = "application/json";
        public static string Header_DefaultAccept = "application/json,application/xml,ultipart/form-data";
        public static string Header_DefaultAuthority = "petstore.swagger.io";
        public static string Header_DefaultEncoding = "UTF-8";

        public static Dictionary<string, string> Default_HeaderParams =
                          new Dictionary<string, string>() {
                              {"content-type",Header_DefaultContentType },
                              {"accept",Header_DefaultAccept },
                              {"authority",Header_DefaultAuthority },
                              {"encoding",Header_DefaultEncoding }
                          };

        

        public static string Api_Token = "";
        public static int  Timeout = 10000;

        public static string DateTimeFormat = "yyyy-MM-dd";

        public enum RequestType { USER, PET, ORDER }

        public enum PetStatus { available, pending, sold }
        public enum OrderStatus { placed, approved, delivered }


    }
}
