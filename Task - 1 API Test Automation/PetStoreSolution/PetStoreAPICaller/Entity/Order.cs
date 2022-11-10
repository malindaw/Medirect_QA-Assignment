using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetStoreAPICaller.Entity
{
    public class Order
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="petId">petId.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="shipDate">shipDate.</param>
        /// <param name="status">Order Status.</param>
        /// <param name="complete">complete.</param>
        public Order(long id = default(long), long petId = default(long),
                    int quantity = default(int), string? shipDate = default(string), 
                    string? status = default(string), bool complete = default(bool))
        {
            this.Id = id;
            this.PetId = petId;
            this.Quantity = quantity;
            this.ShipDate = shipDate;
            this.Status = status;
            this.Complete = complete;
        }


        //[JsonConverter(typeof(Int32Converter))]
        public long Id { get; set; }

       // [JsonConverter(typeof(Int32Converter))]
        public long PetId { get; set; }

       // [JsonConverter(typeof(Int32Converter))]
        public int Quantity { get; set; }
        public string? ShipDate { get; set; }
        public string? Status { get; set; }
        public bool Complete { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Order {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  PetId: ").Append(PetId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  ShipDate: ").Append(ShipDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Complete: ").Append(Complete).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
