using UnityEngine;

namespace Arrows
{
    public class HourArrow : Arrow
    {
        public override float GetScale()
        {
            return 360;
        }

        protected override float GetMyPosition()
        {
            var time = Clock.GetClock().CurrentTime;
            return (time.Hours)*30;
        }
    }
}