using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace PetStoreAPICaller.Entity
{
    /// <summary>
    /// class -Initializes a new instance of the <see cref="Pet" with requried parameters />
    /// </summary>
    /// <param name="id">id.</param>
    /// <param name="name">name (required).</param>
    /// <param name="category">category.</param>
    /// <param name="photoUrls">photoUrls (required).</param>
    /// <param name="tags">tags.</param>
    /// <param name="status">pet status in the store.</param>
    public class Pet
    {


        /// <summary>
        /// Pet -constructor -Initializes a new instance of the <see cref="Pet" with requried parameters />
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name (required).</param>
        /// <param name="category">category.</param>
        /// <param name="photoUrls">photoUrls (required).</param>
        /// <param name="tags">tags.</param>
        /// <param name="status">pet status in the store.</param>
        public Pet(long id = default(long), string? name = default(string), 
            Category? category = default(Category), List<string>? photoUrls = default(List<string>), 
            List<Tag>? tags = default(List<Tag>), string? status = default(string))
        {
            
            this.Name = name;
            this.PhotoUrls = photoUrls;
            this.Id = id;
            this.Category = category;
            this.Tags = tags;
            this.Status = status;
        }

        //[JsonConverter(typeof(Int32Converter))]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Tag>? Tags { get; set; }
        public Category? Category { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Pet {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            if(PhotoUrls!=null && PhotoUrls.Count>0) 
                sb.Append("  PhotoUrls: ").Append(PhotoUrls).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }


    }
}
