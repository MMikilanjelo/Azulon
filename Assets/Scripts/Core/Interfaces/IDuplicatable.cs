
namespace Core.Interfaces
{
    public interface IDuplicable<out T> where T : notnull
    {
        T Duplicate();
    }
}