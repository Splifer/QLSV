using QLSV.Models;

namespace QLSV.Areas.Admin.Data
{
    public class DataHome
    {
        public List<Khoa> DanhSachKhoa { get; set; }
        public List<Sinhvien> DanhSachSV { get; set; }
        public List<Giangvien> DanhSachGV { get; set; }
    }
}
