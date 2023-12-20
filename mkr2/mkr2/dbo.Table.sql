CREATE TABLE [dbo].[Students]
(
    [surname] NCHAR(10) NOT NULL, 
    [faculty] NCHAR(10) NULL, 
    [curse] NCHAR(10) NULL, 
    [genre] NCHAR(10) NULL, 
    [scholarship] NCHAR(10) NULL, 
    [grade1] NCHAR(10) NULL, 
    [grade2] NCHAR(10) NULL, 
    [grade3] NCHAR(10) NULL, 
    CONSTRAINT [PK_Students] PRIMARY KEY ([surname])
)
