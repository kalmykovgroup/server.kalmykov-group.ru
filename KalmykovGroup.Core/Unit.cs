using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalmykovGroup.Core
{
    [Table("units")]
    public class Unit //шт. л. кг.
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;
    }
}
