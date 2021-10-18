using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ILabelConnector : IEntityConnector
    {
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Label Update(Label label);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Label Create(Label label);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<Label> Find(LabelSearch searchSettings);

        Task<Label> UpdateAsync(Label label);
        Task<Label> CreateAsync(Label label);
        Task DeleteAsync(long? id);
        Task<EntityCollection<Label>> FindAsync(LabelSearch searchSettings);
    }
}
