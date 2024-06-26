
CREATE DATABASE [CadernetaPediatrica]
GO

USE [CadernetaPediatrica]
GO
/****** Object:  Table [dbo].[ControlePediatrio]    Script Date: 23/03/2024 19:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlePediatrio](
	[IdControlePediatrio] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [bigint] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Idade] [varchar](50) NOT NULL,
	[Peso] [decimal](6, 3) NOT NULL,
	[Estatura] [decimal](6, 3) NOT NULL,
	[PCef] [decimal](6, 3) NOT NULL,
	[IMC] [decimal](6, 3) NULL,
	[Observacoes] [varchar](500) NULL,
 CONSTRAINT [PK_ControlePediatrio] PRIMARY KEY CLUSTERED 
(
	[IdControlePediatrio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 23/03/2024 19:06:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[IdPaciente] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Peso] [decimal](6, 3) NOT NULL,
	[Estatura] [decimal](6, 3) NOT NULL,
	[PC] [decimal](6, 3) NOT NULL,
	[PT] [decimal](6, 3) NOT NULL,
	[TipoSanguineo] [varchar](50) NOT NULL,
	[Ictericia] [bit] NOT NULL,
	[ReflexoVermelho] [varchar](50) NULL,
	[TestePezinho] [varchar](50) NULL,
	[TriagemAuditiva] [varchar](50) NULL,
	[Observacoes] [varchar](500) NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[IdPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ControlePediatrio]  WITH CHECK ADD  CONSTRAINT [FK_ControlePediatrio_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[ControlePediatrio] CHECK CONSTRAINT [FK_ControlePediatrio_Paciente]
GO
