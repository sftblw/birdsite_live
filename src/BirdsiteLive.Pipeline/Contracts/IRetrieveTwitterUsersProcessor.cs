using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using BirdsiteLive.DAL.Models;

namespace BirdsiteLive.Pipeline.Contracts
{
    public interface IRetrieveTwitterUsersProcessor
    {
        Task UpdateTwitterAsync(BufferBlock<SyncTwitterUser[]> twitterUsersBufferBlock, CancellationToken ct);
    }
}