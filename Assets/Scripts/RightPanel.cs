using UnityEngine;

public class RightPanel : MonoBehaviour
{
   [SerializeField] private Timer timer;
   public void SetActive()
   {
      this.gameObject.SetActive(true);
   }
   
   public void SetActiveFalce()
   {
      timer.ResetTimer();
      this.gameObject.SetActive(false);
   }
}
