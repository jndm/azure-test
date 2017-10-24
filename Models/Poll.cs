using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lunchPollNet.Models
{
    public class Poll 
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime ClosingTime { get; set; }

        public ICollection<PollItem> PollItems { get; set; }
    }
}