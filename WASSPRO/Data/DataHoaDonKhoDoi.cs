using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCongNo.Data
{
    class DataHoaDonKhoDoi
    {
        public decimal ID_HD { get; set; }
        public string trangthaiKH { get; set; }
        public string kyghi { get; set; }
        public string SO_HD { get; set; }
        public decimal? tongtien { get; set; }
        public string tentrangthai { get; set; }
        public string chitiet { get; set; }
        public string thanhtoan { get; set; }
        public string ghichu { get; set; }
        public DateTime? NGAYCHUYEN { get; set; }
        public DateTime? NGAYTHANHTOAN { get; set; }
        public string NGUOITHANHTOAN { get; set; }
        public int? nam { get; set; }
    }
}
