using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalmykovGroup.Core
{
    [Table("ratings")]
    public class Rating
    {
        public int Id { get; set; } 
        public double Value { get; set; }

        public int NumberOfReviews { get; set; }

    }
}
