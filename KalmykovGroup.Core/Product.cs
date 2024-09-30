using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalmykovGroup.Core
{
    [Table("products")]
    public class Product
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!; 

        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }
        public Unit Unit { get; set; } = null!; 

        [ForeignKey(nameof(Img))]
        public int ImgId { get; set; }
        public Img Img { get; set; } = null!; 
          
        [ForeignKey(nameof(Rating))]
        public int RatingId { get; set; }
        public Rating Rating { get; set; } = null!;

        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int OldPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
