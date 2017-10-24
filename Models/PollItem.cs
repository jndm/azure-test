using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lunchPollNet.Models
{
    public class PollItem 
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string CreatedBy { get; set; }

        public string Description { get; set; }

        [Required]
        public int TotalVoteCount { get; set; }

        [Required]
        public bool disabled { get; set; }

        [Required]
        public Restaurant Restaurant { get; set; }

        [Required]
        public Poll Poll { get; set; }
    }
}