using UnityEngine;
using UnityEngine.SceneManagement;

namespace _FingerBlasters.Scripts
{
    public class ResetScene : MonoBehaviour
    {
        public void Restart()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}