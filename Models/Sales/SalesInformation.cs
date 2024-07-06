using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SalesRecord.Models.SalesView;

public class SalesInformation
{
    [Display(Name = "Customer Name")]
    [Required]
    public string CustomersName { get; set; } = default!;

    [Display(Name = "")]
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    [Display(Name = "Sellers Name")]
    public string? SellersName { get; set; }


    [Display(Name = "Customer Phone")]
    [Required]
    public string CustomerPhoneNumber { get; set; } = default!;

}
