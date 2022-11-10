using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPICaller.Entity
{
    public class Category
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class.
        /// </summary>
        /// <param name="Id">id.</param>
        /// <param name="Name">username.</param>
        public Category(long id = default(long), string? name = default(string))
        {
            this.Id = id;
            this.Name = name;
           
        }

        public long Id { get; set; }
        public string? Name { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Category \n");
            sb.Append("  Id ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            return sb.ToString();
        }

    }
}
