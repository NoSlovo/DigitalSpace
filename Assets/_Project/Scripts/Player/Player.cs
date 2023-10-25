using System.Collections;
using _Project.Scripts.Player.CharacterAnimator;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CharacterAnimator _charecterAnimator;

    private HandlerInput _handlerInput;
    private Vector3 _directionMove = Vector3.zero;
    private CharacterMove _characterMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _handlerInput = new HandlerInput();
        _characterMove = new CharacterMove(transform, _cameraTransform, _rigidbody, _charecterAnimator);
    }

    private void OnEnable()
    {
        _handlerInput.Enable();
    }


    private void FixedUpdate()
    {
        _directionMove = GetMoveDirection();

        _characterMove.Move(_directionMove);
        
        ButtonCheck();
    }

    private void ButtonCheck()
    {
        if (_handlerInput.JumpButtonPressed())
            _characterMove.Jump();

        if (_handlerInput.RunnButtonPressed())
            _characterMove.Run();
        
        else
            _characterMove.Wallking();
        
    }

    private Vector3 GetMoveDirection()
    {
        var direction = _handlerInput.GetMoveDirection();
        return new Vector3(direction.x, 0,direction.y);
    }

    private void OnDisable()
    {
        _handlerInput.Disable();
    }
}