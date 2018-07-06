using PuzzleManagement.Core.Enums;

namespace PuzzleManagement.Core.Interfaces
{
    public interface IStateObject
    {
        ObjectState State { get; set; }
    }
}
