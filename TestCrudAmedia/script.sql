USE [TestCrud]
GO
/****** Object:  Table [dbo].[tGenero]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tGenero](
	[cod_genero] [int] IDENTITY(1,1) NOT NULL,
	[txt_desc] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tGeneroPelicula]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tGeneroPelicula](
	[cod_pelicula] [int] NOT NULL,
	[cod_genero] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_pelicula] ASC,
	[cod_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPelicula]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPelicula](
	[cod_pelicula] [int] IDENTITY(1,1) NOT NULL,
	[txt_desc] [varchar](500) NULL,
	[cant_disponibles_alquiler] [int] NULL,
	[cant_disponibles_venta] [int] NULL,
	[precio_alquiler] [numeric](18, 2) NULL,
	[precio_venta] [numeric](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_pelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPeliculaAlquilada]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPeliculaAlquilada](
	[cod_pelicula_alquilada] [int] IDENTITY(1,1) NOT NULL,
	[cod_pelicula] [int] NULL,
	[cod_usuario_cliente] [int] NULL,
	[cod_usuario_creador] [int] NULL,
	[precio] [decimal](18, 2) NULL,
	[fecha_tomada] [datetime] NULL,
	[fecha_devuelta] [datetime] NULL,
	[devuelta] [int] NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_tPeliculaAlquilada] PRIMARY KEY CLUSTERED 
(
	[cod_pelicula_alquilada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPeliculaVendida]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPeliculaVendida](
	[cod_pelicula_vendida] [int] IDENTITY(1,1) NOT NULL,
	[cod_pelicula] [int] NULL,
	[cod_usuario_cliente] [int] NULL,
	[cod_usuario_creador] [int] NULL,
	[precio] [decimal](18, 2) NULL,
	[fecha] [datetime] NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_tPeliculaVendida] PRIMARY KEY CLUSTERED 
(
	[cod_pelicula_vendida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tRol]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tRol](
	[cod_rol] [int] IDENTITY(1,1) NOT NULL,
	[txt_desc] [varchar](500) NULL,
	[sn_activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tUsers]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUsers](
	[cod_usuario] [int] IDENTITY(1,1) NOT NULL,
	[txt_user] [varchar](50) NULL,
	[txt_password] [varchar](50) NULL,
	[txt_nombre] [varchar](200) NULL,
	[txt_apellido] [varchar](200) NULL,
	[nro_doc] [varchar](50) NULL,
	[cod_rol] [int] NULL,
	[sn_activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tGeneroPelicula]  WITH CHECK ADD  CONSTRAINT [fk_genero_pelicula] FOREIGN KEY([cod_pelicula])
REFERENCES [dbo].[tPelicula] ([cod_pelicula])
GO
ALTER TABLE [dbo].[tGeneroPelicula] CHECK CONSTRAINT [fk_genero_pelicula]
GO
ALTER TABLE [dbo].[tGeneroPelicula]  WITH CHECK ADD  CONSTRAINT [fk_pelicula_genero] FOREIGN KEY([cod_genero])
REFERENCES [dbo].[tGenero] ([cod_genero])
GO
ALTER TABLE [dbo].[tGeneroPelicula] CHECK CONSTRAINT [fk_pelicula_genero]
GO
ALTER TABLE [dbo].[tPeliculaAlquilada]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaAlquilada_tPelicula] FOREIGN KEY([cod_pelicula])
REFERENCES [dbo].[tPelicula] ([cod_pelicula])
GO
ALTER TABLE [dbo].[tPeliculaAlquilada] CHECK CONSTRAINT [FK_tPeliculaAlquilada_tPelicula]
GO
ALTER TABLE [dbo].[tPeliculaAlquilada]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaAlquilada_tUsersCliente] FOREIGN KEY([cod_usuario_cliente])
REFERENCES [dbo].[tUsers] ([cod_usuario])
GO
ALTER TABLE [dbo].[tPeliculaAlquilada] CHECK CONSTRAINT [FK_tPeliculaAlquilada_tUsersCliente]
GO
ALTER TABLE [dbo].[tPeliculaAlquilada]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaAlquilada_tUsersCreador] FOREIGN KEY([cod_usuario_creador])
REFERENCES [dbo].[tUsers] ([cod_usuario])
GO
ALTER TABLE [dbo].[tPeliculaAlquilada] CHECK CONSTRAINT [FK_tPeliculaAlquilada_tUsersCreador]
GO
ALTER TABLE [dbo].[tPeliculaVendida]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaVendida_tPelicula] FOREIGN KEY([cod_pelicula])
REFERENCES [dbo].[tPelicula] ([cod_pelicula])
GO
ALTER TABLE [dbo].[tPeliculaVendida] CHECK CONSTRAINT [FK_tPeliculaVendida_tPelicula]
GO
ALTER TABLE [dbo].[tPeliculaVendida]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaVendida_tUsersCliente] FOREIGN KEY([cod_usuario_cliente])
REFERENCES [dbo].[tUsers] ([cod_usuario])
GO
ALTER TABLE [dbo].[tPeliculaVendida] CHECK CONSTRAINT [FK_tPeliculaVendida_tUsersCliente]
GO
ALTER TABLE [dbo].[tPeliculaVendida]  WITH CHECK ADD  CONSTRAINT [FK_tPeliculaVendida_tUsersCreador] FOREIGN KEY([cod_usuario_creador])
REFERENCES [dbo].[tUsers] ([cod_usuario])
GO
ALTER TABLE [dbo].[tPeliculaVendida] CHECK CONSTRAINT [FK_tPeliculaVendida_tUsersCreador]
GO
ALTER TABLE [dbo].[tUsers]  WITH CHECK ADD  CONSTRAINT [fk_user_rol] FOREIGN KEY([cod_rol])
REFERENCES [dbo].[tRol] ([cod_rol])
GO
ALTER TABLE [dbo].[tUsers] CHECK CONSTRAINT [fk_user_rol]
GO
/****** Object:  StoredProcedure [dbo].[GeneroInsert]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroInsert]
(
	@cod_genero int OUTPUT,
	@txt_desc varchar(500) 
)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO tGenero (txt_desc)
    VALUES(@txt_desc)
	
	SELECT @cod_genero = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[GeneroList]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroList]
AS
BEGIN

    SELECT *
    FROM tGenero

END
GO
/****** Object:  StoredProcedure [dbo].[GeneroListByCodePelicula]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroListByCodePelicula]
(
    @cod_pelicula int
)
AS
BEGIN

    SELECT gp.cod_genero, g.txt_desc
	FROM tGeneroPelicula gp
	INNER JOIN tGenero g ON g.cod_genero = gp.cod_genero
	WHERE gp.cod_pelicula=@cod_pelicula

END
GO
/****** Object:  StoredProcedure [dbo].[GeneroPeliculaCheck]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroPeliculaCheck]
(
    @cod_pelicula int,
	@cod_genero int
)
AS
BEGIN

    SELECT gp.cod_genero, g.txt_desc
    FROM tGeneroPelicula gp
	INNER JOIN tGenero g ON g.cod_genero = gp.cod_genero
    WHERE gp.cod_pelicula=@cod_pelicula AND gp.cod_genero=@cod_genero

END
GO
/****** Object:  StoredProcedure [dbo].[GeneroPeliculaInsert]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GeneroPeliculaInsert]
(
	@cod_pelicula int ,
	@cod_genero int
)
AS
BEGIN

    INSERT INTO tGeneroPelicula (cod_pelicula, cod_genero)
    VALUES(@cod_pelicula, @cod_genero)

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaAlquiladaInsert]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaAlquiladaInsert]
(
	@cod_pelicula_alquilada int OUTPUT,
	@cod_pelicula int NULL ,
	@cod_usuario_cliente int NULL  ,
	@cod_usuario_creador int NULL  ,
	@precio decimal(18, 2) NULL ,
	@fecha_tomada datetime NULL ,
	@fecha_devuelta datetime NULL ,
	@devuelta int NULL 
)
AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO tPeliculaAlquilada (cod_pelicula, cod_usuario_cliente, cod_usuario_creador, precio, fecha_tomada, fecha_devuelta, devuelta)
    VALUES(@cod_pelicula, @cod_usuario_cliente, @cod_usuario_creador, @precio, @fecha_tomada, @fecha_devuelta, @devuelta)

	SELECT @cod_pelicula_alquilada = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaAvailableAlquilar]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaAvailableAlquilar]
AS
BEGIN

    SELECT *
    FROM tPelicula
	WHERE cant_disponibles_alquiler > 0

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaAvailableVender]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaAvailableVender]
AS
BEGIN

    SELECT *
    FROM tPelicula
	WHERE cant_disponibles_venta > 0

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaDelete]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaDelete]
(
	@cod_pelicula int
)
AS
BEGIN

    UPDATE tPelicula
        SET
        cant_disponibles_alquiler=0,
        cant_disponibles_venta=0
    WHERE cod_pelicula=@cod_pelicula

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaDevolver]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaDevolver]
(
	@cod_pelicula_alquilada int,
	@fecha_devuelta datetime ,
	@devuelta int 
)
AS
BEGIN

    UPDATE tPeliculaAlquilada
        SET
        fecha_devuelta=@fecha_devuelta,
        devuelta=@devuelta
    WHERE cod_pelicula_alquilada=@cod_pelicula_alquilada

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaGetByID]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaGetByID]
(
    @cod_pelicula int
)
AS
BEGIN

    SELECT *
    FROM tPelicula
    WHERE cod_pelicula=@cod_pelicula

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaInsert]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaInsert]
(
	@cod_pelicula int OUTPUT,
	@txt_desc varchar(500) NULL,
	@cant_disponibles_alquiler int NULL ,
	@cant_disponibles_venta int NULL ,
	@precio_alquiler numeric(18, 2) NULL ,
	@precio_venta numeric(18, 2) NULL 
)
AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO tPelicula (txt_desc, cant_disponibles_alquiler, cant_disponibles_venta, precio_alquiler, precio_venta)
    VALUES(@txt_desc, @cant_disponibles_alquiler, @cant_disponibles_venta, @precio_alquiler, @precio_venta)

	SELECT @cod_pelicula = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaList]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaList]
AS
BEGIN

    SELECT *
    FROM tPelicula

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaUpdate]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaUpdate]
(
	@cod_pelicula int,
	@txt_desc varchar(500) NULL,
	@cant_disponibles_alquiler int NULL ,
	@cant_disponibles_venta int NULL ,
	@precio_alquiler numeric(18, 2) NULL ,
	@precio_venta numeric(18, 2) NULL 
)
AS
BEGIN

    UPDATE tPelicula
        SET
        txt_desc=@txt_desc,
        cant_disponibles_alquiler=@cant_disponibles_alquiler,
        cant_disponibles_venta=@cant_disponibles_venta,
        precio_alquiler=@precio_alquiler,
        precio_venta=@precio_venta
    WHERE cod_pelicula=@cod_pelicula

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaUpdateStockAlquilada]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaUpdateStockAlquilada]
(
	@cod_pelicula int ,
	@cant_disponibles_alquiler int 
)
AS
BEGIN

    UPDATE tPelicula
        SET
        cant_disponibles_alquiler=@cant_disponibles_alquiler
    WHERE cod_pelicula=@cod_pelicula

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaUpdateStockVendida]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaUpdateStockVendida]
(
	@cod_pelicula int ,
	@cant_disponibles_venta int 
)
AS
BEGIN

    UPDATE tPelicula
        SET
        cant_disponibles_venta=@cant_disponibles_venta
    WHERE cod_pelicula=@cod_pelicula

END
GO
/****** Object:  StoredProcedure [dbo].[PeliculaVendidaInsert]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PeliculaVendidaInsert]
(
	@cod_pelicula_vendida int OUTPUT,
	@cod_pelicula int NULL ,
	@cod_usuario_cliente int NULL  ,
	@cod_usuario_creador int NULL  ,
	@precio decimal(18, 2) NULL ,
	@fecha datetime NULL 
)
AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO tPeliculaVendida (cod_pelicula, cod_usuario_cliente, cod_usuario_creador, precio, fecha)
    VALUES(@cod_pelicula, @cod_usuario_cliente, @cod_usuario_creador, @precio, @fecha)

	SELECT @cod_pelicula_vendida = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[RolGetByID]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RolGetByID]
(
    @cod_rol int
)
AS
BEGIN

    SELECT *
    FROM tRol
    WHERE cod_rol=@cod_rol

END
GO
/****** Object:  StoredProcedure [dbo].[RolList]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RolList]
AS
BEGIN

    SELECT *
    FROM tRol

END
GO
/****** Object:  StoredProcedure [dbo].[UsersDelete]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersDelete]
(
	@cod_usuario int
)
AS
BEGIN

    DELETE tusers
    WHERE cod_usuario=@cod_usuario

END
GO
/****** Object:  StoredProcedure [dbo].[UsersInsert]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersInsert]
(
	@cod_usuario int OUTPUT,
	@txt_user varchar(50) NULL,
	@txt_password varchar(50) NULL,
	@txt_nombre varchar(200) NULL ,
	@txt_apellido varchar(200) NULL ,
	@nro_doc varchar(50) NULL ,
	@cod_rol int NULL ,
	@sn_activo int NULL 
)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO tusers (txt_user, txt_password, txt_nombre, txt_apellido, nro_doc, cod_rol, sn_activo)
    VALUES(@txt_user, @txt_password, @txt_nombre, @txt_apellido, @nro_doc, @cod_rol, @sn_activo)
	
	SELECT @cod_usuario = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[UsersList]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersList]
AS
BEGIN

    SELECT *
    FROM tUsers

END
GO
/****** Object:  StoredProcedure [dbo].[UsersUpdate]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersUpdate]
(
	@cod_usuario int ,
	@txt_user varchar(50) NULL,
	@txt_password varchar(50) NULL,
	@txt_nombre varchar(200) NULL ,
	@txt_apellido varchar(200) NULL ,
	@nro_doc varchar(50) NULL ,
	@cod_rol int NULL ,
	@sn_activo int NULL 
)
AS
BEGIN

    UPDATE tusers
        SET
        txt_user=@txt_user,
        txt_password=@txt_password,
        txt_nombre=@txt_nombre,
        txt_apellido=@txt_apellido,
        nro_doc=@nro_doc,
        cod_rol=@cod_rol,
        sn_activo=@sn_activo
    WHERE cod_usuario=@cod_usuario

END
GO
/****** Object:  StoredProcedure [dbo].[UsersValidate]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersValidate]
(
    @txt_user varchar (50),
	@txt_password varchar (50) 
)
AS
BEGIN

    SELECT *
    FROM tUsers
    WHERE txt_user=@txt_user AND txt_password=@txt_password 

END
GO
/****** Object:  StoredProcedure [dbo].[UsersValidateDoc]    Script Date: 8/11/2022 5:13:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersValidateDoc]
(
    @nro_doc varchar(50)
)
AS
BEGIN

    SELECT *
    FROM tUsers
    WHERE nro_doc=@nro_doc

END
GO

/****** Object:  StoredProcedure [dbo].[UsersValidateDocUpdate]    Script Date: 8/11/2022 9:20:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE UsersValidateDocUpdate
(
    @nro_doc varchar(50),
	@cod_usuario int
)
AS
BEGIN

    SELECT *
    FROM tUsers
    WHERE nro_doc=@nro_doc AND cod_usuario != @cod_usuario

END
GO