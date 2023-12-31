using UnityEngine;

public class FinishButton : MonoBehaviour
{
  [SerializeField] private Timer _timer;
  [SerializeField] private LiderBoard _liderBoard;

  private void OnTriggerEnter(Collider other)
  {
    var result = _timer.StopTimer();
      
    if (result.ResultValue == 0)
      return;
    _liderBoard.SetResultRace(result.ResultValue);
  }
}
