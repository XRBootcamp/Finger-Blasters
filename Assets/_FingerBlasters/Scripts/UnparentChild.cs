using System.Collections.Generic;
using UnityEngine;

namespace _FingerBlasters.Scripts
{
    public class UnparentChild : MonoBehaviour
    {
        [SerializeField] private List<Transform> children;

        public void Adoption()
        {
            // Unparent the child object
            foreach (var child in children)
            {
                child.SetParent(null);
            }
        }
    }
}

