using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Core.Entities
{
    [Table("Phan_quyen_thu_ky")]
    public class SecretaryManager
    {
        [Key]
        public int ID { get; set; }
        public required string Nha_may { get; set; }
        public required string MST { get; set; }
        public required string Chuyen_to { get; set; }
        public required string MST_QL { get; set; }
    }
}
