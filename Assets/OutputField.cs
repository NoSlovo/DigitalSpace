using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _raceIndex;
    [SerializeField] private TextMeshProUGUI _raceValue;

    private float _result = 0;
    
    public float Result => _result;
    
    public void Active(bool activeObject)
    {
        gameObject.SetActive(activeObject);
    }
    
    public void SetIndex(int index)
    {
        _raceIndex.text = $"№{index}";
    }

    public void SetValue(float result)
    {
        _raceValue.text = $"{result:0.00}";
        _result = result;
    }
}
