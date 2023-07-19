using UnityEngine;

namespace Arrows
{
    public class HourArrow : Arrow
    {
        protected override float GetMyPosition()
        {
            return Clock.CurrentTime.Hours * 6;
        }
    }
}