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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Label Update(Label label);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Label Create(Label label);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<Label> Find(LabelSearch searchSettings);

		Task<Label> UpdateAsync(Label label);
		Task<Label> CreateAsync(Label label);
		Task DeleteAsync(long? id);
		Task<EntityCollection<Label>> FindAsync(LabelSearch searchSettings);
	}
}
