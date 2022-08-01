using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
   [SerializeField] private Button buttonOK;

   private void Start()
   {
      buttonOK.onClick.AddListener(() => SetIsActive(false));
   }

   public void SetIsActive(bool active)
   {
      gameObject.SetActive(active);
   }
}
