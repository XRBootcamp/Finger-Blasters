using System.Collections.Generic;
using UnityEngine;

namespace _FingerBlasters.Scripts
{
    public class DeactivateOnStart : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField] private List<GameObject> gameObjects;

        public int arrowsFired;
        void Start()
        {
            foreach(var gameObject in gameObjects)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

