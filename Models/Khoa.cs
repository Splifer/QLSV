using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace QLSV.Models;

[Table("KHOA")]
public partial class Khoa
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    [Required(ErrorMessage = "Vui lòng nhập mã khoa")]

    public string MaKhoa { get; set; } = null!;

    [StringLength(50)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập tên khoa")]
    public string? TenKhoa { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng điền số điện thoại")]
    public string? SoDienThoai { get; set; }

    public string? Keyword { get; set; }
    public bool IsActive { get; set; }
    [InverseProperty("MaKhoaNavigation")]
    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();

    public Khoa()
    {
        this.IsActive = false;
    }

    public Khoa(string makhoa, string tenkhoa, string sdt, bool isActive)
    {
        this.MaKhoa = makhoa;
        this.TenKhoa = tenkhoa;
        this.SoDienThoai = sdt;
        this.IsActive = isActive;
        this.Keyword = makhoa.ToLower() + " " + tenkhoa.ToLower();
    }
}
