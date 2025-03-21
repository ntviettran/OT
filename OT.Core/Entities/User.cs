using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Core.Entities
{
    [Table("Nhanvien")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public required string macongty { get; set; }
        public required int masothe { get; set; }
        public required string hoten { get; set; }
        public required string phongban { get; set; }
        public required string capbac { get; set; }
        public required string phanquyen { get; set; }
        public required string matkhau { get; set; }
        public string? deepsea { get; set; }
        public string? skylight { get; set; }
        public string? Kho { get; set; }
    }
}
