using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class HandlerInput : MonoBehaviour,IInputHandelr
{
  [SerializeField] private PlayerInput _playerInput;
  
  private void Awake()=> _playerInput = GetComponent<PlayerInput>();

  public Vector2 Direction { get; set;}
}

public interface IInputHandelr
{
  Vector2 Direction { get; set; }
}
