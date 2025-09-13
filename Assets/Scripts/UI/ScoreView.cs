using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _playerLivesText;
   [SerializeField] private TextMeshProUGUI _enemyKilledText;
   [SerializeField] private TextMeshProUGUI _currentWaveText;
   [SerializeField] private TextMeshProUGUI _enemyAliveText;
   [SerializeField] private TextMeshProUGUI _infoBeforeNewWave;

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

   public void SetInfoBeforeNewWave(int wave)
   {
      _infoBeforeNewWave.gameObject.SetActive(true);
      
      _infoBeforeNewWave.text = $"Be ready to wave : {wave}";
   }

   public void HideInfoBeforeNewWave()
   {
      _infoBeforeNewWave.gameObject.SetActive(false);
   }
   
   public void SetMainUI()
   {
      _playerLivesText.gameObject.SetActive(true);
      _enemyKilledText.gameObject.SetActive(true);
      _currentWaveText.gameObject.SetActive(true);
      _enemyAliveText.gameObject.SetActive(true);
   }

   public void HideMainUI()
   {
      _playerLivesText.gameObject.SetActive(false);
      _enemyKilledText.gameObject.SetActive(false);
      _currentWaveText.gameObject.SetActive(false);
      _enemyAliveText.gameObject.SetActive(false);
   }
}
