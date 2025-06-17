using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class StockPointTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    private const string StockPoint1Code = "P1";
    private const string StockPoint2Code = "P2";

    private bool isWarehouseActivated = true;
    
    [TestInitialize]
    public async Task Test_StockPoint_CRUD_Init()
    {
        isWarehouseActivated = (await FortnoxClient.TenantConnector.GetAsync()).WarehouseActivated;
        if (isWarehouseActivated)
        {
            var stockPoint1 = await FortnoxClient.StockPointConnector.QueryAsync(StockPoint1Code);
            if (stockPoint1.Any())
            {
                try
                {
                    await FortnoxClient.StockPointConnector.DeleteAsync(stockPoint1.First().Id);
                }
                catch (FortnoxApiException ex) when (ex.ErrorInfo.Error == "missing.rights")
                {
                    // Happens if the authorized user doesn't have warehouse access rights
                }
            }

            var stockPoint2 = await FortnoxClient.StockPointConnector.QueryAsync(StockPoint2Code);
            if (stockPoint2.Any())
            {
                try
                {
                    await FortnoxClient.StockPointConnector.DeleteAsync(stockPoint2.First().Id);
                }
                catch (FortnoxApiException ex) when (ex.ErrorInfo.Error == "missing.rights")
                {
                    // Happens if the authorized user doesn't have warehouse access rights
                }
            }
        }
    }
    
    [TestMethod]
    public async Task Test_StockPoint_CRUD()
    {
        if (!isWarehouseActivated)
            Assert.Inconclusive("Warehouse has not been activated on tenant, cannot run tests.");

        try
        {
            var connector = FortnoxClient.StockPointConnector;

            #region CREATE

            var stockPoint1 = await connector.CreateAsync(new StockPoint { Name = "Point1", Active = true, Code = StockPoint1Code, StockLocations = [] });
            var stockPoint2 = await connector.CreateAsync(new StockPoint { Name = "Point2", Active = false, Code = StockPoint2Code, StockLocations = [] });

            #endregion CREATE

            #region READ

            var stockPoints = await connector.QueryAsync(state: StockPointState.All);
            Assert.IsTrue(stockPoints.Count >= 2);
            var stockPoint1FromQuery = stockPoints.FirstOrDefault(sp => sp.Name == "Point1");
            Assert.IsNotNull(stockPoint1FromQuery);
            Assert.IsTrue(stockPoint1FromQuery.Active);
            Assert.AreEqual(StockPoint1Code, stockPoint1FromQuery.Code);

            var stockPoint2FromQuery = stockPoints.FirstOrDefault(sp => sp.Name == "Point2");
            Assert.IsNotNull(stockPoint2FromQuery);
            Assert.IsFalse(stockPoint2FromQuery.Active);
            Assert.AreEqual(StockPoint2Code, stockPoint2FromQuery.Code);

            #endregion READ

            #region UPDATE

            stockPoint2FromQuery.Active = true;
            var stockPoint2FromUpdate = await connector.UpdateAsync(stockPoint2FromQuery);
            Assert.IsNotNull(stockPoint2FromUpdate);
            Assert.IsTrue(stockPoint2FromUpdate.Active);
            Assert.AreEqual(StockPoint2Code, stockPoint2FromUpdate.Code);

            #endregion UPDATE

            #region DELETE

            await connector.DeleteAsync(stockPoint1.Id);
            await connector.DeleteAsync(stockPoint2.Id);

            #endregion DELETE
        }
        catch (FortnoxApiException ex) when (ex.ErrorInfo.Error == "missing.rights")
        {
            Assert.Inconclusive("Authorized client does not have proper access rights to the warehouse APIs, cannot run tests.");
        }
    }
}