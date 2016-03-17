using System.Collections.Generic;

namespace FortnoxAPILibrary.Connectors {
    /// <remarks/>
    public class LabelConnector : EntityConnector<Label, Labels, Sort.By.Label> {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string Id { get; set; }

        /// <remarks/>
        public LabelConnector() {
            base.Resource = "labels";
        }

        /// <summary>
        /// Gets a Label by ID
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public Label Get(string labelId) {
            return base.BaseGet(labelId);
        }

        /// <summary>
        /// Updates a label
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public Label Update(Label label) {
            return base.BaseUpdate(label, label.Id);
        }

        /// <summary>
        /// Create a new label
        /// </summary>
        /// <param name="label">The label entity to create</param>
        /// <returns>The created label.</returns>
        public Label Create(Label label) {
            return base.BaseCreate(label);
        }

        /// <summary>
        /// Delete a label
        /// </summary>
        /// <param name="labelid">The label id to delete</param>
        /// <returns>If the label was deleted. </returns>
        public void Delete(string labelid) {
            base.BaseDelete(labelid);
        }

        /// <summary>
        /// Gets a list of labels
        /// </summary>
        /// <returns>A list of labels</returns>
        public Labels Find() {
            return base.BaseFind();
        }
    }
}
