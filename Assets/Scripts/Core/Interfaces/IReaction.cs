using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IReaction
    {
        bool CanReact(ITrigger trigger);
        Task React(ITrigger trigger);
    }
}