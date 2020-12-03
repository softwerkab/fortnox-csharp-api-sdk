using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ILabelConnector : IEntityConnector
	{


		Label Update(Label label);
		Label Create(Label label);
		void Delete(long? id);
		EntityCollection<Label> Find(LabelSearch searchSettings);

		Task<Label> UpdateAsync(Label label);
		Task<Label> CreateAsync(Label label);
		Task DeleteAsync(long? id);
		Task<EntityCollection<Label>> FindAsync(LabelSearch searchSettings);
	}
}
