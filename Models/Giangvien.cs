using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLSV.Models;

[Table("GIANGVIEN")]
public partial class Giangvien
{
    [Key]
    [Column("MaGV")]
    public int MaGv { get; set; }

    [Column("TenGV")]
    [StringLength(100)]
    public string? TenGv { get; set; }

    [Column(TypeName = "numeric(10, 0)")]
    public decimal? Luong { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? MaKhoa { get; set; }
    public string? Keyword { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("MaGvNavigation")]
    public virtual ICollection<Huongdan> Huongdans { get; set; } = new List<Huongdan>();
    public Giangvien() { }
    public Giangvien(int maGv, string? tenGv, decimal? luong, string? maKhoa)
    {
        MaGv = maGv;
        TenGv = tenGv;
        Luong = luong;
        MaKhoa = maKhoa;
    }
}
