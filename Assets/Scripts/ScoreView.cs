using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreView : MonoBehaviour
{
   [FormerlySerializedAs("_scoreText")] [SerializeField] private TextMeshProUGUI _text;

   public void Display(int score)
   {
      _text.text = $"Score new: {score}";
   }
}
