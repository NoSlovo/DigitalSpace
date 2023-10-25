using UnityEngine;

public class HandlerInput 
{
  private PlayerInput _playerInput;

  public HandlerInput()
  {
     _playerInput =  new PlayerInput();
  }

  public void Enable() => _playerInput.Enable();

  public Vector2 GetMoveDirection() {
      return _playerInput.KeyBoard.WASD.ReadValue<Vector2>();
  }

  public void Disable() => _playerInput.Disable();

  public bool JumpButtonPressed()
  {
      if (_playerInput.KeyBoard.Jump.ReadValue<float>() > 0)
         return true;
      
      return false;
  }

}