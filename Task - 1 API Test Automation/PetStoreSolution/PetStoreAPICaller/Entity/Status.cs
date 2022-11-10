using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PetStoreAPICaller.Common;
using System.Xml.Linq;

namespace PetStoreAPICaller.Entity
{
    public class Status
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Status" /> class.
        /// </summary>
        /// <param name="code">status code</param>
        /// <param name="type">status type</param>
        /// <param name="message">status description.</param>
        public Status(int code = default(int), string? type = default(string),
                    string? message = default(string))
        {
            this.Code = code;
            this.Type = type;
            this.Message = message;
        }

        [JsonConverter(typeof(Int32Converter))]
        public int Code { get; set; }
        public string? Type { get; set; }
        public string? Message { get; set; }

       

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Status \n");
            sb.Append("  Code ").Append(Code).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

    }

    
}
