using System;
using Clock;
using UnityEngine;

namespace Arrows
{
    public abstract class Arrow : MonoBehaviour
    {
        protected ClockTime Clock;

        private void Start()
        {
            Clock = FindClock(transform);
            Debug.Log(Clock.name);
        }

        private ClockTime FindClock(Transform obj)
        {
            Transform parent = obj.parent;
            if (!parent.TryGetComponent(typeof(ClockTime), out var ret))
            {
                ret = FindClock(parent);
            }
            return (ClockTime)ret;
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