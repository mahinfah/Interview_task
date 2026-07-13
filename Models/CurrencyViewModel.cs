using System.ComponentModel.DataAnnotations;

namespace Interview_task.Models
{
    public class CurrencyViewModel
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string FromCurrency { get; set; } = "";

        [Required]
        public string ToCurrency { get; set; } = "";

        public decimal ConvertedAmount { get; set; }
    }
}