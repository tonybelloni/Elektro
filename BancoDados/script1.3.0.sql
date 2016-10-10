alter table [dbo].[REGISTRO_OCORRENCIAS] alter column codigo_tipo_ocorrencia int null

GO

alter table [dbo].[REGISTRO_OCORRENCIAS] add tipo_ocorrencia nvarchar(20) null

GO

alter table [dbo].[REGISTRO_OCORRENCIAS] add data_final datetime

GO

alter table [dbo].[REGISTRO_OCORRENCIAS] drop column data_ocorrencia

GO

alter table [dbo].[HISTORICOS_CAMERAS] add PRONTUARIO nvarchar(50) null

GO

alter table [dbo].[CAMERAS] add PRONTUARIO nvarchar(50) null

GO
