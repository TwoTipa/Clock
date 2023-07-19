using UnityEngine;

namespace Arrows
{
    public class MinuteArrow : Arrow
    {
        protected override float GetMyPosition()
        {
            return Clock.CurrentTime.Minutes * 6;
        }
    }
}