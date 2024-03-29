USE [bankauyg2022]
GO
/****** Object:  Table [dbo].[Banka_Rapor]    Script Date: 4.06.2023 23:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banka_Rapor](
	[Gelen] [int] NOT NULL,
	[Giden] [int] NOT NULL,
	[Toplam] [int] NOT NULL,
	[Tarih] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hesap_Islemleri]    Script Date: 4.06.2023 23:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hesap_Islemleri](
	[no] [int] NOT NULL,
	[Hesap_No] [int] NOT NULL,
	[Islem_Tur_Id] [int] NOT NULL,
	[Miktar] [decimal](18, 0) NOT NULL,
	[Alıcı_Hesap] [int] NULL,
	[Tarih] [date] NOT NULL,
 CONSTRAINT [PK_Hesap_Islemleri] PRIMARY KEY CLUSTERED 
(
	[no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hesaplar]    Script Date: 4.06.2023 23:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hesaplar](
	[Hesap_Id] [int] NOT NULL,
	[Bakiye] [int] NULL,
	[Kullanılabilir_bakiye] [int] NULL,
	[Musteri_No] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Hesap_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Islem_Turler]    Script Date: 4.06.2023 23:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Islem_Turler](
	[Id] [int] NOT NULL,
	[Islem] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullaniciler]    Script Date: 4.06.2023 23:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullaniciler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Kullanıcı_Adı] [varchar](50) NOT NULL,
	[Isim] [nvarchar](50) NOT NULL,
	[Sifre] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 4.06.2023 23:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[no] [int] IDENTITY(1,1) NOT NULL,
	[Isim_Soyisim] [varchar](50) NOT NULL,
	[Telefon] [nvarchar](15) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Adress] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Musteriler] PRIMARY KEY CLUSTERED 
(
	[no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (15500, 15000, 500, CAST(N'2021-09-17' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (20000, 0, 20000, CAST(N'2021-09-18' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (30000, 20000, 10000, CAST(N'2021-09-19' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (60000, 40000, 60000, CAST(N'2021-09-20' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (75000, 5000, 70000, CAST(N'2021-09-21' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (6000, 5500, 1500, CAST(N'2021-10-10' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (0, 0, 0, CAST(N'2022-08-08' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (0, 0, 0, CAST(N'2022-08-09' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (10, 5, 5, CAST(N'2022-08-10' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (20, 15, 5, CAST(N'2022-08-11' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (50, 10, 40, CAST(N'2022-08-12' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (0, 0, 0, CAST(N'2022-08-13' AS Date))
INSERT [dbo].[Banka_Rapor] ([Gelen], [Giden], [Toplam], [Tarih]) VALUES (0, 0, 0, CAST(N'2022-08-14' AS Date))
GO
INSERT [dbo].[Hesaplar] ([Hesap_Id], [Bakiye], [Kullanılabilir_bakiye], [Musteri_No]) VALUES (5, 100000, 1200, 1)
INSERT [dbo].[Hesaplar] ([Hesap_Id], [Bakiye], [Kullanılabilir_bakiye], [Musteri_No]) VALUES (698, 75, 1500, 2)
INSERT [dbo].[Hesaplar] ([Hesap_Id], [Bakiye], [Kullanılabilir_bakiye], [Musteri_No]) VALUES (1545, 750, 1200, 1)
INSERT [dbo].[Hesaplar] ([Hesap_Id], [Bakiye], [Kullanılabilir_bakiye], [Musteri_No]) VALUES (6988, 0, 1200, 2)
INSERT [dbo].[Hesaplar] ([Hesap_Id], [Bakiye], [Kullanılabilir_bakiye], [Musteri_No]) VALUES (10052, 1200, 350, 67)
GO
INSERT [dbo].[Islem_Turler] ([Id], [Islem]) VALUES (1, N'PARA YATIR')
INSERT [dbo].[Islem_Turler] ([Id], [Islem]) VALUES (2, N'PARA ÇEK')
INSERT [dbo].[Islem_Turler] ([Id], [Islem]) VALUES (3, N'Hesap Havale')
GO
SET IDENTITY_INSERT [dbo].[Kullaniciler] ON 

INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (110, N'kemal2828 ', N'Kemal', N'282828', N'kemall@gmail.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10055, N'ahmet123 ', N'Ahmet', N'19031903', N'ahmet123@gmail.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10057, N'mehmet4589 ', N'Mehmet', N'789654', N'mehmet4589@gmail.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10062, N'yunus4141 ', N'Yunus', N'414141', N'yunus4141@gmail.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10063, N'ebubkr34', N'ebubekir çayan', N'343434', N'007ebubekir@gmail.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10064, N'sefa ', N'Sefa', N'654122', N'sefacelik@gmail.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10065, N'orhanbaba', N'orhan', N'19701980', N'orhnbaba@gmail.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10066, N'yıldırımenes', N'mehmetyıldırım', N'123456', N'mehmetey.y@gmail.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10067, N'smyo', N'smyo', N'smyo', N'smyo@edu.tr.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10068, N'smyo', N'smyo', N'smyo', N'smyo.smyo@edu.tr.com')
INSERT [dbo].[Kullaniciler] ([id], [Kullanıcı_Adı], [Isim], [Sifre], [Email]) VALUES (10073, N'smyo1', N'smyo1', N'smyo1', N'smyo1.smyo@edu.tr.com')
SET IDENTITY_INSERT [dbo].[Kullaniciler] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteriler] ON 

INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (1, N'Mehmet', N'558965858', N'mehmet@gmail.com', N'Ankara/ERYAMAN')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (2, N'ahmet', N'558965858', N'ahmet@gmail.com', N'İstanbul/ÜSKÜDAR')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (3, N'ebubekir', N'545734', N'ebubekir.cyn@gmail.com', N'KOCAELİ/DARICA-MAHALLE')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (11, N'bekir ÇAYAN', N'(145) 741-2785', N'bek34rgmai@lcom.com', N'kocaelidarıcamahalle')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (60, N'Ahmet Rüzgar', N'0', N'ahmetr@gmail.com', N'İstanbulPendik')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (62, N'safsdfsdf', N'asdasda11111s', N'as1111dasd', N'asdasdas')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (64, N'Isim_Soyisim', N'Telefon', N'Email', N'Adress')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (65, N'EBUBEKİRCAYAN', N'05458745211', N'ebubekir.123@gmail.com', N'KOCAELİ/Darıca-Mahalle')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (66, N'asdfvghjk azsdfgh', N'(545) 555-2253', N'asdgasfdgf@gmai.com', N'asdfghj')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (67, N'mustafa bardak', N'(545) 444-4477', N'mustbardak@gmai.com', N'wertyuıopğasdfghjklş')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (69, N'muhammet şahin', N'(545) 444-4445', N'mhmtsahinn@gmai.com', N'wertyuıopğasdfghjklş')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (70, N'ali kartal', N'(545) 788-2626', N'aliikartal@gmai.com', N'asdfghjkjnbvcxdrtyujklş')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (71, N'murat yüzyirmidört', N'(432) 345-6799', N'murat124mr@gmai.com', N'asdfghjkl')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (73, N'bekir ÇAYAN', N'(545) 741-2784', N'bekrrgmail@com .com', N'kocaelidarıcamahalle')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (75, N'bekir ÇAYAN', N'(145) 741-2784', N'bekr3rgmai@lcom.com', N'kocaelidarıcamahalle')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (77, N'müslüm gürses', N'(532) 532-0101', N'mülümbaba1@gmai.com', N'mdmdmdkssllaşaşdşş mah mmdmdm sok no12 daire 5 ')
INSERT [dbo].[Musteriler] ([no], [Isim_Soyisim], [Telefon], [Email], [Adress]) VALUES (78, N'can erdem', N'(542) 973-5544', N'jhjhhjhjhj@hotmail.com', N'jyfyfgy mh')
SET IDENTITY_INSERT [dbo].[Musteriler] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uq_email]    Script Date: 4.06.2023 23:29:54 ******/
ALTER TABLE [dbo].[Kullaniciler] ADD  CONSTRAINT [Uq_email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uq_Musteri_email]    Script Date: 4.06.2023 23:29:54 ******/
ALTER TABLE [dbo].[Musteriler] ADD  CONSTRAINT [uq_Musteri_email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Musteriler_Email]    Script Date: 4.06.2023 23:29:54 ******/
ALTER TABLE [dbo].[Musteriler] ADD  CONSTRAINT [UQ_Musteriler_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hesap_Islemleri] ADD  CONSTRAINT [DF_Hesap_Islemleri_Alıcı_Hesap]  DEFAULT (NULL) FOR [Alıcı_Hesap]
GO
ALTER TABLE [dbo].[Hesap_Islemleri] ADD  CONSTRAINT [DF_Hesap_Islemleri_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[Hesaplar] ADD  DEFAULT ((0)) FOR [Bakiye]
GO
ALTER TABLE [dbo].[Hesaplar] ADD  DEFAULT ((1100)) FOR [Kullanılabilir_bakiye]
GO
ALTER TABLE [dbo].[Hesap_Islemleri]  WITH CHECK ADD  CONSTRAINT [FKHesap_Islemleri_Hesap_Alıcı_Hesap] FOREIGN KEY([Alıcı_Hesap])
REFERENCES [dbo].[Hesaplar] ([Hesap_Id])
GO
ALTER TABLE [dbo].[Hesap_Islemleri] CHECK CONSTRAINT [FKHesap_Islemleri_Hesap_Alıcı_Hesap]
GO
ALTER TABLE [dbo].[Hesap_Islemleri]  WITH CHECK ADD  CONSTRAINT [FKHesap_Islemleri_Hesap_Hesap_No] FOREIGN KEY([Hesap_No])
REFERENCES [dbo].[Hesaplar] ([Hesap_Id])
GO
ALTER TABLE [dbo].[Hesap_Islemleri] CHECK CONSTRAINT [FKHesap_Islemleri_Hesap_Hesap_No]
GO
ALTER TABLE [dbo].[Hesap_Islemleri]  WITH CHECK ADD  CONSTRAINT [FKHesap_Islemleri_Islem_Tur] FOREIGN KEY([Islem_Tur_Id])
REFERENCES [dbo].[Islem_Turler] ([Id])
GO
ALTER TABLE [dbo].[Hesap_Islemleri] CHECK CONSTRAINT [FKHesap_Islemleri_Islem_Tur]
GO
ALTER TABLE [dbo].[Hesaplar]  WITH CHECK ADD  CONSTRAINT [FK_Hesaplar_Musteriler] FOREIGN KEY([Musteri_No])
REFERENCES [dbo].[Musteriler] ([no])
GO
ALTER TABLE [dbo].[Hesaplar] CHECK CONSTRAINT [FK_Hesaplar_Musteriler]
GO
