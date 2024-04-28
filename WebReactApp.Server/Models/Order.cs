using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebReactApp.Server.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public required string Name { get; set; }
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public required IdentityUser User { get; set; }
    }
}
