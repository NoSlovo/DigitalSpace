using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _charecterAnimator;

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

        if (_handlerInput.JumpButtonPressed())
        {
            _characterMove.Jump();
        }
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