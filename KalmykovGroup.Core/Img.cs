using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalmykovGroup.Core
{
    public enum Size { _70x70, _150x150, _300x300, _1200x1200 }

    /*/Big/ - фотографии размером до 1200*1200 пикселей.
    /Medium/ - фотографии размером 300*300 пикселей.
    /Small/ - фотографии размером 150*150 пикселей.
    /Icon/ - фотографии размером 70*70 пикселей. */

    [Table("images")]
    public class Img
    {
        public int Id { get; set; } 

        [MaxLength(512)]
        public string Src { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Extension { get; set; } = string.Empty;

        public Size Size { get; set; } 


    }
}
