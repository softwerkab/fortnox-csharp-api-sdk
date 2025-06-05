using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

public enum StockPointState
{
    [EnumMember(Value = "ALL")]
    All,
    
    [EnumMember(Value = "ACTIVE")]
    Active,
    
    [EnumMember(Value = "INACTIVE")]
    Inactive
}

/// <remarks/>
public interface IStockPointConnector : IEntityConnector
{
    Task<StockPoint> GetAsync(string id);
    Task<IList<StockPoint>> QueryAsync(string codeOrName = null, StockPointState state = StockPointState.All);
    Task<StockPoint> UpdateAsync(StockPoint stockPoint);
    Task<StockPoint> CreateAsync(StockPoint stockPoint);
    Task DeleteAsync(string id);
}