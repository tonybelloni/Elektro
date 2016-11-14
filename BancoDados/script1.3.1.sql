delete from dbo.escalas_codç
GO

alter table dbo.veiculos alter column numero nvarchar(10) null
GO

alter table dbo.veiculos add observacao nvarchar(300)
GO

alter table [dbo].[ESCALA_COD] add constraint escala_cod_fk01 foreign key (sigla_equipe) references equipes (sigla_equipe)
GO

alter table [dbo].[ESCALA_COD] add constraint escala_cod_fk02 foreign key (prontuario) references funcionarios (prontuario)
GO

alter table dbo.funcionarios alter column periodo nchar(10) null
GO

alter table [dbo].[FUNCIONARIOS] alter column localidade int not null
GO

alter table [dbo].[FUNCIONARIOS] alter column supervisao int not null
GO

alter table [dbo].[FUNCIONARIOS] alter column gerencia int not null
GO

alter table [dbo].[FUNCIONARIOS] alter column regiao int not null
GO

alter table [dbo].[FUNCIONARIOS] add constraint funcionarios_fk01 foreign key (localidade) references
dbo.localidade (codigo_localidade)
GO

alter table [dbo].[FUNCIONARIOS] add constraint funcionarios_fk02 foreign key (supervisao) references
dbo.supervisao (codigo_supervisao)
GO

alter table [dbo].[FUNCIONARIOS] add constraint funcionarios_fk03 foreign key (gerencia) references
dbo.gerencia (codigo_gerencia)
GO

alter table [dbo].[FUNCIONARIOS] add constraint funcionarios_fk04 foreign key (regiao) references
dbo.regiao (codigo_regiao)
GO