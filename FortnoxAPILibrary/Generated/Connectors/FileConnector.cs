using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class FileConnector : EntityConnector<File, EntityCollection<FileSubset>, Sort.By.File?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.File FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Path { get; set; }

		/// <remarks/>
		public FileConnector()
		{
			Resource = "files";
		}

		/// <summary>
		/// Find a file based on filenumber
		/// </summary>
		/// <param name="fileNumber">The filenumber to find</param>
		/// <returns>The found file</returns>
		public File Get(string fileNumber)
		{
			return BaseGet(fileNumber);
		}

		/// <summary>
		/// Updates a file
		/// </summary>
		/// <param name="file">The file to update</param>
		/// <returns>The updated file</returns>
		public File Update(File file)
		{
			return BaseUpdate(file, file.FileNumber);
		}

		/// <summary>
		/// Create a new file
		/// </summary>
		/// <param name="file">The file to create</param>
		/// <returns>The created file</returns>
		public File Create(File file)
		{
			return BaseCreate(file);
		}

		/// <summary>
		/// Deletes a file
		/// </summary>
		/// <param name="fileNumber">The filenumber to delete</param>
		public void Delete(string fileNumber)
		{
			BaseDelete(fileNumber);
		}

		/// <summary>
		/// Gets a list of files
		/// </summary>
		/// <returns>A list of files</returns>
		public EntityCollection<FileSubset> Find()
		{
			return BaseFind();
		}
	}
}
