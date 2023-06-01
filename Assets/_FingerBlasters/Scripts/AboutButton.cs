using UnityEngine;

namespace _FingerBlasters.Scripts
{
    public class AboutButton : MonoBehaviour
    {
        public GameObject objectA;
        public GameObject objectB;

        private bool isObjectAActive = true;

        public void ToggleObjects()
        {
            if (isObjectAActive)
            {
                objectA.SetActive(false);
                objectB.SetActive(true);
                isObjectAActive = false;
            }
            else
            {
                objectA.SetActive(true);
                objectB.SetActive(false);
                isObjectAActive = true;
            }
        }
    }
}
