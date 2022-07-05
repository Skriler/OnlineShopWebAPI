using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required field")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required field")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10000")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Producer is required field")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Type is required field")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Amount is required field")]
        [Range(1, 1000, ErrorMessage = "Amount must be between 1 and 1000")]
        public int Amount { get; set; }

        public Product(string title, int price, string producer, string type, int amount)
        {
            Title = title;
            Price = price;
            Producer = producer;
            Type = type;
            Amount = amount;
        }

        public Product()
        { }
    }
}
