using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class LabelConnector : EntityConnector<Label, EntityCollection<LabelSubset>, Sort.By.Label?>
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
			return BaseUpdate(label, label.Id.ToString());
		}

		/// <summary>
		/// Creates a new label
		/// </summary>
		/// <param name="label">The label to create</param>
		/// <returns>The created label</returns>
		public Label Create(Label label)
		{
			return BaseCreate(label);
		}

		/// <summary>
		/// Deletes a label
		/// </summary>
		/// <param name="id">Identifier of the label to delete</param>
		public void Delete(int? id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of labels
		/// </summary>
		/// <returns>A list of labels</returns>
		public EntityCollection<LabelSubset> Find()
		{
			return BaseFind();
		}
	}
}
