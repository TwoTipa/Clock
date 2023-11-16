using UnityEngine;

namespace Arrows
{
    public class MinuteArrow : Arrow
    {
        public override float GetScale()
        {
            return 60f;
        }

        protected override float GetMyPosition()
        {
            return Clock.GetClock().CurrentTime.Minutes * 6;
        }
    }
}