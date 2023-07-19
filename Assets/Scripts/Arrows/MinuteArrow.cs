using UnityEngine;

namespace Arrows
{
    public class MinuteArrow : Arrow
    {
        protected override float GetMyPosition()
        {
            return Clock.GetClock().CurrentTime.Minutes * 6;
        }
    }
}