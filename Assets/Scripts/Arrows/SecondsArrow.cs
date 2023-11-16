using System;
using Clock;
using UnityEngine;

namespace Arrows
{
    public class SecondsArrow : Arrow
    {
        public override float GetScale()
        {
            return 1f;
        }

        protected override float GetMyPosition()
        {
            return Clock.GetClock().CurrentTime.Seconds * 6;
        }
    }
}