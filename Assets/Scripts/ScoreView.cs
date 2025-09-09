using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _playerLivesText;
   [SerializeField] private TextMeshProUGUI _enemyKilledText;
   [SerializeField] private TextMeshProUGUI _currentWaveText;
   [SerializeField] private TextMeshProUGUI _enemyAliveText;

   public void SetPlayerLives(int lives) 
   {
      _playerLivesText.text = $"Lives : {lives}";
   }

   public void SetEnemyKilled(int  killed) 
   {
      _enemyKilledText.text = $"Killed : {killed}";
   }

   public void SetCurrentWave(int wave)
   {
      _currentWaveText.text = $"Wave: {wave}";
   }

   public void SetAliveEnemy(int alive)
   {
      _enemyAliveText.text = $"Needs to kill to next wave: {alive}";
   }
}
