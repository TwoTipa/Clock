using System;
using Clock;
using UnityEngine;

namespace Arrows
{
    public abstract class Arrow : MonoBehaviour
    {
        protected ClockBehavior Clock;

        private void Start()
        {
            Clock = FindClock(transform);
        }

        private ClockBehavior FindClock(Transform obj)
        {
            Transform parent = obj.parent;
            if (!parent.TryGetComponent(typeof(ClockBehavior), out var ret))
            {
                ret = FindClock(parent);
            }
            return (ClockBehavior)ret;
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0,0 , -GetMyPosition());
        }

        protected virtual float GetMyPosition()
        {
            return 0f;
        }
    }
}