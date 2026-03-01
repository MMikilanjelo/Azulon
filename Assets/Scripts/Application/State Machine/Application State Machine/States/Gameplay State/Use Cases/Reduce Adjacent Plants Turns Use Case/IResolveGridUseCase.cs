using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Reduce_Adjacent_Plants_Turns_Use_Case
{
    public interface IResolveGridUseCase
    {
        GridResolutionResult Execute();
    }
}