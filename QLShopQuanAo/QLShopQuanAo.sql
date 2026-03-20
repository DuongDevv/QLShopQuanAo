USE [QLShopQuanAo]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHD] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 2) NULL,
	[ThanhTien]  AS ([SoLuong]*[DonGia]),
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaPN] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuongNhap] [int] NULL,
	[DonGiaNhap] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [datetime] NULL,
	[MaNV] [int] NULL,
	[MaKH] [int] NULL,
	[TongTien] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SDT] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgayDK] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSP]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSP](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSP] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SDT] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [date] NULL,
	[SDT] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[Trangthai] [nvarchar](50) NULL,
	[HinhAnh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPN] [int] IDENTITY(1,1) NOT NULL,
	[NgayNhap] [datetime] NULL,
	[MaNV] [int] NULL,
	[MaNCC] [int] NULL,
	[TongTienNhap] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](100) NOT NULL,
	[DVT] [nvarchar](20) NULL,
	[SoLuongTon] [int] NULL,
	[GiaNhap] [decimal](18, 2) NULL,
	[GiaBan] [decimal](18, 2) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[MaLoai] [int] NULL,
	[HinhAnh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 3/21/2026 1:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenTK] [varchar](50) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
	[MaNV] [int] NULL,
	[PhanQuyen] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (1, 1, 2, CAST(150000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (1, 3, 1, CAST(350000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (2, 1, 2, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (3, 2, 1, CAST(250000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (4, 2, 2, CAST(250000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (5, 2, 3, CAST(250000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (6, 6, 2, CAST(750000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (7, 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (8, 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (9, 1, 2, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (10, 3, 2, CAST(420000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (11, 4, 1, CAST(380000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (12, 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (13, 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (14, 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong], [DonGia]) VALUES (15, 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [DonGiaNhap]) VALUES (1, 1, 10, CAST(150000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [DonGiaNhap]) VALUES (3, 4, 20, CAST(20000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (1, CAST(N'2026-03-16T19:35:58.740' AS DateTime), 2, 1, CAST(500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (2, CAST(N'2026-03-19T12:57:04.250' AS DateTime), 1, 4, CAST(640000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (3, CAST(N'2026-03-20T19:55:38.257' AS DateTime), 1, 1, CAST(250000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (4, CAST(N'2026-03-20T20:23:45.773' AS DateTime), 1, 1, CAST(500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (5, CAST(N'2026-03-20T20:29:26.367' AS DateTime), 1, 1, CAST(750000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (6, CAST(N'2026-03-20T20:35:26.073' AS DateTime), 1, 1, CAST(1500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (7, CAST(N'2026-03-20T20:50:15.893' AS DateTime), 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (8, CAST(N'2026-03-20T20:51:27.267' AS DateTime), 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (9, CAST(N'2026-03-20T22:14:37.690' AS DateTime), 1, 1, CAST(640000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (10, CAST(N'2026-03-20T22:35:44.117' AS DateTime), 1, 1, CAST(840000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (11, CAST(N'2026-03-20T22:38:03.837' AS DateTime), 1, 1, CAST(380000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (12, CAST(N'2026-03-20T22:38:56.500' AS DateTime), 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (13, CAST(N'2026-03-20T22:42:47.637' AS DateTime), 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (14, CAST(N'2026-03-20T22:46:36.363' AS DateTime), 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (15, CAST(N'2026-03-20T22:48:15.893' AS DateTime), 1, 1, CAST(320000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [GioiTinh], [NgayDK]) VALUES (1, N'Độ Mixi', N'dhasduhwadnakbdk', N'0123456789', N'asdsdad@gmail.com', N'Nam', CAST(N'2026-03-14' AS Date))
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [GioiTinh], [NgayDK]) VALUES (2, N'Đương', N'Đồng THáp', N'0123456789', N'qsdaw@gmail.com', N'Nam', CAST(N'2026-03-15' AS Date))
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [GioiTinh], [NgayDK]) VALUES (4, N'Nguyễn Văn An', N'Quận 7', N'0911222333', N'annguyen@gmail.com', N'Nam', CAST(N'2026-03-16' AS Date))
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [GioiTinh], [NgayDK]) VALUES (5, N'Lê Thị Bình', N'Quận 1', N'0944555666', N'binhle@gmail.com', N'Nữ', CAST(N'2026-03-16' AS Date))
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [GioiTinh], [NgayDK]) VALUES (6, N'Nguyễn Tâm Thanh Tùng', N'Microsoft', N'0988888888', N'pate@gmail.com', N'Nam', CAST(N'2026-03-16' AS Date))
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [GioiTinh], [NgayDK]) VALUES (7, N'Độ Tày', N'Cao Bằng', N'0988888888', N'domixi@gmail.com', N'Nam', CAST(N'2026-03-16' AS Date))
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [GioiTinh], [NgayDK]) VALUES (8, N'Ngọc Khuyển', N'Thanh Hóa', N'0987777777', N'ngoctranvan@gmail.com', N'Nam', CAST(N'2026-03-16' AS Date))
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [GioiTinh], [NgayDK]) VALUES (9, N'Nguyễn Văn Jet', N'dsadasdasds', N'0123123122', N'jet@gmail.com', N'Nam', CAST(N'2026-03-20' AS Date))
GO
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSP] ON 
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (1, N'Sơ mi Nam')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (2, N'Áo thun/Polo')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (3, N'Quần Jean')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (4, N'Quần Tây/Kaki')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (5, N'Váy/Chân váy')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (6, N'Đầm nữ')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (7, N'Khoác/Hoodie')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (8, N'Đồ lót/Ngủ')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (9, N'Nón/Mũ')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (10, N'Thắt lưng/Ví')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (11, N'Túi xách/Balo')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (12, N'Giày Sneaker')
GO
INSERT [dbo].[LoaiSP] ([MaLoai], [TenLoaiSP]) VALUES (13, N'Dép/Sandal')
GO
SET IDENTITY_INSERT [dbo].[LoaiSP] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email]) VALUES (1, N'Gucci', N'Thanh Hóa ', N'0999999999', N'gucci@gmail.com')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email]) VALUES (2, N'Chanel', N'Hung Yên', N'0988888888', N'chanel@gmail.com')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email]) VALUES (3, N'Lacos', N'Los Angeles', N'0987777777', N'lacos@gmail.com')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email]) VALUES (4, N'Độ Mixi', N'Cao Bằng', N'0987666666', N'domixi@gmail.com')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT], [Email]) VALUES (5, N'Đàm Vĩnh Hưng', N'American', N'0987655555', N'vinhhungdam@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [Email], [ChucVu], [Trangthai], [HinhAnh]) VALUES (1, N'Nguyễn Quốc Đương', N'Nam', CAST(N'2000-01-01' AS Date), N'0123456789', N'admin1@gmail.com', N'Quản lí', N'Đang làm việc', N'10eba85a-9ec4-4b05-919f-2e6d66a7728b.jpg')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [Email], [ChucVu], [Trangthai], [HinhAnh]) VALUES (2, N'Lê Thảo Nguyên', N'Nữ', CAST(N'2000-01-01' AS Date), N'0123456789', N'admin2@gmail.com', N'Quản lí', N'Đang làm việc', N'576a2cf0-983a-4fcd-94fd-da400a64f253.jpg')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [Email], [ChucVu], [Trangthai], [HinhAnh]) VALUES (3, N'Đương Đẹp Trai', N'Nam', CAST(N'2006-03-14' AS Date), N'0234567891', N'duong@gmail.com', N'Nhân viên', N'Đang làm việc', N'')
GO
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 
GO
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [MaNV], [MaNCC], [TongTienNhap]) VALUES (1, CAST(N'2026-03-16T19:35:58.740' AS DateTime), 1, 1, CAST(1500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [MaNV], [MaNCC], [TongTienNhap]) VALUES (3, CAST(N'2026-03-20T14:46:11.193' AS DateTime), 1, 2, CAST(400000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (1, N'Sơ mi Oxford', N'Cái', 20, NULL, CAST(320000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 1, N'somi.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (2, N'Áo Polo Navy', N'Cái', 39, NULL, CAST(250000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 2, N'polo.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (3, N'Quần Jean Slim', N'Cái', 23, NULL, CAST(420000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 3, N'jean.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (4, N'Quần Kaki Beige', N'Cái', 39, NULL, CAST(380000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 4, N'kaki.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (5, N'Chân váy chữ A', N'Cái', 15, NULL, CAST(220000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 5, N'vay.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (6, N'Đầm lụa tiệc', N'Cái', 8, NULL, CAST(750000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 6, N'dam.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (7, N'Hoodie Brand', N'Cái', 40, NULL, CAST(450000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 7, N'hoodie.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (8, N'Nón Beanie', N'Cái', 50, NULL, CAST(95000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 9, N'non.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (9, N'Ví da thật', N'Cái', 8, NULL, CAST(550000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 10, N'vi.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (10, N'Balo chống nước', N'Cái', 15, NULL, CAST(620000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 11, N'balo.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (11, N'Sneaker White', N'Đôi', 20, NULL, CAST(1200000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 12, N'sneaker.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (12, N'Sandal quai', N'Đôi', 30, NULL, CAST(280000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 13, N'sandal.jpg')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVT], [SoLuongTon], [GiaNhap], [GiaBan], [TrangThai], [MaLoai], [HinhAnh]) VALUES (13, N'Caro JetJet', N'Cái', 45, NULL, CAST(250000.00 AS Decimal(18, 2)), N'Đang kinh doanh', 1, N'polo.jpg')
GO
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [MaNV], [PhanQuyen]) VALUES (N'admin1', N'123', 1, N'Quản lí')
GO
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [MaNV], [PhanQuyen]) VALUES (N'admin2', N'123', 2, N'Quản lí')
GO
INSERT [dbo].[TaiKhoan] ([TenTK], [MatKhau], [MaNV], [PhanQuyen]) VALUES (N'duong', N'123', 3, N'Nhân viên')
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT (getdate()) FOR [NgayLap]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT (getdate()) FOR [NgayDK]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT (N'Đang làm việc') FOR [Trangthai]
GO
ALTER TABLE [dbo].[PhieuNhap] ADD  DEFAULT (getdate()) FOR [NgayNhap]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT ((0)) FOR [SoLuongTon]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT (N'Đang kinh doanh') FOR [TrangThai]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_CTHD_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_CTHD_SanPham]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPN_PhieuNhap] FOREIGN KEY([MaPN])
REFERENCES [dbo].[PhieuNhap] ([MaPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_CTPN_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPN_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_CTPN_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_LoaiSP_SanPham] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSP] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_LoaiSP_SanPham]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON DELETE CASCADE
GO
