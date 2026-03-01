using UnityEngine;
using UnityEngine.UI;

namespace UI.Gameplay_State_UI.Views
{
    public class BoardView : MonoBehaviour
    {
        [field: SerializeField] public LayoutGroup GridLayoutGroup { get; private set; }
    }
}