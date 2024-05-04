CREATE PROCEDURE GetSalesDataByFilter
    @CategoryFilter NVARCHAR(50) = NULL,
    @RegionFilter NVARCHAR(50) = NULL,
    @StartDate DATE = NULL,
    @EndDate Date = NULL,
	@PageNumber INT = 1,  
    @PageSize INT = 10 
AS
BEGIN
-- Disables the message that shows the number of rows affected
    SET NOCOUNT ON;

    WITH SalesData AS (
        SELECT
            p.Name as ProductName,
            pc.Name as ProductCategory,
            s.Name as Territory,
            SUM(sod.LineTotal) as TotalSales,
			soh.OrderDate as OrderDate
        FROM Sales.SalesOrderHeader soh
        JOIN Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID
        JOIN Production.Product p ON sod.ProductID = p.ProductID
        JOIN Production.ProductSubcategory psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
        JOIN Production.ProductCategory pc ON psc.ProductCategoryID = pc.ProductCategoryID
        JOIN Sales.SalesTerritory s ON soh.TerritoryID = s.TerritoryID
        WHERE (@StartDate IS NULL OR soh.OrderDate>=@StartDate)
        AND  (@EndDate IS NULL OR soh.OrderDate<=@EndDate)
        GROUP BY p.Name, pc.Name, S.Name, soh.OrderDate
    ),
    TotalSalesByCategoryRegion AS (
        SELECT
            ProductName,
            ProductCategory,
            Territory,
            TotalSales,
            SUM(TotalSales) OVER (PARTITION BY ProductCategory, Territory) as TotalSalesByCategoryAndRegion,
            SUM(TotalSales) OVER (PARTITION BY Territory) as TotalSalesByRegion,
			OrderDate
        FROM SalesData
    ),
    PercentageContribution AS (
        SELECT
            ProductName,
            ProductCategory,
            Territory,
            TotalSales,
            (TotalSales / TotalSalesByCategoryAndRegion) * 100 as PercentContributionByCategoryAndRegion,
            (TotalSales / TotalSalesByRegion) * 100 as PercentContributionByRegion,
			OrderDate
        FROM TotalSalesByCategoryRegion
    ),
	FinalResult AS (
	  SELECT
        ProductName,
        ProductCategory,
        TotalSales,
        PercentContributionByCategoryAndRegion,
        PercentContributionByRegion,
		OrderDate
    FROM PercentageContribution
    WHERE (@CategoryFilter IS NULL OR ProductCategory LIKE '%' + @CategoryFilter + '%')
      AND (@RegionFilter IS NULL OR Territory LIKE '%' + @RegionFilter + '%'))
	 SELECT * FROM (
        SELECT
            ROW_NUMBER() OVER (ORDER BY ProductCategory, PercentContributionByRegion, OrderDate DESC) as RowNum,
            *
        FROM FinalResult
    ) AS Pagination
    WHERE RowNum BETWEEN (@PageNumber - 1) * @PageSize + 1 AND @PageNumber * @PageSize
END

--DROP PROCEDURE GetSalesDataByFilter;
GO

EXEC GetSalesDataByFilter @CategoryFilter = 'Components', @RegionFilter = 'Germany',
      @PageNumber = 2, @PageSize = 50;	

GO

CREATE PROCEDURE SalesByEmployee (
    @StartDate DATE = NULL,
    @EndDate Date = NULL,
    @Employee NVARCHAR(50) = NULL,
    @Product NVARCHAR(50) = NULL,
    @PageNumber INT = 1,  
    @PageSize INT = 10 
)
AS
BEGIN
-- Disables the message that shows the number of rows affected
    SET NOCOUNT ON;

    WITH salesCTE AS (
        SELECT
            c.FirstName + ' ' + c.LastName AS EmployeeName,
            psc.Name AS CategoryName,
            p.Name AS ProductName,
            so.SalesOrderID,
            so.OrderDate,
            sod.UnitPrice,
            sod.OrderQty,
            sod.UnitPrice * sod.OrderQty AS TotalPrice,
            sa.AddressLine1
        FROM
            Sales.SalesOrderHeader so
        INNER JOIN
            Sales.SalesOrderDetail sod ON so.SalesOrderID = sod.SalesOrderID
        INNER JOIN
            Production.Product p ON sod.ProductID = p.ProductID
        INNER JOIN
            Production.ProductSubcategory psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
        INNER JOIN
            Sales.SalesPerson sp ON so.SalesPersonID = sp.BusinessEntityID
        INNER JOIN
            HumanResources.Employee e ON sp.BusinessEntityID = e.BusinessEntityID
        INNER JOIN Person.Person c ON e.BusinessEntityID = c.BusinessEntityID
        INNER JOIN
            Person.Address sa ON so.BillToAddressID = sa.AddressID
    ), SalesSummary AS (
        SELECT
            EmployeeName,
            CategoryName,
            ProductName,
            COUNT(SalesOrderID) AS SalesCount,
            AVG(UnitPrice) AS AvgUnitPrice,
            SUM(TotalPrice) AS TotalSales,
            MIN(OrderDate) AS FirstSaleDate,
            MAX(OrderDate) AS LastSaleDate,
            ROW_NUMBER() OVER (ORDER BY SUM(TotalPrice) DESC, EmployeeName, CategoryName, ProductName) AS RowNumber
        FROM
            salesCTE
        WHERE
            (@StartDate IS NULL OR OrderDate >= @StartDate)
            AND (@EndDate IS NULL OR OrderDate <= @EndDate)
            AND (@Employee IS NULL OR EmployeeName LIKE '%' + @Employee + '%')
            AND (@Product IS NULL OR ProductName LIKE '%' + @Product + '%')
        GROUP BY
            EmployeeName,
            CategoryName,
            ProductName
    )
    SELECT *
    FROM SalesSummary
    WHERE RowNumber BETWEEN (@PageNumber - 1) * @PageSize + 1 AND @PageNumber * @PageSize;
END;
GO

EXEC SalesByEmployee @Employee = "David Campbell", @StartDate='01-01-2012', @EndDate = '12-31-2012', @PageNumber = 1, @PageSize = 100;
EXEC SalesByEmployee @Employee = "David Campbell", @StartDate='01-01-2012', @EndDate = '01-01-2012';


--DROP PROCEDURE SalesByEmployee;
--GO