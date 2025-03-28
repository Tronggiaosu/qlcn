USE [CAPNUOC_TDC]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 19/10/2024 11:37:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Text] [nvarchar](255) NULL,
	[Action] [nvarchar](255) NULL,
	[Icon] [nvarchar](255) NULL,
	[Status] [int] NULL,
	[Sort] [int] NULL,
	[ParentId] [int] NULL,
	[AdditionParam] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (1, N'hệThốngToolStripMenuItem', N'Hệ thống', NULL, NULL, 1, 99000, NULL, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (2, N'ngườiDùngToolStripMenuItem', N'Quản lý người dùng', NULL, NULL, 0, 200, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (3, N'nhânViênToolStripMenuItem', N'Nhân viên', N'HeThong.UcNhanVienForm', NULL, 1, 300, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (4, N'mnuNguoiDung', N'Người dùng', N'HeThong.UcUserForm', NULL, 1, 400, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (5, N'mnuNhom', N'Nhóm người dùng', N'DanhMuc.UcGroupForm', NULL, 1, 500, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (6, N'mnuPhanQuyen', N'Phân quyền chức năng', N'HeThong.UcPhanQuyenForm', NULL, 1, 600, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (7, N'phânQuyềnLộTrìnhToolStripMenuItem', N'Cập nhật lộ trình', N'LoTrinhThu.UcCapNhatLT', NULL, 1, 700, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (8, N'đemHóaĐơnVềPhânChiaChoTNVToolStripMenuItem', N'Đem hóa đơn về phân chia cho TNV', N'GachNo.UcPhanQuyenNhanVienThu', NULL, 0, 800, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (9, N'dSHóaĐơnChưaChiaChoTNVToolStripMenuItem', N'DS hóa đơn chưa chia cho TNV', N'LoTrinhThu.UcDSHoaDonChuaChiaChoTNV', NULL, 0, 900, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (10, N'thayĐổiMậtKhẩuToolStripMenuItem', N'Thay đổi mật khẩu', N'HeThong.ChangePassForm', NULL, 0, 1000, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (11, N'đăngXuấtToolStripMenuItem', N'Đăng xuất', NULL, NULL, 0, 1100, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (12, N'thoátToolStripMenuItem', N'Thoát', NULL, NULL, 0, 1200, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (13, N'đồngBộDữLiệuToolStripMenuItem', N'Đồng bộ dữ liệu', N'HoaDon.UcDongBoDuLieuHoaDon', NULL, 0, 1300, 1, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (14, N'quảnLýKháchHàngToolStripMenuItem', N'Khách hàng', NULL, N'User', 1, 1400, NULL, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (15, N'kháchHàngToolStripMenuItem', N'Cập nhật thông tin khách hàng', N'HoaDon.UcCapNhatThongTinKH', N'UserEdit', 1, 1500, 14, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (16, N'inGiấyBáoTiềnNướcToolStripMenuItem', N'In giấy báo tiền nước', N'HoaDon.UcGiayBaoTienNuoc', N'Box', 1, 1600, 14, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (17, N'quảnLýYêuCầuToolStripMenuItem', N'Quản lý mở/khóa nước', N'HoaDon.UcKhachHang', NULL, 1, 1700, 14, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (18, N'cậpNhậtĐịaChỉKháchHàngBằngFileExcelToolStripMenuItem', N'Cập nhật địa chỉ khách hàng bằng file excel', N'HoaDon.UcCapNhatDiaChiKH', NULL, 1, 1800, 14, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (19, N'đồngBộKháchHàngXemHóaĐơnToolStripMenuItem', N'Đồng bộ khách hàng xem hóa đơn', N'HoaDon.UcDongBoKhachHangForm', NULL, 1, 1900, 14, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (20, N'hóaĐơnToolStripMenuItem', N'Quản lý hóa đơn', NULL, N'FileInvoice', 1, 2000, NULL, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (21, N'dữLiệuHóaĐơnToolStripMenuItem', N'Import dữ liệu hóa đơn', N'GachNo.UcHoaDon', NULL, 1, 2100, 20, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (22, N'importDữLiệuChiTiếtHóaĐơnToolStripMenuItem', N'Import dữ liệu chi tiết hóa đơn', N'HoaDon.UcChitietHD', NULL, 1, 2200, 20, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (23, N'tạoHóaĐơnToolStripMenuItem', N'Tạo hóa đơn', N'HoaDon.UcTaoHoaDon', NULL, 1, 2300, 20, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (24, N'phátHànhHóaĐơnToolStripMenuItem', N'Phát hành hóa đơn', N'HoaDon.UcPhatHanhHD', NULL, 1, 2400, 20, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (25, N'đồngBộDữLiệuThuHộToolStripMenuItem', N'Đồng bộ dữ liệu thu hộ', N'HoaDon.UcDongBoHDThuHo', NULL, 1, 2500, 20, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (26, N'traCứuHóaĐơnToolStripMenuItem', N'Tra cứu hóa đơn', N'GachNo.UcTraCuuHoaDon', NULL, 1, 2600, 20, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (27, N'kỳHóaĐơnToolStripMenuItem', N'Kỳ hóa đơn', N'HoaDon.UcKyGhi', NULL, 1, 2700, 20, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (28, N'đồngBộThanhToánLỗiToolStripMenuItem', N'Đồng bộ thanh toán lỗi', N'GachNo.UcDongBoThanhToanThuHo', NULL, 1, 2800, 20, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (29, N'xửLýHóaĐơnToolStripMenuItem', N'Xử lý hóa đơn', NULL, N'FileInvoiceDollar', 1, 2900, NULL, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (30, N'tạoQuyếtĐịnhĐiềuChỉnhHĐToolStripMenuItem', N'Tạo quyết định điều chỉnh HĐ', N'HoaDon.UcXuLyHoaDon', NULL, 1, 3000, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (31, N'quyếtĐịnhĐiềuChỉnhHóaĐơnToolStripMenuItem', N'Danh sách quyết định điều chỉnh hóa đơn', N'HoaDon.UcQuanlyQD_DieuChinh', NULL, 1, 3100, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (32, N'lậpHóaĐơnĐiềuChỉnhToolStripMenuItem', N'Điều chỉnh thông tin', N'HoaDon.UcDieuChinhHoaDon', NULL, 1, 3200, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (33, N'danhSáchHóaĐơnĐiềuChỉnhThôngTinToolStripMenuItem', N'Danh sách hóa đơn điều chỉnh thông tin', N'HoaDon.UcThongKeDieuChinhThongTin', NULL, 1, 3300, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (34, N'lậpHóaĐơnThayThếToolStripMenuItem', N'Lập hóa đơn mới', N'HoaDon.UcThayTheHoaDon', NULL, 1, 3400, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (35, N'hủyHóaĐơnToolStripMenuItem1', N'Hủy hóa đơn', N'HoaDon.UcHoaDonHuy', NULL, 1, 3500, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (36, N'danhSáchHóaĐơnĐiềuChỉnhToolStripMenuItem', N'Danh sách hóa đơn điều chỉnh', N'HoaDon.UcQLHoaDonDieuChinh', NULL, 1, 3600, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (37, N'danhSáchHóaĐơnHủyToolStripMenuItem', N'Danh sách hóa đơn hủy', N'HoaDon.UcQLHuyHoaDon', NULL, 0, 3700, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (38, N'đồngBộThanhToánHDDTToolStripMenuItem', N'Đồng bộ thanh toán HDDT', N'GachNo.UcDongBoHDDT', NULL, 1, 3800, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (39, N'đồngBộDữLiệuThuHộToolStripMenuItem1', N'Đồng bộ dữ liệu thanh toán thu hộ', N'HoaDon.UcDongBoDuLieuHoaDon', NULL, 1, 3900, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (40, N'đồngBộDữLiệuThanhToànFileExcelToolStripMenuItem', N'Đồng bộ dữ liệu thanh toán file excel', N'GachNo.UcDongBoThanhToanEx', NULL, 1, 4000, 29, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (41, N'quảnLýNợKhóĐòiToolStripMenuItem', N'Hóa đơn khó đòi', NULL, N'Dice', 1, 4100, NULL, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (42, N'danhSáchHóaĐơnKhóĐòiToolStripMenuItem', N'Chuyển nợ khó đòi', N'HoaDon.UcQLHoaDonKhoDoi', NULL, 1, 4200, 41, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (43, N'tổngHợpDanhSáchChuyểnNợToolStripMenuItem', N'Danh sách chuyển nợ', N'HoaDon.UcDSChuyenNo', NULL, 1, 4300, 41, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (44, N'gạchNợKhóĐòiToolStripMenuItem1', N'Thanh toán nợ khó đòi', N'GachNo.UcGachNoKH', NULL, 0, 4400, 41, N'{"maloai":"KD","trangthai":7}')
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (45, N'quảnLýHóaĐơnTrảChậmToolStripMenuItem', N'Hóa đơn trả chậm', NULL, N'HourglassEmpty', 1, 4500, NULL, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (46, N'gạchNợKháchHàngTrảChậmToolStripMenuItem', N'Thanh toán nợ trả chậm', N'GachNo.UcGachNoKH', NULL, 1, 4600, 45, N'{"maloai" :"TC", "trangthai" : 6}')
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (47, N'tổngHợpĐăngNgânTrảChậmToolStripMenuItem', N'Tổng hợp đăng ngân trả chậm', N'DangNgan.UcDangNganChuyenKhoan', NULL, 1, 4700, 45, N'{"maloai":"TC"}')
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (48, N'quảnLýNợToolStripMenuItem', N'Quản lý nợ', NULL, N'DollarSign', 1, 4800, NULL, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (49, N'gạchNợTạiQuầyToolStripMenuItem', N'Đăng ngân của nhân viên thu', N'GachNo.UcGachNoNV', NULL, 1, 4900, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (50, N'gạchNợTạiQuầyToolStripMenuItem1', N'Gạch nợ tại quầy', N'GachNo.UcGachNoKH', NULL, 1, 5000, 48, N'{"maloai":"KH","trangthai":0}')
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (51, N'gạchNợToolStripMenuItem', N'Gạch nợ chuyển khoản', N'GachNo.UcGachNoKH', NULL, 1, 5100, 48, N'{"maloai":"CK"}')
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (52, N'gạchNợChuyểnKhoảnBằngFileExcelToolStripMenuItem', N'Gạch nợ chuyển khoản bằng file excel', N'GachNo.UcGachNo_Excel', NULL, 1, 5200, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (53, N'gạchNợĐốiTácThuHộToolStripMenuItem', N'Gạch nợ đối tác thu hộ', N'GachNo.UcGachNo_ThuHo', NULL, 1, 5300, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (54, N'quảnLýBiênNhậnToolStripMenuItem', N'Tổng hợp thanh toán', N'GachNo.UcQLBienNhan', NULL, 1, 5400, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (55, N'thanhToánHóaĐơn0đToolStripMenuItem', N'Thanh toán hóa đơn 0đ', N'GachNo.UcGachNoHDKhongDong', NULL, 1, 5500, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (56, N'xácNhậnNộpTiềnToolStripMenuItem', N'Xác nhận nộp tiền', N'GachNo.UcGachNoKeToan', NULL, 1, 5600, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (57, N'tổngHợpĐăngNgânTheoNgàyToolStripMenuItem', N'Tổng hợp đăng ngân thu tại quầy', N'DangNgan.UcDangNganChuyenKhoan', NULL, 1, 5700, 48, N'{"maloai":"KH"}')
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (58, N'tổngHợpĐăngNgânChuyểnKhoảnToolStripMenuItem', N'Tổng hợp đăng ngân chuyển khoản', N'DangNgan.UcDangNganChuyenKhoan', NULL, 1, 5800, 48, N'{"maloai":"CK"}')
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (59, N'danhSáchKháchHàngĐãThanhToánToolStripMenuItem', N'Danh sách khách hàng đã thanh toán', N'ReportViewer.BaoCao.UcThongKeHDDaThu', NULL, 1, 5900, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (60, N'tổngHợpĐăngNgânNhânViênThuToolStripMenuItem', N'Tổng hợp đăng ngân nhân viên thu', N'DangNgan.UcDangNganChuyenKhoan', NULL, 1, 6000, 48, N'{"maloai":"TT"}')
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (61, N'tổngHợpĐăngNgânToolStripMenuItem', N'Tổng hợp đăng ngân', N'ReportViewer.BaoCao.UcBaoCaoTongHop', NULL, 1, 6100, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (62, N'tổngHợpĐăngNgânTheoĐốiTượngToolStripMenuItem', N'Tổng hợp đăng ngân theo đối tượng', N'DangNgan.UcBaoCaoTongHopTheoLoai', NULL, 1, 6200, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (63, N'phiếuĐăngNgânChuyểnKhoảnToolStripMenuItem', N'Phiếu đăng ngân chuyển khoản', N'DangNgan.UcTongHopChuyenKhoan', NULL, 1, 6300, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (64, N'đẩyDữLiệuSangBiilingToolStripMenuItem', N'Xuất file data', N'DangNgan.UcTongHopBilling', NULL, 1, 6400, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (65, N'toolStripMenuItem3', N'Log Thu Tiền Nước', N'GachNo.UcQLPhieuThu_App', NULL, 1, 6500, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (66, N'danhSáchHủyThanhToánToolStripMenuItem', N'Danh sách hủy thanh toán', N'HoaDon.UcDSHuyThanhToan', NULL, 1, 6600, 48, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (67, N'thốngKêBáoCáoToolStripMenuItem', N'Thống kê - Báo cáo', NULL, N'FileText', 1, 6700, NULL, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (68, N'báoCáoToolStripMenuItem', N'Báo cáo chuẩn thu', N'ReportViewer.BaoCao.UcBaoCaoChuanThu', NULL, 1, 6800, 67, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (69, N'báoCáoTổngHợpHóaĐơnChiaTheoĐợtToolStripMenuItem', N'Báo cáo tổng hợp hóa đơn chia theo đợt', N'ReportViewer.BaoCao.UcBaoCaoChuanThu_Dot', NULL, 1, 6900, 67, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (70, N'báoCáoTổngHợpHóaĐơnBằng0ChiaTheoĐợtToolStripMenuItem', N'Báo cáo tổng hợp hóa đơn bằng 0 chia theo đợt', N'ReportViewer.BaoCao.UcBaoCaoChuanThu0Dong', NULL, 1, 7000, 67, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (71, N'phiếuTheoDõiHóaĐơnToolStripMenuItem', N'Phiếu theo dõi hóa đơn', N'ReportViewer.BaoCao.UcBaoCaoTheoDoiHoaDon', NULL, 1, 7100, 67, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (72, N'bảngTổngHợpĐăngNgânHàngNgàyToolStripMenuItem', N'Bảng tổng hợp đăng ngân hàng ngày', N'ReportViewer.BaoCao.UcBaoCaoTongHopDangNganTheoNgay', NULL, 1, 7200, 67, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (73, N'thốngKêKháchHàngNợNhiềuKỳToolStripMenuItem', N'Thống kê khách hàng nợ nhiều kỳ', N'ReportViewer.BaoCao.UcKhachHangNoNhieuKy', NULL, 1, 7300, 67, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (74, N'danhSáchKháchHàngGửiSmsToolStripMenuItem', N'Danh sách khách hàng gửi sms', N'HoaDon.UcDSNoNhieuKySMS', NULL, 1, 7400, 67, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (75, N'bảngKêHóaĐơnToolStripMenuItem', N'Bảng kê hóa đơn', N'ReportViewer.DataSource.UcBangKeHoaDon', NULL, 1, 7500, 67, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (76, N'trợGiúpToolStripMenuItem', N'Trợ giúp', NULL, N'CircleQuestion', 0, 7600, NULL, NULL)
INSERT [dbo].[Menu] ([Id], [Name], [Text], [Action], [Icon], [Status], [Sort], [ParentId], [AdditionParam]) VALUES (77, N'mnuTichHop', N'Tích hợp', N'HeThong.UcLienKet', N'Gears', 1, 7700, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
