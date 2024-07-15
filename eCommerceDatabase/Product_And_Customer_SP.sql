-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.PRODUCT_AND_CUSTOMER_SALES
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT TOP 10
	P.[Id] as ProductId,
	COUNT(Distinct P.[Id]) AS ProductCount,
	SUM(BI.Quantity) ProductSales,
	C.Id AS CustomerId,
	COUNT(Distinct C.[Id]) AS CustomerCount

	FROM Baskets AS B
	-- I did not get time to use the invoice tables as planned for the SP, hence I had to use the BasketItems to simulate it instead
	INNER JOIN BasketItems AS BI ON B.Id = BI.BasketId
	INNER JOIN Products AS P ON BI.ProductId = P.Id
	INNER JOIN Customers AS C ON B.CustomerId = C.Id

	WHERE B.ModifiedDate >= DATEADD(MONTH, -3, GETDATE())
	GROUP BY P.[Id], C.[Id], BI.Quantity
	ORDER BY BI.Quantity DESC
END
GO
