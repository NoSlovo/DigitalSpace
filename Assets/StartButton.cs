using UnityEngine;

public class StartButton : MonoBehaviour
{
   [SerializeField] private Timer _timer;
   public void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out Player _player))
      {
         _timer.StartTimer();
      }
   }
}
