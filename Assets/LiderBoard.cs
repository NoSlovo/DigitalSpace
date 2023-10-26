using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LiderBoard : MonoBehaviour
{
    [SerializeField] private List<OutputField> _outputFields;

    public void SetResultRace(float value)
    {
        for (int i = 0; i < _outputFields.Count; i++)
        {
            if (value < _outputFields[i].Result)
            {
                _outputFields[i].SetIndex(i + 1);
                _outputFields[i].SetValue(value);
                _outputFields[i].Active(true);
                break;
            }

            if (_outputFields[i].Result == 0)
            {
                _outputFields[i].SetIndex(i + 1);
                _outputFields[i].SetValue(value);
                _outputFields[i].Active(true);
                break;
            }
        }
    }
}