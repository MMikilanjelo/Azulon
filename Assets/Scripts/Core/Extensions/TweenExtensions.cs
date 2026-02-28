using DG.Tweening;

namespace Core.Extensions
{
    public static class TweenExtensions
    {
        public static void KillIfActive(this Tween tween, bool complete = false)
        {
            if (tween != null && tween.IsActive())
            {
                tween.Kill(complete);
            }
        }
    }
}