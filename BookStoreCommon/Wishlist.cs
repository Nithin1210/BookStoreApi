using System.ComponentModel.DataAnnotations;

namespace BookStoreCommon
{
    public class Wishlist
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "IsAvailable is null")]
        public bool IsAvailable { get; set; }

        public virtual Books book { get; set; }

    }
}
