using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalmykovGroup.Core
{
    [Table("categories")]
    public class Category
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Category))]
        public int ParentId { get; set; }
        public Category Parent { get; set; } = null!;

        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;

    }
}
