using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fortnox.SDK.Interfaces;

public interface IRateLimiter
{
  Task<HttpResponseMessage> Throttle(string token, Func<Task<HttpResponseMessage>> action);
}