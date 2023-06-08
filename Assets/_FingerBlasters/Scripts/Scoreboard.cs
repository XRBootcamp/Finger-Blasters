using TMPro;
using UnityEngine;

namespace _FingerBlasters.Scripts
{
    public class Scoreboard : MonoBehaviour
    {
        public int score = 0;


        void Start()
        {
            GetComponent<TMP_Text>().text = "Score: " + score.ToString();
        }
        void Update()
        {
            Debug.Log("Score: " + score);
            GetComponent<TMP_Text>().text = "Score: " + score.ToString();
        }
    
    }
}

