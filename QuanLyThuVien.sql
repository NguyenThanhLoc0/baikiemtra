CREATE DATABASE Quan_Ly_Thu_Vien_3;
USE Quan_Ly_Thu_Vien_3;

-- Bảng Nhân viên
CREATE TABLE NhanVien (
    MaNhanVien NVARCHAR(50) PRIMARY KEY,
    HoDem NVARCHAR(50),
    TenNhanVien NVARCHAR(50),
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    DiaChi NVARCHAR(200),
    SoDienThoai NVARCHAR(20),
    GhiChu NVARCHAR(200)
);

-- Bảng Tác giả
CREATE TABLE TacGia (
    MaTacGia NVARCHAR(20) PRIMARY KEY,
    TenTacGia NVARCHAR(100),
    DiaChi NVARCHAR(200),
    SoDienThoai NVARCHAR(20),
    NgaySinh DATE,
    Email NVARCHAR(100),
    GhiChu NVARCHAR(200)
);

-- Bảng Thể loại
CREATE TABLE TheLoai (
    MaTheLoai NVARCHAR(20) PRIMARY KEY,
    TenTheLoai NVARCHAR(100),
    GhiChu NVARCHAR(200)
);

-- Bảng Kho sách
create table KhoSach(
    MaSach nvarchar(10) primary key,
    TenSach nvarchar(200),
    MaTacGia nvarchar(100),   
    MaTheLoai nvarchar(100),  
    SoLuong int,
    GhiChu nvarchar(200)
););

-- Bảng Độc giả
CREATE TABLE DocGia (
    MaDocGia NVARCHAR(20) PRIMARY KEY,
    TenDocGia NVARCHAR(100),
    SoDienThoai NVARCHAR(20),
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    DiaChi NVARCHAR(200),
    DanhGia NVARCHAR(50),
    GhiChu NVARCHAR(200)
);

-- Bảng Đăng nhập
CREATE TABLE DangNhap (
    TaiKhoan NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(50)
);

-- Bảng Nhà xuất bản
CREATE TABLE NhaXuatBan (
    MaNhaXuatBan NVARCHAR(20) PRIMARY KEY,
    TenNhaXuatBan NVARCHAR(100),
    DiaChi NVARCHAR(200),
    Email NVARCHAR(100),
    SoDienThoai NVARCHAR(20),
    GhiChu NVARCHAR(200)
);

-- Bảng Nhập hàng
CREATE TABLE NhapHang (
    MaNhapHang NVARCHAR(20) PRIMARY KEY,
    MaNhaXuatBan NVARCHAR(20),
    MaSach NVARCHAR(20),
    SoLuongNhap INT,
    NgayNhap DATE,
    GhiChu NVARCHAR(200),
    CONSTRAINT FK_NhapHang_NXB FOREIGN KEY (MaNhaXuatBan) REFERENCES NhaXuatBan(MaNhaXuatBan),
    CONSTRAINT FK_NhapHang_Sach FOREIGN KEY (MaSach) REFERENCES KhoSach(MaSach)
);

-- Bảng Phiếu mượn
CREATE TABLE PhieuMuon (
    MaPhieuMuon NVARCHAR(20) PRIMARY KEY,
    MaDocGia NVARCHAR(20),
    MaNhanVien NVARCHAR(20),
    NgayMuon DATE,
    NgayHenTra DATE,
    GhiChu NVARCHAR(200),
    CONSTRAINT FK_PhieuMuon_DocGia FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia),
    
);

-- Bảng Phiếu trả
CREATE TABLE PhieuTra (
    MaPhieuTra NVARCHAR(20) PRIMARY KEY,
    MaPhieuMuon NVARCHAR(20),
    NgayTra DATE,
    GhiChu NVARCHAR(200),
    CONSTRAINT FK_PhieuTra_PhieuMuon FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon)
);

-- Bảng Chi tiết phiếu mượn
CREATE TABLE ChiTietPhieuMuon (
    MaPhieuMuon NVARCHAR(20),
    MaSach NVARCHAR(20),
    SoLuong INT,
    PRIMARY KEY (MaPhieuMuon, MaSach),
    CONSTRAINT FK_CTPM_PhieuMuon FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon),
    CONSTRAINT FK_CTPM_Sach FOREIGN KEY (MaSach) REFERENCES KhoSach(MaSach)
);

-- Bảng Chi tiết phiếu trả
CREATE TABLE ChiTietPhieuTra (
    MaPhieuTra NVARCHAR(20),
    MaSach NVARCHAR(20),
    SoLuong INT,
    PRIMARY KEY (MaPhieuTra, MaSach),
    CONSTRAINT FK_CTPT_PhieuTra FOREIGN KEY (MaPhieuTra) REFERENCES PhieuTra(MaPhieuTra),
    CONSTRAINT FK_CTPT_Sach FOREIGN KEY (MaSach) REFERENCES KhoSach(MaSach)
);
-- Nhân viên
INSERT INTO NhanVien (MaNhanVien, HoDem, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, GhiChu)
VALUES 
(N'NV01', N'Nguyễn', N'An', N'Nam', '1990-05-20', N'Hà Nội', N'0912345678', N'Quản lý'),
(N'NV02', N'Trần', N'Bình', N'Nam', '1995-07-12', N'Đà Nẵng', N'0987654321', N'Thủ thư');

-- Tác giả
INSERT INTO TacGia (MaTacGia, TenTacGia, DiaChi, SoDienThoai, NgaySinh, Email, GhiChu)
VALUES
(N'TG01', N'Tô Hoài', N'Hà Nội', N'0911111111', '1920-09-27', N'tohoai@gmail.com', N'Tác giả Dế Mèn phiêu lưu ký'),
(N'TG02', N'Nam Cao', N'Hà Nam', N'0922222222', '1915-10-29', N'namcao@gmail.com', N'Tác giả Chí Phèo');

-- Thể loại
INSERT INTO TheLoai (MaTheLoai, TenTheLoai, GhiChu)
VALUES
(N'TL01', N'Truyện ngắn', N'Văn học hiện đại'),
(N'TL02', N'Tiểu thuyết', N'Văn học cổ điển');

-- Kho sách
INSERT INTO KhoSach (MaSach, TenSach, MaTacGia, MaTheLoai, SoLuong, GhiChu)
VALUES
(N'S01', N'Dế Mèn phiêu lưu ký', N'TG01', N'TL01', 10, N'Sách văn học thiếu nhi'),
(N'S02', N'Chí Phèo', N'TG02', N'TL01', 5, N'Truyện ngắn nổi tiếng');

-- Độc giả
INSERT INTO DocGia (MaDocGia, TenDocGia, SoDienThoai, GioiTinh, NgaySinh, DiaChi, DanhGia, GhiChu)
VALUES
(N'DG01', N'Nguyễn Văn Minh', N'0901234567', N'Nam', '2000-01-15', N'Hà Nội', N'Tốt', N'Độc giả thường xuyên'),
(N'DG02', N'Lê Thị Hoa', N'0912345678', N'Nữ', '1999-03-22', N'Hồ Chí Minh', N'Khá', N'Mới đăng ký');

-- Đăng nhập
INSERT INTO DangNhap (TaiKhoan, MatKhau)
VALUES
(N'admin', N'123456'),
(N'user01', N'password');

-- Nhà xuất bản
INSERT INTO NhaXuatBan (MaNhaXuatBan, TenNhaXuatBan, DiaChi, Email, SoDienThoai, GhiChu)
VALUES
(N'NXB01', N'NXB Kim Đồng', N'Hà Nội', N'kimdong@nxb.com', N'0241234567', N'Chuyên sách thiếu nhi'),
(N'NXB02', N'NXB Giáo dục', N'Hồ Chí Minh', N'nxbgd@nxb.com', N'0287654321', N'Sách giáo khoa');

-- Nhập hàng
INSERT INTO NhapHang (MaNhapHang, MaNhaXuatBan, MaSach, SoLuongNhap, NgayNhap, GhiChu)
VALUES
(N'NH01', N'NXB01', N'S01', 20, '2025-09-01', N'Nhập đợt 1'),
(N'NH02', N'NXB02', N'S02', 15, '2025-09-05', N'Nhập đợt 2');

-- Phiếu mượn
INSERT INTO PhieuMuon (MaPhieuMuon, MaDocGia, MaNhanVien, NgayMuon, NgayHenTra, GhiChu)
VALUES
(N'PM01', N'DG01', N'NV01', '2025-09-10', '2025-09-20', N'Mượn lần 1'),
(N'PM02', N'DG02', N'NV02', '2025-09-12', '2025-09-22', N'Mượn lần 2');

-- Chi tiết phiếu mượn
INSERT INTO ChiTietPhieuMuon (MaPhieuMuon, MaSach, SoLuong)
VALUES
(N'PM01', N'S01', 1),
(N'PM01', N'S02', 2),
(N'PM02', N'S02', 1);

-- Phiếu trả
INSERT INTO PhieuTra (MaPhieuTra, MaPhieuMuon, NgayTra, GhiChu)
VALUES
(N'PT01', N'PM01', '2025-09-18', N'Trả đúng hạn'),
(N'PT02', N'PM02', '2025-09-25', N'Trả trễ');

-- Chi tiết phiếu trả
INSERT INTO ChiTietPhieuTra (MaPhieuTra, MaSach, SoLuong)
VALUES
(N'PT01', N'S01', 1),
(N'PT01', N'S02', 2),
(N'PT02', N'S02', 1);









