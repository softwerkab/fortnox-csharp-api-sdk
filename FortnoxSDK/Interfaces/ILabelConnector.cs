using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ILabelConnector : IEntityConnector
{
    Task<Label> UpdateAsync(Label label);
    Task<Label> CreateAsync(Label label);
    Task DeleteAsync(long? id);
    Task<EntityCollection<Label>> FindAsync(LabelSearch searchSettings);
}