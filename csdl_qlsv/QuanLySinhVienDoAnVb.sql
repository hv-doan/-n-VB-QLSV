CREATE DATABASE QuanLySinhVienDoAnVb;
GO

USE QuanLySinhVienDoAnVb;
GO

CREATE TABLE SinhVien (
    MaSV        VARCHAR(10)  PRIMARY KEY,
    HoTen       NVARCHAR(100) NOT NULL,
    NgaySinh    DATE          NOT NULL,
    GioiTinh    CHAR(1)       NULL CHECK (GioiTinh IN ('M','F')),
    DiaChi      NVARCHAR(200) NULL,
    Lop         NVARCHAR(50)  NULL,
    Nganh       NVARCHAR(100) NULL
);

CREATE TABLE MonHoc (
    MaMH       VARCHAR(10)   PRIMARY KEY,
    TenMH      NVARCHAR(100) NOT NULL,
    SoTinChi   INT           NOT NULL CHECK (SoTinChi > 0),
    HocKy      TINYINT       NULL CHECK (HocKy BETWEEN 1 AND 12)
);

CREATE TABLE Diem (
    MaSV         VARCHAR(10)  NOT NULL,
    MaMH         VARCHAR(10)  NOT NULL,
    DiemQuaTrinh DECIMAL(4,2) NULL CHECK (DiemQuaTrinh BETWEEN 0 AND 10),
    DiemThi      DECIMAL(4,2) NULL CHECK (DiemThi BETWEEN 0 AND 10),
    DiemTongKet  AS (ROUND(0.4 * ISNULL(DiemQuaTrinh,0) + 0.6 * ISNULL(DiemThi,0), 2)) PERSISTED,
    CONSTRAINT PK_Diem PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT FK_Diem_SV FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    CONSTRAINT FK_Diem_MH FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH)
);
GO
select name from sys.foreign_keys;
INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, Lop, Nganh)
VALUES 
('SV001', 'Nguyen Van A', '2004-04-20', 'M', 'Ha Noi', 'CTK46A', 'CNTT'),
('SV002', 'Tran Thi B', '2004-11-02', 'F', 'HCM', 'CTK46B', 'CNTT');

INSERT INTO MonHoc (MaMH, TenMH, SoTinChi, HocKy) VALUES
('MH001','Cau truc du lieu',3,2),
('MH002','Co so du lieu',3,3);

INSERT INTO Diem (MaSV, MaMH, DiemQuaTrinh, DiemThi) VALUES
('SV001','MH001',8.0,7.5),
('SV001','MH002',7.0,8.0),
('SV002','MH001',6.5,7.0);
select * from SinhVien