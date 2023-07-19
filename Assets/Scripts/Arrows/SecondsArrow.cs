using System;
using Clock;
using UnityEngine;

namespace Arrows
{
    public class SecondsArrow : Arrow
    {
        protected override float GetMyPosition()
        {
            return Clock.GetClock().CurrentTime.Seconds * 6;
        }
    }
}