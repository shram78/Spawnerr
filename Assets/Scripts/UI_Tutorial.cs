using UnityEngine;
using UnityEngine.UI;

public class UI_Tutorial : MonoBehaviour
{
   [SerializeField] private Button _fireButton;
   [SerializeField] private PlayerController _playerController;

   private void Start()
   {
      _fireButton.onClick.AddListener(OnClick);
   }

   private void OnClick()
   {
      _playerController.GetFireButtonTutorial();
   }
}
