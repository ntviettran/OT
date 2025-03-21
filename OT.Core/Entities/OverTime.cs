using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Core.Entities
{
    [Table("Dang_ky_tang_ca")]
    public class OverTime
    {
        [Key]
        public int ID { get; set; }
        public string? Nha_may { get; set; }
        public string? MST { get; set; }
        public string? Ho_ten { get; set; }
        public string? Chuc_vu { get; set; }
        public string? Chuyen_to { get; set; }
        public string? Bo_phan { get; set; }
        public DateOnly Ngay_dang_ky { get; set; }
        public TimeSpan? Tang_ca_sang { get; set; }
        public TimeSpan? Tang_ca_sang_thuc_te { get; set; }
        public TimeSpan? Gio_tang_ca { get; set; }
        public TimeSpan? Gio_tang_ca_thuc_te { get; set; }
        public TimeSpan? Tang_ca_dem { get; set; }
        public TimeSpan? Tang_ca_dem_thuc_te { get; set; }
        public string? ca { get; set; }
        public TimeSpan? Gio_vao { get; set; }
        public TimeSpan? Gio_ra { get; set; }
        public string? HR { get; set; }

    }
}
