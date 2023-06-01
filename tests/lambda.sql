


--########################################################################################
--sp
DECLARE @st DATETIME, @fn DATETIME, @cn DECIMAL(18,5)
SELECT TOP(1) @st = CreatedTimeUtc
	FROM dbo.Logs
ORDER BY Id

SELECT TOP(1) @fn = CreatedTimeUtc
	FROM dbo.Logs
ORDER BY Id DESC

SELECT @cn = COUNT(*)/2
	FROM dbo.Logs

IF @cn = 0
BEGIN
	SET @cn = 1
END

SELECT CAST(DATEDIFF(MICROSECOND, @st, @fn)/@cn/1000000 AS DECIMAL(18,6))
--########################################################################################



--########################################################################################
--ssf
SELECT TOP(10000) * 
    FROM dbo.Logs
--WHERE Message LIKE N'%%'
ORDER BY Id DESC
GO
--########################################################################################



--########################################################################################
--rm
TRUNCATE TABLE dbo.Logs
GO
--########################################################################################
