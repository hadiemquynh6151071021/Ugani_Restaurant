CREATE DATABASE UGANI_1
GO
USE UGANI_1
GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
	[UserName]             NVARCHAR (256) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC)
);

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserRoles]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);


CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);



CREATE TABLE LOAIBAN(
	MALOAIBAN INT NOT NULL IDENTITY(1,1),
	TENLOAIBAN NVARCHAR(50),
	MOTA NVARCHAR(500),
	DONGIA DECIMAL,
	DVT NVARCHAR(10),

	-->RBTV
	CONSTRAINT RBTV_PK_LOAIBAN PRIMARY KEY(MALOAIBAN)
)

CREATE TABLE BANAN(
	MABAN CHAR(10) PRIMARY KEY NOT NULL,
	MALOAIBAN INT NOT NULL,
	SOGHE TINYINT,
	
	-->RBTV
	CONSTRAINT RBTV_PF_BANAN FOREIGN KEY (MALOAIBAN) REFERENCES LOAIBAN(MALOAIBAN)
)

CREATE TABLE LOAIMON(
	MALOAIMON INT NOT NULL IDENTITY(1,1),
	TENLOAIMON NVARCHAR(200),

	-->RBTV
	CONSTRAINT RBTV_PK_LOAIMON PRIMARY KEY(MALOAIMON)
)


CREATE TABLE MONAN(
	MAMONAN INT NOT NULL IDENTITY(1,1),
	MALOAIMON INT NOT NULL,
	TENMONAN NVARCHAR(100),
	HINHANH NVARCHAR(100),
	DONGIA DECIMAL,
	DVT NVARCHAR(10),

	-->RBTV
	CONSTRAINT RBTV_PK_MONAN PRIMARY KEY(MAMONAN),
	CONSTRAINT RBTV1_PF_MONAN FOREIGN KEY (MALOAIMON) REFERENCES LOAIMON(MALOAIMON)
)


CREATE TABLE CHITIETDATMONAN(
	MAKH  NVARCHAR (128) NOT NULL,
	MAMONAN INT NOT NULL,
	SOLUONG INT,
	NGAYDAT	DATE,

	CONSTRAINT RBTV_PF_1_DANHSACHMONAN FOREIGN KEY (MAKH) REFERENCES AspNetUsers(Id),
	CONSTRAINT RBTV_PF2_DANHSACHMONAN FOREIGN KEY (MAMONAN) REFERENCES MONAN(MAMONAN)
)

CREATE TABLE CHITIETDATBAN(
	MAKH NVARCHAR (128) NOT NULL,
	MABAN CHAR(10) NOT NULL,
	NGAYDAT	DATE,
	GIODATBAN	DATETIME,
	GIOTRABAN		DATETIME,

	CONSTRAINT RBTV_PF1_DANHSACHBAN FOREIGN KEY (MAKH) REFERENCES AspNetUsers(Id),
	CONSTRAINT RBTV_PF2_DANHSACHBAN FOREIGN KEY (MABAN) REFERENCES BANAN(MABAN)


)

CREATE TABLE HOADON(
	MAKH NVARCHAR (128) NOT NULL,
	NGAYDATCOC DATE,
	TONGTIEN DECIMAL,
	TIENCOC DECIMAL,

	CONSTRAINT RBTV_PF1_HOADON FOREIGN KEY (MAKH) REFERENCES AspNetUsers(Id),
)

-->INSERT INFORMATION

INSERT INTO LOAIBAN VALUES
(N'VIP',N'Bàn ăn được bố trí trong không gian phòng ăn được xây dựng tách biệt so với các không gian ẩm thực còn lại trong nhà hàng, đảm bảo tính riêng tư cao.',50000,N'Ghế'),
(N'Thường',N'Bàn ăn được bố trí trong không gian sảnh chung của nhà hàng',25000,N'Ghế');

INSERT INTO BANAN VALUES
('AV1-2',1,2),('AV2-2',1,2),('AV3-2',1,2),('AV4-2',1,2),('AV5-2',1,2),('AV6-2',1,2),('AV7-2',1,2),('AV8-2',1,2),('AV9-2',1,2),('AV10-2',1,2),
('AV11-2',1,2),('AV12-2',1,2),('AV13-2',1,2),('AV14-2',1,2),('AV15-2',1,2),('AV16-2',1,2),('AV17-2',1,2),('AV18-2',1,2),('AV19-2',1,2),('AV20-2',1,2),
('AV21-2',1,2),('AV22-2',1,2),('AV23-2',1,2),('AV24-2',1,2),('AV25-2',1,2),('AV26-2',1,2),('AV27-2',1,2),('AV28-2',1,2),('AV29-2',1,2),('AV30-2',1,2),

('AV1-4',1,4),('AV2-4',1,4),('AV3-4',1,4),('AV4-4',1,4),('AV5-4',1,4),('AV6-4',1,4),('AV7-4',1,4),('AV8-4',1,4),('AV9-4',1,4),('AV10-4',1,4),
('AV11-4',1,4),('AV12-4',1,4),('AV13-4',1,4),('AV14-4',1,4),('AV15-4',1,4),('AV16-4',1,4),('AV17-4',1,4),('AV18-4',1,4),('AV19-4',1,4),('AV20-4',1,4),
('AV21-4',1,4),('AV22-4',1,4),('AV23-4',1,4),('AV24-4',1,4),('AV25-4',1,4),('AV26-4',1,4),('AV27-4',1,4),('AV28-4',1,4),('AV29-4',1,4),('AV30-4',1,4),

('AV1-6',1,6),('AV2-6',1,6),('AV3-6',1,6),('AV4-6',1,6),('AV5-6',1,6),('AV6-6',1,6),('AV7-6',1,6),('AV8-6',1,6),('AV9-6',1,6),('AV10-6',1,6),
('AV11-6',1,6),('AV12-6',1,6),('AV13-6',1,6),('AV14-6',1,6),('AV15-6',1,6),('AV16-6',1,6),('AV17-6',1,6),('AV18-6',1,6),('AV19-6',1,6),('AV20-6',1,6),
('AV21-6',1,6),('AV22-6',1,6),('AV23-6',1,6),('AV24-6',1,6),('AV25-6',1,6),('AV26-6',1,6),('AV27-6',1,6),('AV28-6',1,6),('AV29-6',1,6),('AV30-6',1,6),

('AV1-8',1,8),('AV2-8',1,8),('AV3-8',1,8),('AV4-8',1,8),('AV5-8',1,8),('AV6-8',1,8),('AV7-8',1,8),('AV8-8',1,8),('AV9-8',1,8),('AV10-8',1,8),
('AV11-8',1,8),('AV12-8',1,8),('AV13-8',1,8),('AV14-8',1,8),('AV15-8',1,8),('AV16-8',1,8),('AV17-8',1,8),('AV18-8',1,8),('AV19-8',1,8),('AV20-8',1,8),
('AV21-8',1,8),('AV22-8',1,8),('AV23-8',1,8),('AV24-8',1,8),('AV25-8',1,8),('AV26-8',1,8),('AV27-8',1,8),('AV28-8',1,8),('AV29-8',1,8),('AV30-8',1,8),

('AV1-10',1,10),('AV2-10',1,10),('AV3-10',1,10),('AV4-10',1,10),('AV5-10',1,10),('AV6-10',1,10),('AV7-10',1,10),('AV8-10',1,10),('AV9-10',1,10),('AV10-10',1,10),
('AV11-10',1,10),('AV12-10',1,10),('AV13-10',1,10),('AV14-10',1,10),('AV15-10',1,10),('AV16-10',1,10),('AV17-10',1,10),('AV18-10',1,10),('AV19-10',1,10),('AV20-10',1,10),
('AV21-10',1,10),('AV22-10',1,10),('AV23-10',1,10),('AV24-10',1,10),('AV25-10',1,10),('AV26-10',1,10),('AV27-10',1,10),('AV28-10',1,10),('AV29-10',1,10),('AV30-10',1,10),

('A1-2',2,2),('A2-2',2,2),('A3-2',2,2),('A4-2',2,2),('A5-2',2,2),('A6-2',2,2),('A7-2',2,2),('A8-2',2,2),('A9-2',2,2),('A10-2',2,2),
('A11-2',2,2),('A12-2',2,2),('A13-2',2,2),('A14-2',2,2),('A15-2',2,2),('A16-2',2,2),('A17-2',2,2),('A18-2',2,2),('A19-2',2,2),('A20-2',2,2),
('A21-2',2,2),('A22-2',2,2),('A23-2',2,2),('A24-2',2,2),('A25-2',2,2),('A26-2',2,2),('A27-2',2,2),('A28-2',2,2),('A29-2',2,2),('A30-2',2,2),

('A1-4',2,4),('A2-4',2,4),('A3-4',2,4),('A4-4',2,4),('A5-4',2,4),('A6-4',2,4),('A7-4',2,4),('A8-4',2,4),('A9-4',2,4),('A10-4',2,4),
('A11-4',2,4),('A12-4',2,4),('A13-4',2,4),('A14-4',2,4),('A15-4',2,4),('A16-4',2,4),('A17-4',2,4),('A18-4',2,4),('A19-4',2,4),('A20-4',2,4),
('A21-4',2,4),('A22-4',2,4),('A23-4',2,4),('A24-4',2,4),('A25-4',2,4),('A26-4',2,4),('A27-4',2,4),('A28-4',2,4),('A29-4',2,4),('A30-4',2,4),

('A1-6',2,6),('A2-6',2,6),('A3-6',2,6),('A4-6',2,6),('A5-6',2,6),('A6-6',2,6),('A7-6',2,6),('A8-6',2,6),('A9-6',1,6),('A10-6',1,6),
('A11-6',2,6),('A12-6',2,6),('A13-6',2,6),('A14-6',2,6),('A15-6',2,6),('A16-6',2,6),('A17-6',2,6),('A18-6',2,6),('A19-6',1,6),('A20-6',1,6),
('A21-6',2,6),('A22-6',2,6),('A23-6',2,6),('A24-6',2,6),('A25-6',2,6),('A26-6',2,6),('A27-6',2,6),('A28-6',2,6),('A29-6',1,6),('A30-6',1,6),

('A1-8',2,8),('A2-8',2,8),('A3-8',2,8),('A4-8',2,8),('A5-8',2,8),('A6-8',2,8),('A7-8',2,8),('A8-8',2,8),('A9-8',2,8),('A10-8',2,8),
('A11-8',2,8),('A12-8',2,8),('A13-8',2,8),('A14-8',2,8),('A15-8',2,8),('A16-8',2,8),('A17-8',2,8),('A18-8',2,8),('A19-8',2,8),('A20-8',2,8),
('A21-8',2,8),('A22-8',2,8),('A23-8',2,8),('A24-8',2,8),('A25-8',2,8),('A26-8',2,8),('A27-8',2,8),('A28-8',2,8),('A29-8',2,8),('A30-8',2,8),

('A1-10',2,10),('A2-10',2,10),('A3-10',2,10),('A4-10',2,10),('A5-10',2,10),('A6-10',2,10),('A7-10',2,10),('A8-10',2,10),('A9-10',2,10),('A10-10',2,10),
('A11-10',2,10),('A12-10',2,10),('A13-10',2,10),('A14-10',2,10),('A15-10',2,10),('A16-10',2,10),('A17-10',2,10),('A18-10',2,10),('A19-10',2,10),('A20-10',2,10),
('A21-10',2,10),('A22-10',2,10),('A23-10',2,10),('A24-10',2,10),('A25-10',2,10),('A26-10',2,10),('A27-10',2,10),('A28-10',2,10),('A29-10',2,10),('A30-10',2,10)

INSERT INTO LOAIMON VALUES
(N'Khai vị'),
(N'Món chính'),
(N'Tráng miệng'),
(N'Nước uống');


INSERT INTO MONAN VALUES
(1,N'Súp bí đỏ Đà Lạt',N'SupBiDo.jpg',59000,N'đ'),
(1,N'Súp kem nấm đặc biệt',N'SupKemNam.jpg',59000,N'đ'),
(1,N'Vẹm xanh sốt Tomyum',N'VemXanhSotTomyum.jpg',95000,N'đ'),
(1,N'Quesaddilas 4 loại phô mai',N'Quesadillas4LoaiPhoMai.jpg',99000,N'đ'),
(1,N'Mai cua Farci đút lò phủ phô mai',N'MaiCuaFarciDutLoPhuPhoMai.jpg',135000,N'đ'),
(1,N'Cua lột sốt chanh dây',N'CuaLotSotChanhDay.jpg',135000,N'đ'),
(1,N'Sò điệp hoàng gia',N'SoDiepHoangGia.jpg',159000,N'đ'),
(1,N'Gan ngỗng Pháp',N'GanNgongPhap.jpg',209000,N'đ'),
(1,N'Hàu sống sốt Tabasco',N'HauSongSotTabasco.jpg',79000,N'đ'),
(1,N'Hàu nướng bơ tỏi',N'HauNuongBoToi.jpg',79000,N'đ'),
(1,N'Hàu nướng phô mai tan chảy',N'HauNuongPhoMaiTanChay.jpg',95000,N'đ'),
(1,N'Tôm tươi Cocktail',N'TomTuoiCocktail.jpg',85000,N'đ'),
(1,N'Tôm nướng bơ tỏi',N'TomNuongBoToi.jpg',79000,N'đ'),
(1,N'Tôm nướng phô mai',N'TomNuongPhoMai.png',95000,N'đ'),
(1,N'Nachos bò bằm phô mai',N'NachosBoBamPhoMai.png',89000,N'đ'),
(1,N'Mực chiên giòn',N'MucChienGio.jpg',99000,N'đ'),
(1,N'Cánh gà sốt BBQ',N'CanhGaBBQ.jpg',85000,N'đ'),
(2,N'Sườn cừu sốt Mint',N'SuonCuuSotMint.png',289000,N'đ'),
(2,N'Cá hồi Na Uy sốt Tariyaki',N'CaHoiNaUySotTariyaki.webp',200000,N'đ'),
(2,N'Sườn heo BBQ',N'SuonHeoSotBBQ.jpg',159000,N'đ'),
(2,N'Ức vịt sốt cam',N'UcVitSotCam.jpg',149000,N'đ'),
(2,N'Gà sốt Tariyaki',N'GaoSotTariyaki.jpg',129000,N'đ'),
(2,N'Cá chẽm sốt Tomyum',N'CaChemSotTomyum.jpg',139000,N'đ'),
(3,N'Sữa chua chanh dây',N'SuaChuaChanhDay.jpg',39000,N'đ'),
(3,N'Creme Brulée',N'CremeBrulee.gif',39000,N'đ'),
(3,N'Kem Tươi',N'KemTuoi.jpg',35000,N'đ'),
(3,N'Pana Cota',N'PanaCota.png',39000,N'đ'),
(4,N'Nước ép cam',N'NuocEpCam.jpg',49000,N'đ'),
(4,N'Nước ép dứa',N'NuocEpDua.jpg',39000,N'đ'),
(4,N'Nước ép chanh dây',N'NuocEpChanhDay.jpg',45000,N'đ'),
(4,N'Nước chanh đá',N'NuocChanhDa.jpg',29000,N'đ'),
(4,N'Nước suối',N'NuocSuoi.jpg',10000,N'đ'),
(4,N'Trà đào cam sả',N'TraDaoCamSa.jpg',49000,N'đ'),
(4,N'Trà gừng',N'TraGung.png',39000,N'đ');

INSERT INTO CHITIETDATBAN VALUES
(N'ce881356-2173-45e6-8bc5-3f6e1b1baa50','AV1-2','2023-04-15','2023-04-20 09:00:00','2023-04-20 11:00:00'),
(N'ce881356-2173-45e6-8bc5-3f6e1b1baa50','AV2-2','2023-04-15','2023-04-20 09:00:00','2023-04-20 11:00:00'),
(N'02b52178-9bf3-4477-a4e5-ec36adc8692c','AV1-4','2023-04-16','2023-04-20 19:00:00','2023-04-20 21:00:00'),
(N'02b52178-9bf3-4477-a4e5-ec36adc8692c','AV2-4','2023-04-16','2023-04-20 19:00:00','2023-04-20 21:00:00');

INSERT INTO CHITIETDATMONAN VALUES
(N'ce881356-2173-45e6-8bc5-3f6e1b1baa50',1,4,'2023-04-15'),
(N'ce881356-2173-45e6-8bc5-3f6e1b1baa50',18,4,'2023-04-15'),
(N'ce881356-2173-45e6-8bc5-3f6e1b1baa50',24,4,'2023-04-15'),
(N'ce881356-2173-45e6-8bc5-3f6e1b1baa50',32,4,'2023-04-15'),
(N'02b52178-9bf3-4477-a4e5-ec36adc8692c',2,8,'2023-04-15'),
(N'02b52178-9bf3-4477-a4e5-ec36adc8692c',19,8,'2023-04-15'),
(N'02b52178-9bf3-4477-a4e5-ec36adc8692c',25,8,'2023-04-15'),
(N'02b52178-9bf3-4477-a4e5-ec36adc8692c',31,8,'2023-04-15');

INSERT INTO HOADON VALUES
(N'ce881356-2173-45e6-8bc5-3f6e1b1baa50','2023-04-15',1632000,816000),
(N'02b52178-9bf3-4477-a4e5-ec36adc8692c','2023-04-15',3016000,1508000);
