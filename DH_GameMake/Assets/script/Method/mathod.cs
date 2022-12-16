

namespace mathod
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public static class mathod
    {

        public static T FindComponent<T>(this GameObject gameObject, string ComponentName) where T : Component
        {
            Component child = gameObject.GetComponent(ComponentName);
            if (child == null) return null;
            return child.GetComponent<T>();
        }
    }
}


