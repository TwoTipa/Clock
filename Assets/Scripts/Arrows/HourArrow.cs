using UnityEngine;

namespace Arrows
{
    public class HourArrow : Arrow
    {
        protected override float GetMyPosition()
        {
            return -Clock.GetClock().CurrentTime.Hours * 3;
        }
    }
}