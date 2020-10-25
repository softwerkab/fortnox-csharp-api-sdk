using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAccountChartConnector : IEntityConnector
	{
		AccountChartSearch Search { get; set; }

		EntityCollection<AccountChart> Find();

		Task<EntityCollection<AccountChart>> FindAsync();
	}
}
