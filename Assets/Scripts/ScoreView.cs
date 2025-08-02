using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _PlayerLivesText;
   [SerializeField] private TextMeshProUGUI _EnemyKilledText;

   public void ShowPlayerLives(int lives)
   {
      _PlayerLivesText.text = $"Lives : {lives}";
   }

   public void ShowEnemyKilled(int  killed)
   {
      _EnemyKilledText.text = $"Killed : {killed}";
   }
}
