using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class LabelConnector : EntityConnector<Label, EntityCollection<Label>, Sort.By.Label?>, ILabelConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Label? FilterBy { get; set; }


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
			return UpdateAsync(label).Result;
		}

		/// <summary>
		/// Creates a new label
		/// </summary>
		/// <param name="label">The label to create</param>
		/// <returns>The created label</returns>
		public Label Create(Label label)
		{
			return CreateAsync(label).Result;
		}

		/// <summary>
		/// Deletes a label
		/// </summary>
		/// <param name="id">Identifier of the label to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of labels
		/// </summary>
		/// <returns>A list of labels</returns>
		public EntityCollection<Label> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<Label>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(int? id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<Label> CreateAsync(Label label)
		{
			return await BaseCreate(label);
		}
		public async Task<Label> UpdateAsync(Label label)
		{
			return await BaseUpdate(label, label.Id.ToString());
		}
	}
}
