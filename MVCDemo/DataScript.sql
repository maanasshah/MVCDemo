USE TestDB

INSERT INTO Category
(CategoryId, CategoryName)
VALUES
(1, 'Category 1'),
(2, 'Category 2'),
(3, 'Category 3')

GO 
Select * From Category

GO

INSERT INTO [dbo].[Transaction]
(Payee, Amount, PurchaseDate, Memo, CategoryId)
VALUES
('Payee 1', 225.24, '03/24/2020', 'Memo data test', 1),
('Payee 2', 5840.56, '01/24/2020', 'Memo - free text area for any extra information.  Optional field ', 2),
('Payee 3', 789.85, '06/24/2019', 'LiteracyPro Coding Challenge Project ', 2)
