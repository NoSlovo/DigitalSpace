using UnityEngine;

public class StartButton : MonoBehaviour
{
   [SerializeField] private Timer _timer;
   
   public void OnTriggerEnter(Collider other)
   {
      _timer.StartTimer();
   }
}
