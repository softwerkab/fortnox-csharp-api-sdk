using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class StockPointTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_StockPoint_CRUD()
    {
        var connector = FortnoxClient.StockPointConnector;

        #region CREATE
        var stockPoint1 = await connector.CreateAsync(new StockPoint { Name = "Point1", Active = true, Code = "P1", StockLocations = [new StockLocation { Code = "P1L" }] });
        var stockPoint2 = await connector.CreateAsync(new StockPoint { Name = "Point2", Active = false, Code = "P2", StockLocations = [new StockLocation { Code = "P2L" }] });
        #endregion CREATE

        #region READ
        var stockPoints = await connector.QueryAsync(state: StockPointState.All);
        Assert.IsTrue(stockPoints.Count >= 2);
        var stockPoint1FromQuery = stockPoints.FirstOrDefault(sp => sp.Name == "Point1");
        Assert.IsNotNull(stockPoint1FromQuery);
        Assert.IsTrue(stockPoint1FromQuery.Active);
        Assert.AreEqual("P1", stockPoint1FromQuery.Code);
        Assert.AreEqual(1, stockPoint1FromQuery.StockLocations.Count);
        Assert.AreEqual("P1L", stockPoint1FromQuery.StockLocations[0].Code);
        
        var stockPoint2FromQuery = stockPoints.FirstOrDefault(sp => sp.Name == "Point2");
        Assert.IsNotNull(stockPoint2FromQuery);
        Assert.IsFalse(stockPoint2FromQuery.Active);
        Assert.AreEqual("P2", stockPoint2FromQuery.Code);
        Assert.AreEqual(1, stockPoint2FromQuery.StockLocations.Count);
        Assert.AreEqual("P2L", stockPoint2FromQuery.StockLocations[0].Code);
        #endregion READ

        #region UPDATE
        stockPoint2.Active = true;
        var stockPoint2FromUpdate = await connector.UpdateAsync(stockPoint2);
        Assert.IsNotNull(stockPoint2FromUpdate);
        Assert.IsTrue(stockPoint2FromUpdate.Active);
        Assert.AreEqual("P2", stockPoint2FromUpdate.Code);
        Assert.AreEqual(1, stockPoint2FromUpdate.StockLocations.Count);
        Assert.AreEqual("P2L", stockPoint2FromUpdate.StockLocations[0].Code);
        #endregion UPDATE

        #region DELETE
        await connector.DeleteAsync(stockPoint1.Id);
        await connector.DeleteAsync(stockPoint2.Id);
        #endregion DELETE
    }
}