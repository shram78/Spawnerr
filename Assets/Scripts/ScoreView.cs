using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreView : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _PlayerLivesText;
   [SerializeField] private TextMeshProUGUI _EnemyKilledText;

   private void Start()
   {
      _EnemyKilledText.text = $"Killed : ";
   }

   public void ShowPlayerLives(int lives)
   {
      _PlayerLivesText.text = $"Lives : {lives}";
   }

   public void ShowEnemyKilled(int  killed)
   {
      _EnemyKilledText.text = $"Killed : {killed}";
   }
}
