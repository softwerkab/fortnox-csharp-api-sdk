using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class LabelConnector : SearchableEntityConnector<Label, Label, LabelSearch>, ILabelConnector
	{


		/// <remarks/>
		public LabelConnector()
		{
			Resource = "labels";
		}

		/// <summary>
		/// Updates a label
		/// </summary>
		/// <param name="label">The label to update</param>
		/// <returns>The updated label</returns>
		public Label Update(Label label)
		{
			return UpdateAsync(label).GetResult();
		}

		/// <summary>
		/// Creates a new label
		/// </summary>
		/// <param name="label">The label to create</param>
		/// <returns>The created label</returns>
		public Label Create(Label label)
		{
			return CreateAsync(label).GetResult();
		}

		/// <summary>
		/// Deletes a label
		/// </summary>
		/// <param name="id">Identifier of the label to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of labels
		/// </summary>
		/// <returns>A list of labels</returns>
		public EntityCollection<Label> Find(LabelSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<Label>> FindAsync(LabelSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(long? id)
		{
			await BaseDelete(id.ToString()).ConfigureAwait(false);
		}
		public async Task<Label> CreateAsync(Label label)
		{
			return await BaseCreate(label).ConfigureAwait(false);
		}
		public async Task<Label> UpdateAsync(Label label)
		{
			return await BaseUpdate(label, label.Id.ToString()).ConfigureAwait(false);
		}
	}
}
