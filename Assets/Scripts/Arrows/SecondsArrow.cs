using System;
using Clock;
using UnityEngine;

namespace Arrows
{
    public class SecondsArrow : Arrow
    {
        protected override float GetMyPosition()
        {
            return Clock.CurrentTime.Seconds * 6;
        }
    }
}