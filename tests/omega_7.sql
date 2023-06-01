-- omega script
USE MASTER 
GO

ALTER DATABASE ef_core_7_with_net_7
SET MULTI_USER WITH ROLLBACK IMMEDIATE
GO

ALTER DATABASE ef_core_7_with_net_7
SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

DROP DATABASE ef_core_7_with_net_7
GO

DECLARE @SqlFolder NVARCHAR(512), @BackupFolder NVARCHAR(512),
		@Mdf NVARCHAR(512),	@Ldf NVARCHAR(512), @Bak NVARCHAR(512)

SELECT @SqlFolder = CAST(SERVERPROPERTY(N'InstanceDefaultDataPath') AS NVARCHAR(512))
EXEC [master].dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'SOFTWARE\Microsoft\MSSQLServer\MSSQLServer', N'BackupDirectory', @BackupFolder OUT

SELECT @Mdf = @SqlFolder + N'ef_core_7_with_net_7.mdf'
SELECT @Ldf = @SqlFolder + N'ef_core_7_with_net_7_log.ldf'
SELECT @Bak = @BackupFolder + N'\ef_core_7_with_net_7.bak'

USE master
RESTORE DATABASE ef_core_7_with_net_7
  FROM DISK = @Bak
WITH 
  MOVE 'ef_core_7_with_net_7' TO @Mdf,
  MOVE 'ef_core_7_with_net_7_log' TO @Ldf
GO
