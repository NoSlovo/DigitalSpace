using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _timer;

   private float _value = 0;
   private float _defaultValue = 0;
   private bool _timeActive = true;

   public void StartTimer()
   {
      _timeActive = true;
      _value = _defaultValue;
      StartCoroutine(TimerStart());
   }
   
   private IEnumerator TimerStart()
   {
      while (_timeActive)
      {
         _value += Time.deltaTime;
         _timer.text = $"Timer:{_value:0.00}";
         yield return null;
      }
   }

   public Result StopTimer()
   {
      StopCoroutine(TimerStart());
      _timeActive = false;
      var result = new Result();
      result.ResultValue = _value;
      _value = 0;
      return result;
   }
}