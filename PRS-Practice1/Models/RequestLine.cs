using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace PRS_Practice1.Models {
    public class RequestLine {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;

        //FK's and Virtual Properties
        public int RequestId { get; set; }
        [JsonIgnore]                                 // Correct ???
        public virtual Request? Request { get; set; }

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; } = null;
    }
}
