Để tách dữ liệu từ LoggingService sang LoggingService1
1. Backup LoggingService từ server 148
2. Mở SSMS, New Query và chạy lệnh SQL sau:

USE [master]
RESTORE DATABASE [LoggingService1]
FROM DISK = N'D:\SERVER FSP\databases\LoggingService.bak'
WITH FILE = 1, MOVE N'LoggingService' TO N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LoggingService1.mdf', 
    MOVE N'LoggingService_log' TO N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LoggingService1_log.ldf', NOUNLOAD, STATS = 5
GO
3. Đổi logical name từ LoggingService sang LoggingService1
ALTER DATABASE LoggingService1 MODIFY FILE (NAME = LoggingService, NEWNAME = LoggingService1)
ALTER DATABASE LoggingService1 MODIFY FILE (NAME = LoggingService_log, NEWNAME = LoggingService1_log)