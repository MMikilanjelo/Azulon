using System.Collections.Generic;
using System.Linq;
using Application.State_Machine.Application_State_Machine.States.Gameplay_State.Models.Food_Model.Strategy;

namespace Application.State_Machine.Application_State_Machine.States.Gameplay_State.Use_Cases.Resolve_Grid_Use_Case
{
    public class GridResolutionResult
    {
        public IReadOnlyList<CellResolutionResult> CellResults { get; }
        
        public int TotalGold { get; }

        public GridResolutionResult(IReadOnlyList<CellResolutionResult> cellResults)
        {
            CellResults = cellResults;
            TotalGold = cellResults.Sum(c => c.Gold);
        }
    }
}