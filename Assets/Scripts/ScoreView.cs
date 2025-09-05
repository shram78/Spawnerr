using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _PlayerLivesText;
   [SerializeField] private TextMeshProUGUI _EnemyKilledText;

   public void ShowPlayerLives(int lives) //needs rename
   {
      _PlayerLivesText.text = $"Lives : {lives}";
   }

   public void ShowEnemyKilled(int  killed) // needs rename
   {
      _EnemyKilledText.text = $"Killed : {killed}";
   }
}
