  CREATE TABLE Products (
    Id INT IDENTITY (1, 1) PRIMARY KEY
   ,CategoryId INT NOT NULL
   ,NAME NVARCHAR(50) NOT NULL 
   ,Description NVARCHAR(100) NOT NULL
   ,Price DECIMAL(18,2) NULL  
   ,Image NVARCHAR(25) null
  )
  
  CREATE TABLE Categories (
  Id INT IDENTITY (1, 1) PRIMARY KEY
 ,NAME NVARCHAR(50) NOT NULL
 ,Description NVARCHAR(100) NOT NULL
)


CREATE TABLE Users (

  Id INT IDENTITY (1, 1) PRIMARY KEY
 ,NAME NVARCHAR(50) NOT NULL
 ,Login NVARCHAR(10) NOT NULL
 ,Password NVARCHAR(10) NOT NULL
)

CREATE TABLE Orders (
  OrderId INT IDENTITY (1, 1) PRIMARY KEY
 ,UserId INT NOT NULL
 ,Comment NVARCHAR(100)
)


INSERT INTO Products (CategoryId, NAME, Description, Price, Image)
  VALUES (1, N'Kayak', N'Protective and fashionable', 275.00, N''),
         (1, N'Lifejacket', N'Protective and fashionable', 48.98, N''),
         (2, N'Soccer Ball', N'FIFA-approved size and weight', 19.50, N''),
         (2, N'Corner Flags', N'FIFA-approved size and weight', 34.95, N''),
         (2, N'Stadium', N'Flat-packed, 35,000-seat stadium', 75500.00, N''),
         (3, N'Thinking Cap', N'Improve your brain efficiency by 75%', 16.00, N''),
         (3, N'Unsteady Chair', N'Unsteady Chair', 29.95, N''),
         (3, N'Human Chess Board', N'A fun game for the family', 75.00, N''),
         (3, N'Bling-Bling King', N'Gold-plated, diamond-studded King',1200.00, N'')


    INSERT INTO Categories (NAME, Description)
           VALUES (N'Watersports', N''),
                  (N'Soccer', N''),
                  (N'Chess', N'')
  
  ALTER TABLE Products ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id); ?
