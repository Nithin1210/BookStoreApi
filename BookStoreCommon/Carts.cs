using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreCommon
{
    public class Carts
    {

        [Required(ErrorMessage = "BookId is null")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Count is null")]
        public int Count { get; set; }

        [Required(ErrorMessage = "IsAvailable is null")]
        public bool IsAvailable { get; set; }
        public virtual Books Book { get; set; }
    }
}
