using System.Threading.Tasks;
using Fortnox.SDK.Entities;

namespace Fortnox.SDK.Interfaces;

public interface IProfileConnector : IEntityConnector
{
    public Task<Profile> GetAsync();
}
