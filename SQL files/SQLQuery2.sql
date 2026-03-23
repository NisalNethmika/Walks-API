SELECT TOP (1000) [Id]
      ,[Code]
      ,[Name]
      ,[RegionImageURL]
  FROM [WalksDB].[dbo].[Regions]

INSERT INTO Regions (Id, Code, Name, RegionImageURL)
VALUES (NEWID(), 'AUK', 'Auckland', NULL);