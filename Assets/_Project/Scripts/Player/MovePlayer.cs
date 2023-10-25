using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HandlerInput))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private HandlerInput _handlerInput;
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _handlerInput = GetComponent<HandlerInput>();
    }
}
