IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'AppContext-2025')
BEGIN
    CREATE DATABASE [AppContext-2025];
END
GO

USE [AppContext-2025]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aktualnosc]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aktualnosc](
	[IdAktualnosci] [int] IDENTITY(1,1) NOT NULL,
	[LinkTytul] [nvarchar](10) NOT NULL,
	[Tytul] [nvarchar](50) NOT NULL,
	[Tresc] [nvarchar](max) NOT NULL,
	[Pozycja] [int] NOT NULL,
 CONSTRAINT [PK_Aktualnosc] PRIMARY KEY CLUSTERED 
(
	[IdAktualnosci] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[AutorID] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [nvarchar](50) NOT NULL,
	[Nazwisko] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[AutorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DaneKontaktowe]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaneKontaktowe](
	[UzytkownikID] [int] NOT NULL,
	[Adres] [nvarchar](100) NULL,
	[KodPocztowy] [nvarchar](10) NULL,
	[Miasto] [nvarchar](50) NULL,
	[Telefon] [nvarchar](20) NULL,
 CONSTRAINT [PK_DaneKontaktowe] PRIMARY KEY CLUSTERED 
(
	[UzytkownikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FooterItem]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FooterItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_FooterItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategoria]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoria](
	[KategoriaID] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](500) NULL,
 CONSTRAINT [PK_Kategoria] PRIMARY KEY CLUSTERED 
(
	[KategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ksiazka]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ksiazka](
	[KsiazkaID] [int] IDENTITY(1,1) NOT NULL,
	[Tytul] [nvarchar](200) NOT NULL,
	[ISBN] [nvarchar](20) NOT NULL,
	[Cena] [decimal](18, 2) NOT NULL,
	[AutorID] [int] NOT NULL,
	[WydawnictwoID] [int] NOT NULL,
	[KategoriaID] [int] NOT NULL,
	[DataWydania] [datetime2](7) NULL,
	[OkladkaUrl] [nvarchar](max) NULL,
	[Opis] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Ksiazka] PRIMARY KEY CLUSTERED 
(
	[KsiazkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kupon]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kupon](
	[KuponID] [int] IDENTITY(1,1) NOT NULL,
	[Kod] [nvarchar](20) NOT NULL,
	[TypZnizki] [int] NOT NULL,
	[WartoscZnizki] [decimal](18, 2) NOT NULL,
	[DataWaznosci] [datetime2](7) NOT NULL,
	[MinimalnaWartosc] [decimal](18, 2) NULL,
	[CzyAktywny] [bit] NOT NULL,
 CONSTRAINT [PK_Kupon] PRIMARY KEY CLUSTERED 
(
	[KuponID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recenzja]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recenzja](
	[RecenzjaID] [int] IDENTITY(1,1) NOT NULL,
	[Ocena] [int] NOT NULL,
	[Tresc] [nvarchar](1000) NOT NULL,
	[DataDodania] [datetime2](7) NOT NULL,
	[KsiazkaID] [int] NOT NULL,
	[UzytkownikID] [int] NOT NULL,
 CONSTRAINT [PK_Recenzja] PRIMARY KEY CLUSTERED 
(
	[RecenzjaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sponsor]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sponsor](
	[SponsorID] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](200) NOT NULL,
	[Opis] [nvarchar](1000) NULL,
	[LogoUrl] [nvarchar](max) NULL,
	[DataRozpoczeciaWspolpracy] [datetime2](7) NULL,
	[DataZakonczeniaWspolpracy] [datetime2](7) NULL,
 CONSTRAINT [PK_Sponsor] PRIMARY KEY CLUSTERED 
(
	[SponsorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Strona]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Strona](
	[IdStrony] [int] IDENTITY(1,1) NOT NULL,
	[LinkTytul] [nvarchar](10) NOT NULL,
	[Tytul] [nvarchar](50) NOT NULL,
	[Tresc] [nvarchar](max) NOT NULL,
	[Pozycja] [int] NOT NULL,
 CONSTRAINT [PK_Strona] PRIMARY KEY CLUSTERED 
(
	[IdStrony] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrescStrony]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrescStrony](
	[TrescStronyID] [int] IDENTITY(1,1) NOT NULL,
	[Klucz] [nvarchar](100) NOT NULL,
	[Wartosc] [nvarchar](max) NOT NULL,
	[DataModyfikacji] [datetime2](7) NOT NULL,
	[KtoZmienil] [nvarchar](max) NULL,
 CONSTRAINT [PK_TrescStrony] PRIMARY KEY CLUSTERED 
(
	[TrescStronyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uzytkownik]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uzytkownik](
	[UzytkownikID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[HasloHash] [nvarchar](max) NOT NULL,
	[Imie] [nvarchar](max) NULL,
	[Nazwisko] [nvarchar](max) NULL,
	[CzyAdmin] [bit] NOT NULL,
	[DataRejestracji] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Uzytkownik] PRIMARY KEY CLUSTERED 
(
	[UzytkownikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wydawnictwo]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wydawnictwo](
	[WydawnictwoID] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](100) NOT NULL,
	[Opis] [nvarchar](500) NULL,
 CONSTRAINT [PK_Wydawnictwo] PRIMARY KEY CLUSTERED 
(
	[WydawnictwoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zamowienie]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zamowienie](
	[ZamowienieID] [int] IDENTITY(1,1) NOT NULL,
	[DataZamowienia] [datetime2](7) NOT NULL,
	[UzytkownikID] [int] NOT NULL,
	[KuponID] [int] NULL,
	[AdresDostawy] [nvarchar](200) NULL,
	[KwotaCalkowita] [decimal](18, 2) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Zamowienie] PRIMARY KEY CLUSTERED 
(
	[ZamowienieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZamowienieKsiazka]    Script Date: 07.06.2025 07:34:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZamowienieKsiazka](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ZamowienieID] [int] NOT NULL,
	[KsiazkaID] [int] NOT NULL,
	[Ilosc] [int] NOT NULL,
	[CenaJednostkowa] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ZamowienieKsiazka] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250509123038_M1', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250602141917_M2', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250603003740_M3', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250603004327_M4', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250603004546_M5', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250603015018_M6', N'8.0.11')
GO
SET IDENTITY_INSERT [dbo].[Aktualnosc] ON 

INSERT [dbo].[Aktualnosc] ([IdAktualnosci], [LinkTytul], [Tytul], [Tresc], [Pozycja]) VALUES (1, N'A1', N'Aktualność 1', N'Nowe książki w ofercie!', 1)
INSERT [dbo].[Aktualnosc] ([IdAktualnosci], [LinkTytul], [Tytul], [Tresc], [Pozycja]) VALUES (2, N'A2', N'Aktualność 2', N'Nowe funkcje w systemie!', 2)
INSERT [dbo].[Aktualnosc] ([IdAktualnosci], [LinkTytul], [Tytul], [Tresc], [Pozycja]) VALUES (3, N'A3', N'Aktualność 3', N'Zmiany w polityce prywatności.', 3)
SET IDENTITY_INSERT [dbo].[Aktualnosc] OFF
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([AutorID], [Imie], [Nazwisko]) VALUES (4, N'Anthony', N'Burgess')
INSERT [dbo].[Autor] ([AutorID], [Imie], [Nazwisko]) VALUES (5, N'Jane', N'Austen')
INSERT [dbo].[Autor] ([AutorID], [Imie], [Nazwisko]) VALUES (6, N'John', N'Steinbeck')
INSERT [dbo].[Autor] ([AutorID], [Imie], [Nazwisko]) VALUES (7, N'Bret Easton', N'Ellis')
INSERT [dbo].[Autor] ([AutorID], [Imie], [Nazwisko]) VALUES (8, N'Aldous', N'Huxley')
INSERT [dbo].[Autor] ([AutorID], [Imie], [Nazwisko]) VALUES (9, N'K. A.', N'Applegate')
INSERT [dbo].[Autor] ([AutorID], [Imie], [Nazwisko]) VALUES (10, N'Ray', N'Bradbury')
INSERT [dbo].[Autor] ([AutorID], [Imie], [Nazwisko]) VALUES (11, N'David', N'Sedaris')
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
INSERT [dbo].[DaneKontaktowe] ([UzytkownikID], [Adres], [KodPocztowy], [Miasto], [Telefon]) VALUES (1, N'Adres 123', N'123123', N'Nowy Sącz', N'12314567')
GO
SET IDENTITY_INSERT [dbo].[FooterItem] ON 

INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (1, N'Footer.Header1', N'Pobierz aplikację', 1)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (2, N'Footer.SubHeader1', N'Pobierz aplikację na Androida i iOS', 2)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (3, N'Footer.Image1.Url', N'/content/footerLogo1.png', 3)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (4, N'Footer.Image1.Alt', N'marka6', 4)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (5, N'Footer.Image2.Url', N'/content/footerLogo2.png', 5)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (6, N'Footer.Image2.Alt', N'marka6', 6)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (7, N'Footer.Header2', N'Użyteczne linki', 7)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (8, N'Footer.Link1.Text', N'Kupony', 8)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (9, N'Footer.Link1.Url', N'#', 9)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (10, N'Footer.Link2.Text', N'Polityka zwrotów', 10)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (11, N'Footer.Link2.Url', N'#', 11)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (12, N'Footer.Link3.Text', N'Dołącz do programu partnerskiego', 12)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (13, N'Footer.Link3.Url', N'#', 13)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (14, N'Footer.Header3', N'Śledź nas', 14)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (15, N'Footer.Social1.Text', N'Facebook', 15)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (16, N'Footer.Social1.Url', N'#', 16)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (17, N'Footer.Social2.Text', N'Twitter', 17)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (18, N'Footer.Social2.Url', N'#', 18)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (19, N'Footer.Social3.Text', N'Instagram', 19)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (20, N'Footer.Social3.Url', N'#', 20)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (21, N'Footer.Social4.Text', N'YouTube', 21)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (22, N'Footer.Social4.Url', N'#', 22)
INSERT [dbo].[FooterItem] ([Id], [Key], [Content], [Order]) VALUES (23, N'Footer.Copyright', N'© 2025 BookShop, Inc', 23)
SET IDENTITY_INSERT [dbo].[FooterItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Kategoria] ON 

INSERT [dbo].[Kategoria] ([KategoriaID], [Nazwa], [Opis]) VALUES (3, N'Kryminały', N'Zanurz się w mroczne zagadki, nieoczywiste zwroty akcji i śledztwa, które trzymają w napięciu do ostatniej strony.')
INSERT [dbo].[Kategoria] ([KategoriaID], [Nazwa], [Opis]) VALUES (4, N'Historyczne', N'Przenieś się w czasie i poznaj wydarzenia, które ukształtowały świat — od starożytności po XX wiek.')
INSERT [dbo].[Kategoria] ([KategoriaID], [Nazwa], [Opis]) VALUES (5, N'Przygodowe', N'Wyrusz w niezapomnianą podróż pełną niebezpieczeństw, tajemnic i niespodziewanych spotkań.')
INSERT [dbo].[Kategoria] ([KategoriaID], [Nazwa], [Opis]) VALUES (6, N'Fantastyka', N'Odkryj światy pełne magii, legendarnych bohaterów i walk dobra ze złem w epickich opowieściach.')
SET IDENTITY_INSERT [dbo].[Kategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Ksiazka] ON 

INSERT [dbo].[Ksiazka] ([KsiazkaID], [Tytul], [ISBN], [Cena], [AutorID], [WydawnictwoID], [KategoriaID], [DataWydania], [OkladkaUrl], [Opis]) VALUES (5, N'Pride and Prejudice', N'978-3-16-148410-0', CAST(40.00 AS Decimal(18, 2)), 5, 1, 5, CAST(N'1813-01-28T18:26:00.0000000' AS DateTime2), N'https://www.papertrue.com/blog/wp-content/uploads/2023/11/1prideandprejudice.jpg', N'The beautiful peacock feathers all across the cover look very enchanting. Illustrated by Hugh Thomson, this cover is one of the many popular book covers designed for this book. The peacock can be seen admiring his flock of feathers proudly. This edition of the book was published in 1894.')
INSERT [dbo].[Ksiazka] ([KsiazkaID], [Tytul], [ISBN], [Cena], [AutorID], [WydawnictwoID], [KategoriaID], [DataWydania], [OkladkaUrl], [Opis]) VALUES (6, N'A Clockwork Orange', N'918-3-16-141410-0', CAST(45.00 AS Decimal(18, 2)), 4, 1, 6, CAST(N'1962-06-22T18:30:00.0000000' AS DateTime2), N'https://www.papertrue.com/blog/wp-content/uploads/2023/11/2A-Clockwork-Orange-Book-Cover-368x600-1.jpg', N'Published in 1962, this book cover announces the movie tie-up with the book. Penguin UK’s first edition of the novel introduced the iconic ‘cog-eyed droog’ book cover, which has since become a widely recognized and famous design. The designer did a clever thing by using a cog as an eye, which cleverly connects to both clockwork and the main character Alex. It went on to become one of the best book covers of all time.')
INSERT [dbo].[Ksiazka] ([KsiazkaID], [Tytul], [ISBN], [Cena], [AutorID], [WydawnictwoID], [KategoriaID], [DataWydania], [OkladkaUrl], [Opis]) VALUES (7, N'The Grapes of Wrath', N'642-3-16-148320-1', CAST(42.00 AS Decimal(18, 2)), 6, 1, 4, CAST(N'1939-04-14T16:34:00.0000000' AS DateTime2), N'https://www.papertrue.com/blog/wp-content/uploads/2023/11/3px-The_Grapes_of_Wrath_1939_1st_ed_cover.jpg', N'The cover of this Pulitzer Prize-winning novel depicts the main characters of the story, the Joad family, and how they have to leave their home in search of work. The book cover design showcases themes of the novel like human dignity, injustice, and the strength of community. The cover also represents the challenging times of the Great Depression.')
INSERT [dbo].[Ksiazka] ([KsiazkaID], [Tytul], [ISBN], [Cena], [AutorID], [WydawnictwoID], [KategoriaID], [DataWydania], [OkladkaUrl], [Opis]) VALUES (8, N'American Psycho', N'955-2-11-131410-0', CAST(45.00 AS Decimal(18, 2)), 7, 1, 3, CAST(N'1991-03-06T18:36:00.0000000' AS DateTime2), N'https://www.papertrue.com/blog/wp-content/uploads/2023/11/4american-psycho-670x1024-1.jpg', N'The book cover art of this 1991-published book was based on a painting by American illustrator and artist Marshall Arisman, who made the book cover himself. The cover is a haunting representation of Patrick Bateman who is shown without eyes, also depicting a lack of conscience.')
INSERT [dbo].[Ksiazka] ([KsiazkaID], [Tytul], [ISBN], [Cena], [AutorID], [WydawnictwoID], [KategoriaID], [DataWydania], [OkladkaUrl], [Opis]) VALUES (9, N'Brave New World', N'331-8-11-148410-0', CAST(39.00 AS Decimal(18, 2)), 8, 1, 5, CAST(N'1932-02-04T15:52:00.0000000' AS DateTime2), N'https://www.papertrue.com/blog/wp-content/uploads/2023/11/5bravenewworld.jpg', N'A dystopian novel published in 1932, the story is based on a world where people live in a superficial state of happiness. Being one of the best book cover designs, it portrays the aspects of dystopia and technology in the storyline. A peculiar globe can be seen on the cover to represent the futuristic world written in the book.')
INSERT [dbo].[Ksiazka] ([KsiazkaID], [Tytul], [ISBN], [Cena], [AutorID], [WydawnictwoID], [KategoriaID], [DataWydania], [OkladkaUrl], [Opis]) VALUES (10, N'Animorphs – The Stranger', N'442-3-16-182220-1', CAST(40.00 AS Decimal(18, 2)), 9, 1, 6, CAST(N'1997-04-15T18:30:00.0000000' AS DateTime2), N'https://www.papertrue.com/blog/wp-content/uploads/2023/11/6Animorphs.jpg', N'This well-known fantasy series revolves around 5 humans, the Animorphs, who can turn into any animal they touch. David Mattingly, the artist behind Animorph book covers used a special editing software from the early ’90s, Elastic Reality, to transform children into animals to make captivating book cover art.  ')
INSERT [dbo].[Ksiazka] ([KsiazkaID], [Tytul], [ISBN], [Cena], [AutorID], [WydawnictwoID], [KategoriaID], [DataWydania], [OkladkaUrl], [Opis]) VALUES (11, N'Fahrenheit 451', N'726-3-12-182310-0', CAST(45.00 AS Decimal(18, 2)), 10, 1, 4, CAST(N'1953-09-19T17:33:00.0000000' AS DateTime2), N'https://www.papertrue.com/blog/wp-content/uploads/2023/11/7F451.jpg', N'The first cover of this novel published in 1953 was illustrated by Joseph Mugnaini. The cover shows the main character, Guy Montag who burns down houses in which books have been found as a job. The book cover symbolizes fire and paper which are prevailing elements of the story.')
INSERT [dbo].[Ksiazka] ([KsiazkaID], [Tytul], [ISBN], [Cena], [AutorID], [WydawnictwoID], [KategoriaID], [DataWydania], [OkladkaUrl], [Opis]) VALUES (12, N'When You Are Engulfed in Flames', N'921-7-12-158320-1', CAST(40.00 AS Decimal(18, 2)), 11, 1, 3, CAST(N'2008-06-03T19:31:00.0000000' AS DateTime2), N'https://www.papertrue.com/blog/wp-content/uploads/2023/11/8engulfedinflames.jpg', N'The cover shows a literal skeleton smoking a cigarette. It represents the title that comes from a tourist advice card, author Sedaris discovers in Japan, where he’d gone to quit smoking. The first-edition cover was designed by Chip Kidd and features a painting by Vincent van Gogh.')
SET IDENTITY_INSERT [dbo].[Ksiazka] OFF
GO
SET IDENTITY_INSERT [dbo].[Kupon] ON 

INSERT [dbo].[Kupon] ([KuponID], [Kod], [TypZnizki], [WartoscZnizki], [DataWaznosci], [MinimalnaWartosc], [CzyAktywny]) VALUES (3, N'192361', 1, CAST(10.00 AS Decimal(18, 2)), CAST(N'2025-06-30T00:00:00.0000000' AS DateTime2), CAST(100.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Kupon] OFF
GO
SET IDENTITY_INSERT [dbo].[Recenzja] ON 

INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (5, 5, N'Wciągająca od pierwszej strony. Świetnie napisana, z genialnym zakończeniem. Polecam każdemu miłośnikowi thrillerów.', CAST(N'2025-06-03T00:33:00.0000000' AS DateTime2), 5, 1)
INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (6, 4, N'Bardzo dobra książka, ciekawi bohaterowie i dobrze poprowadzona fabuła. Jedna-dwie dłużyzny, ale całość na plus.', CAST(N'2025-05-15T00:34:00.0000000' AS DateTime2), 6, 1)
INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (7, 3, N'Nie była zła, ale trochę przewidywalna. Styl pisania lekki, idealna na luźne czytanie.', CAST(N'2023-06-03T00:34:00.0000000' AS DateTime2), 7, 1)
INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (8, 2, N'Początek obiecujący, ale potem było tylko gorzej. Bohaterowie płascy, a fabuła naciągana.', CAST(N'2025-05-29T00:34:00.0000000' AS DateTime2), 8, 1)
INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (9, 1, N'Z trudem dobrnąłem do końca. Nudna, pełna banałów i bez wyrazu. Nie polecam.', CAST(N'2025-06-01T00:34:00.0000000' AS DateTime2), 9, 1)
INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (10, 5, N'Arcydzieło. Książka, która zostaje w głowie na długo po przeczytaniu. Emocjonalna, głęboka i świetnie napisana.', CAST(N'2025-05-26T00:35:00.0000000' AS DateTime2), 10, 1)
INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (11, 4, N'Fajny klimat, dobrze zbudowany świat. Mało brakowało do piątki – zakończenie było trochę zbyt szybkie.', CAST(N'2025-06-01T00:35:00.0000000' AS DateTime2), 11, 1)
INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (12, 3, N'Średnia. Momentami ciekawa, ale całości zabrakło czegoś wyjątkowego. Może młodszym czytelnikom przypadnie bardziej do gustu', CAST(N'2025-05-30T00:35:00.0000000' AS DateTime2), 12, 1)
INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (13, 4, N'Całkiem dobra książka.', CAST(N'2025-06-03T00:39:00.0000000' AS DateTime2), 5, 1)
INSERT [dbo].[Recenzja] ([RecenzjaID], [Ocena], [Tresc], [DataDodania], [KsiazkaID], [UzytkownikID]) VALUES (14, 5, N'Super książka', CAST(N'2025-06-04T00:00:00.0000000' AS DateTime2), 5, 4)
SET IDENTITY_INSERT [dbo].[Recenzja] OFF
GO
SET IDENTITY_INSERT [dbo].[Sponsor] ON 

INSERT [dbo].[Sponsor] ([SponsorID], [Nazwa], [Opis], [LogoUrl], [DataRozpoczeciaWspolpracy], [DataZakonczeniaWspolpracy]) VALUES (3, N'National Geographic', NULL, N'https://res.cloudinary.com/vistaprint/images/c_scale,w_500,h_148/f_auto,q_auto/v1719942404/ideas-and-advice-prod/blogadmin/national-geographic-logo/national-geographic-logo.png?_i=AA', NULL, NULL)
INSERT [dbo].[Sponsor] ([SponsorID], [Nazwa], [Opis], [LogoUrl], [DataRozpoczeciaWspolpracy], [DataZakonczeniaWspolpracy]) VALUES (4, N'Nike', NULL, N'https://www.pngmart.com/files/23/Nike-Sign-PNG-Clipart.png', CAST(N'2025-05-26T09:45:00.0000000' AS DateTime2), CAST(N'2025-06-30T09:45:00.0000000' AS DateTime2))
INSERT [dbo].[Sponsor] ([SponsorID], [Nazwa], [Opis], [LogoUrl], [DataRozpoczeciaWspolpracy], [DataZakonczeniaWspolpracy]) VALUES (5, N'Coca-Cola', NULL, N'https://res.cloudinary.com/vistaprint/images/c_scale,w_1048,h_342/f_auto,q_auto/v1706089184/ideas-and-advice-prod/en-us/Coca-Cola_logo.svg_/Coca-Cola_logo.svg_.png?_i=AA', NULL, NULL)
INSERT [dbo].[Sponsor] ([SponsorID], [Nazwa], [Opis], [LogoUrl], [DataRozpoczeciaWspolpracy], [DataZakonczeniaWspolpracy]) VALUES (6, N'Amazon', NULL, N'https://res.cloudinary.com/vistaprint/images/w_1024,h_309,c_scale,w_1024,h_309/f_auto,q_auto/v1719942376/ideas-and-advice-prod/blogadmin/amazon-logo/amazon-logo.png?_i=AA', NULL, NULL)
INSERT [dbo].[Sponsor] ([SponsorID], [Nazwa], [Opis], [LogoUrl], [DataRozpoczeciaWspolpracy], [DataZakonczeniaWspolpracy]) VALUES (7, N'Marvel', NULL, N'https://res.cloudinary.com/vistaprint/images/w_1024,h_412,c_scale,w_1024,h_411/f_auto,q_auto/v1719942440/ideas-and-advice-prod/blogadmin/marvel-logo/marvel-logo.png?_i=AA', NULL, NULL)
INSERT [dbo].[Sponsor] ([SponsorID], [Nazwa], [Opis], [LogoUrl], [DataRozpoczeciaWspolpracy], [DataZakonczeniaWspolpracy]) VALUES (8, N'FedEx', NULL, N'https://res.cloudinary.com/vistaprint/images/w_1024,h_287,c_scale,w_1024,h_287/f_auto,q_auto/v1719942389/ideas-and-advice-prod/blogadmin/fedex-logo/fedex-logo.png?_i=AA', NULL, NULL)
INSERT [dbo].[Sponsor] ([SponsorID], [Nazwa], [Opis], [LogoUrl], [DataRozpoczeciaWspolpracy], [DataZakonczeniaWspolpracy]) VALUES (9, N'Mastercard', NULL, N'https://res.cloudinary.com/vistaprint/images/c_scale,w_448,h_305/f_auto,q_auto/v1719961008/ideas-and-advice-prod/blogadmin/mastercard-logo-1/mastercard-logo-1.png?_i=AA', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Sponsor] OFF
GO
SET IDENTITY_INSERT [dbo].[Strona] ON 

INSERT [dbo].[Strona] ([IdStrony], [LinkTytul], [Tytul], [Tresc], [Pozycja]) VALUES (11, N'Home', N'Index', N'Strona główna treść', 1)
INSERT [dbo].[Strona] ([IdStrony], [LinkTytul], [Tytul], [Tresc], [Pozycja]) VALUES (12, N'Produkty', N'Produkty', N'Produkty treść', 2)
INSERT [dbo].[Strona] ([IdStrony], [LinkTytul], [Tytul], [Tresc], [Pozycja]) VALUES (13, N'O nas', N'ONas', N'O nas treść', 3)
INSERT [dbo].[Strona] ([IdStrony], [LinkTytul], [Tytul], [Tresc], [Pozycja]) VALUES (14, N'Kontakt', N'Kontakt', N'Kontakt treść', 4)
INSERT [dbo].[Strona] ([IdStrony], [LinkTytul], [Tytul], [Tresc], [Pozycja]) VALUES (15, N'Konto', N'Konto', N'Konto treść', 5)
SET IDENTITY_INSERT [dbo].[Strona] OFF
GO
SET IDENTITY_INSERT [dbo].[TrescStrony] ON 

INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (1, N'Sklep.Kategorie', N'Najpopularniejsze kategorie', CAST(N'2025-06-02T16:27:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (2, N'HomePage.Hero.Title', N'Tysiące historii na wyciągnięcie ręki', CAST(N'2025-06-03T01:53:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (3, N'HomePage.Hero.Description', N'Odkryj bogatą ofertę książek w każdej kategorii — od bestsellerów po niszowe perełki. Znajdziesz tu coś dla siebie, niezależnie od tego, co lubisz czytać.', CAST(N'2025-06-03T01:54:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (4, N'HomePage.Hero.ImagePath', N'~/content/mainPagePhoto.jpeg', CAST(N'2025-06-03T01:54:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (5, N'HomePage.Hero.Benefit1', N'Szeroki wybór gatunków', CAST(N'2025-06-03T02:10:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (6, N'HomePage.Hero.Benefit2', N'Szybka dostawa', CAST(N'2025-06-03T02:10:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (7, N'HomePage.Hero.Benefit3', N'Najwyższe oceny czytelników', CAST(N'2025-06-03T02:10:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (8, N'O_Nas.Header', N'O nas', CAST(N'2025-06-03T18:41:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (9, N'O_Nas.Paragraph1', N'"Od lat z pasją łączymy miłośników literatury, dostarczając nie tylko książki, lecz także inspiracje."', CAST(N'2025-06-03T18:41:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (10, N'O_Nas.Paragraph2', N'"Naszym celem jest, aby każda przeczytana strona otwierała przed Tobą nowe światy i emocje."', CAST(N'2025-06-03T18:41:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (11, N'O_Nas.Quote', N'"Książka to najcichszy i najbardziej wytrwały przyjaciel, jaki może towarzyszyć człowiekowi."', CAST(N'2025-06-03T18:42:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (12, N'O_Nas.QuoteAuthor', N'"Charles W. Eliot"', CAST(N'2025-06-03T18:42:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (13, N'O_Nas.Wartosci.PasjaDoLiteratury', N'Kochamy książki i dzielimy się tą pasją z naszymi klientami.', CAST(N'2025-06-03T18:42:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (14, N'O_Nas.Wartosci.SzybkaDostawa', N'Zamówienia realizujemy błyskawicznie – książki są u Ciebie w mgnieniu oka.', CAST(N'2025-06-03T18:42:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (15, N'O_Nas.Wartosci.ObsługaKlienta', N'Zawsze służymy pomocą – odpowiadamy szybko i konkretnie.', CAST(N'2025-06-03T18:42:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (16, N'O_Nas.Statystyki.Liczba1', N'10,000+', CAST(N'2025-06-03T18:42:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (17, N'O_Nas.Statystyki.Opis1', N'Dostępnych książek', CAST(N'2025-06-03T18:43:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (18, N'O_Nas.Statystyki.Liczba2', N'5000+', CAST(N'2025-06-03T18:43:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (19, N'O_Nas.Statystyki.Opis2', N'Zadowolonych klientów', CAST(N'2025-06-03T18:43:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (20, N'O_Nas.Statystyki.Liczba3', N'98%', CAST(N'2025-06-03T18:43:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (21, N'O_Nas.Statystyki.Opis3', N'Pozytywnych opinii', CAST(N'2025-06-03T18:43:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (22, N'O_Nas.Statystyki.Liczba4', N'3+', CAST(N'2025-06-03T18:43:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (23, N'O_Nas.Statystyki.Opis4', N'Lata działalności', CAST(N'2025-06-03T18:44:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (24, N'O_Nas.SectionValuesHeader', N'Nasze Wartości', CAST(N'2025-06-03T19:20:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (25, N'O_Nas.ContactButtonText', N'Skontaktuj się z nami', CAST(N'2025-06-03T19:20:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (26, N'Kontakt.Header', N'Skontaktuj się z nami', CAST(N'2025-06-03T19:28:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (27, N'Kontakt.Opis', N'Masz pytania? Jesteśmy tutaj, aby pomóc.', CAST(N'2025-06-03T19:28:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (28, N'Kontakt.Adres', N'Ul. Książkowa 12, 00-001 Nowy Sącz', CAST(N'2025-06-03T19:29:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (29, N'Kontakt.Email', N'kontakt@bookshop.pl', CAST(N'2025-06-03T19:29:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (30, N'Kontakt.Telefon', N'+48 123 456 789', CAST(N'2025-06-03T19:29:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (31, N'Kontakt.Godziny', N'Pon-Pt: 9:00 - 17:00, Sob: 10:00 - 14:00', CAST(N'2025-06-03T19:29:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (32, N'Kontakt.ButtonText', N'Wyślij', CAST(N'2025-06-03T19:29:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (33, N'Kontakt.MapEmbedUrl', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d41365.35783277058!2d20.66544074542774!3d49.610291306980756!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x473de53cb3f195cf%3A0x9865e0e4a3f03225!2sNowy%20S%C4%85cz!5e0!3m2!1spl!2spl!4v1746829528776!5m2!1spl!2spl', CAST(N'2025-06-03T19:30:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (34, N'Kontakt.FbLink', N'#', CAST(N'2025-06-03T19:33:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (35, N'Kontakt.InstagramLink', N'#', CAST(N'2025-06-03T19:33:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (36, N'Kontakt.TwitterLink', N'#', CAST(N'2025-06-03T19:33:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (37, N'Kontakt.HeaderDaneKontaktowe', N'Dane kontaktowe', CAST(N'2025-06-03T19:35:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (38, N'Kontakt.HeaderGodzinyOtwarcia', N'Godziny otwarcia', CAST(N'2025-06-04T17:32:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (39, N'Kontakt.HeaderZnajdzNas', N'Znajdź nas', CAST(N'2025-06-04T17:32:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (40, N'Kontakt.HeaderFormularz', N'Formularz kontaktowy', CAST(N'2025-06-04T17:32:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (41, N'Kontakt.ImieNazwiskoLabel', N'Imię i nazwisko', CAST(N'2025-06-04T17:32:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (42, N'Kontakt.EmailLabel', N'Adres e-mail', CAST(N'2025-06-04T17:33:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (43, N'Kontakt.WiadomoscLabel', N'Wiadomość', CAST(N'2025-06-04T17:33:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (44, N'faq_1_pytanie', N'Nie pamiętam hasła', CAST(N'2025-06-04T19:30:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (45, N'faq_1_odpowiedz', N'Kliknij „Zaloguj się”, a następnie „Zapomniałem hasła”.', CAST(N'2025-06-04T19:30:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (46, N'faq_2_pytanie', N'Czy rejestracja jest darmowa?', CAST(N'2025-06-04T19:30:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (47, N'faq_2_odpowiedz', N'Tak, rejestracja jest całkowicie bezpłatna.', CAST(N'2025-06-04T19:30:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (48, N'faq_3_pytanie', N'Co zyskuję po rejestracji?', CAST(N'2025-06-04T19:30:00.0000000' AS DateTime2), N'admin')
INSERT [dbo].[TrescStrony] ([TrescStronyID], [Klucz], [Wartosc], [DataModyfikacji], [KtoZmienil]) VALUES (49, N'faq_3_odpowiedz', N'Historia aktywności, dostęp do ofert, szybsze logowanie.', CAST(N'2025-06-04T19:30:00.0000000' AS DateTime2), N'admin')
SET IDENTITY_INSERT [dbo].[TrescStrony] OFF
GO
SET IDENTITY_INSERT [dbo].[Uzytkownik] ON 

INSERT [dbo].[Uzytkownik] ([UzytkownikID], [Email], [HasloHash], [Imie], [Nazwisko], [CzyAdmin], [DataRejestracji]) VALUES (1, N'adam.nowak@gmail.com', N'haslo1', N'Adam', N'Nowak', 0, CAST(N'2025-06-02T18:21:00.0000000' AS DateTime2))
INSERT [dbo].[Uzytkownik] ([UzytkownikID], [Email], [HasloHash], [Imie], [Nazwisko], [CzyAdmin], [DataRejestracji]) VALUES (4, N'kacper@email.com', N'$2a$11$3v1pmtQx9XyifItqXMRmy.LyrRobhAGy4jwuYDLr9.tYTmWLbio6q', N'Kacper', N'Kałużny', 0, CAST(N'2025-06-05T20:48:24.6740000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Uzytkownik] OFF
GO
SET IDENTITY_INSERT [dbo].[Wydawnictwo] ON 

INSERT [dbo].[Wydawnictwo] ([WydawnictwoID], [Nazwa], [Opis]) VALUES (1, N'Wydawnictwo 1', NULL)
SET IDENTITY_INSERT [dbo].[Wydawnictwo] OFF
GO
SET IDENTITY_INSERT [dbo].[Zamowienie] ON 

INSERT [dbo].[Zamowienie] ([ZamowienieID], [DataZamowienia], [UzytkownikID], [KuponID], [AdresDostawy], [KwotaCalkowita], [Status]) VALUES (2, CAST(N'2025-06-02T00:00:00.0000000' AS DateTime2), 1, 3, N'asdas', CAST(110.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Zamowienie] ([ZamowienieID], [DataZamowienia], [UzytkownikID], [KuponID], [AdresDostawy], [KwotaCalkowita], [Status]) VALUES (3, CAST(N'2025-07-05T16:33:00.0000000' AS DateTime2), 1, NULL, N'asd', CAST(111.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Zamowienie] OFF
GO
SET IDENTITY_INSERT [dbo].[ZamowienieKsiazka] ON 

INSERT [dbo].[ZamowienieKsiazka] ([Id], [ZamowienieID], [KsiazkaID], [Ilosc], [CenaJednostkowa]) VALUES (1, 2, 5, 3, CAST(40.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ZamowienieKsiazka] OFF
GO
ALTER TABLE [dbo].[Autor] ADD  DEFAULT (N'') FOR [Imie]
GO
ALTER TABLE [dbo].[Autor] ADD  DEFAULT (N'') FOR [Nazwisko]
GO
ALTER TABLE [dbo].[Kupon] ADD  DEFAULT (CONVERT([bit],(0))) FOR [CzyAktywny]
GO
ALTER TABLE [dbo].[Uzytkownik] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DataRejestracji]
GO
ALTER TABLE [dbo].[Zamowienie] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[ZamowienieKsiazka] ADD  DEFAULT ((0.0)) FOR [CenaJednostkowa]
GO
ALTER TABLE [dbo].[DaneKontaktowe]  WITH CHECK ADD  CONSTRAINT [FK_DaneKontaktowe_Uzytkownik_UzytkownikID] FOREIGN KEY([UzytkownikID])
REFERENCES [dbo].[Uzytkownik] ([UzytkownikID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DaneKontaktowe] CHECK CONSTRAINT [FK_DaneKontaktowe_Uzytkownik_UzytkownikID]
GO
ALTER TABLE [dbo].[Ksiazka]  WITH CHECK ADD  CONSTRAINT [FK_Ksiazka_Autor_AutorID] FOREIGN KEY([AutorID])
REFERENCES [dbo].[Autor] ([AutorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ksiazka] CHECK CONSTRAINT [FK_Ksiazka_Autor_AutorID]
GO
ALTER TABLE [dbo].[Ksiazka]  WITH CHECK ADD  CONSTRAINT [FK_Ksiazka_Kategoria_KategoriaID] FOREIGN KEY([KategoriaID])
REFERENCES [dbo].[Kategoria] ([KategoriaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ksiazka] CHECK CONSTRAINT [FK_Ksiazka_Kategoria_KategoriaID]
GO
ALTER TABLE [dbo].[Ksiazka]  WITH CHECK ADD  CONSTRAINT [FK_Ksiazka_Wydawnictwo_WydawnictwoID] FOREIGN KEY([WydawnictwoID])
REFERENCES [dbo].[Wydawnictwo] ([WydawnictwoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ksiazka] CHECK CONSTRAINT [FK_Ksiazka_Wydawnictwo_WydawnictwoID]
GO
ALTER TABLE [dbo].[Recenzja]  WITH CHECK ADD  CONSTRAINT [FK_Recenzja_Ksiazka_KsiazkaID] FOREIGN KEY([KsiazkaID])
REFERENCES [dbo].[Ksiazka] ([KsiazkaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recenzja] CHECK CONSTRAINT [FK_Recenzja_Ksiazka_KsiazkaID]
GO
ALTER TABLE [dbo].[Recenzja]  WITH CHECK ADD  CONSTRAINT [FK_Recenzja_Uzytkownik_UzytkownikID] FOREIGN KEY([UzytkownikID])
REFERENCES [dbo].[Uzytkownik] ([UzytkownikID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recenzja] CHECK CONSTRAINT [FK_Recenzja_Uzytkownik_UzytkownikID]
GO
ALTER TABLE [dbo].[Zamowienie]  WITH CHECK ADD  CONSTRAINT [FK_Zamowienie_Kupon_KuponID] FOREIGN KEY([KuponID])
REFERENCES [dbo].[Kupon] ([KuponID])
GO
ALTER TABLE [dbo].[Zamowienie] CHECK CONSTRAINT [FK_Zamowienie_Kupon_KuponID]
GO
ALTER TABLE [dbo].[Zamowienie]  WITH CHECK ADD  CONSTRAINT [FK_Zamowienie_Uzytkownik_UzytkownikID] FOREIGN KEY([UzytkownikID])
REFERENCES [dbo].[Uzytkownik] ([UzytkownikID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Zamowienie] CHECK CONSTRAINT [FK_Zamowienie_Uzytkownik_UzytkownikID]
GO
ALTER TABLE [dbo].[ZamowienieKsiazka]  WITH CHECK ADD  CONSTRAINT [FK_ZamowienieKsiazka_Ksiazka_KsiazkaID] FOREIGN KEY([KsiazkaID])
REFERENCES [dbo].[Ksiazka] ([KsiazkaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ZamowienieKsiazka] CHECK CONSTRAINT [FK_ZamowienieKsiazka_Ksiazka_KsiazkaID]
GO
ALTER TABLE [dbo].[ZamowienieKsiazka]  WITH CHECK ADD  CONSTRAINT [FK_ZamowienieKsiazka_Zamowienie_ZamowienieID] FOREIGN KEY([ZamowienieID])
REFERENCES [dbo].[Zamowienie] ([ZamowienieID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ZamowienieKsiazka] CHECK CONSTRAINT [FK_ZamowienieKsiazka_Zamowienie_ZamowienieID]
GO
