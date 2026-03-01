using UnityEngine;

namespace UI.UI_Root.View
{
    public class UIRootView : MonoBehaviour
    {
        [field: SerializeField] public RectTransform ScreenContainer { get; set; }

        [field: SerializeField] public RectTransform OverlayContainer { get; set; }

        [field: SerializeField] public RectTransform GameplayUIContainer { get; set; }
    }
}