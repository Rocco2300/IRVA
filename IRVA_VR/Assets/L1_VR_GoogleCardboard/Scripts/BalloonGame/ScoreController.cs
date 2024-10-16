using L1_VR_GoogleCardboard.Scripts.Helpers;
using TMPro;
using UnityEngine;

namespace L1_VR_GoogleCardboard.Scripts.BalloonGame
{
    /// <summary>
    /// Used to keep track of the game score & update a world space UI canvas.
    /// </summary>
    public class ScoreController : Singleton<ScoreController>
    {
       [SerializeField] private TextMeshProUGUI scoreText;

       private int score = 0;
       
       public void IncrementScore()
       {
           score += 1;
           scoreText.text = $"{score}";
       }

       public void DecrementScore()
       {
           score -= 1;
           if (score < 0)
           {
               score = 0;
           }
           
           scoreText.text = $"{score}";
       }
    }
}