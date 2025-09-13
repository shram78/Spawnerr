using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tutorial : MonoBehaviour
{
   [SerializeField] private Button _fireButton;
   [SerializeField] private Image _handIcon;
   [SerializeField] private PlayerController _playerController;

   private float _distanceToMoveIcon = 200;
   private float _durationTimeToMoveIcon = 1;
   
   private void Start()
   {
      _fireButton.onClick.AddListener(OnClick);
     
      RectTransform rect = _handIcon.rectTransform;
      rect.DOAnchorPosX(rect.anchoredPosition.x + _distanceToMoveIcon, _durationTimeToMoveIcon)
         .SetEase(Ease.InOutSine)     
         .SetLoops(-1, LoopType.Yoyo); 
   }

   private void OnClick()
   {
      _playerController.GetFireButtonTutorial();
   }

   private void OnDestroy()
   {
      if (_fireButton != null)
         _fireButton.onClick.RemoveAllListeners();
   }

   public void HiddenButton()
   {
      _handIcon.gameObject.SetActive(false);
   }
}
