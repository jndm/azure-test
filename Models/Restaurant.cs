using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lunchPollNet.Models
{
    public class Restaurant 
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string LunchUrl { get; set; }
        
        [Required]
        public string StreetAddress { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string PostalCode { get; set; }
    }
}