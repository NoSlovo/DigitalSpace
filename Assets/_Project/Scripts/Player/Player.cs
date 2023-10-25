using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Rigidbody _rigidbody;

    private HandlerInput _handlerInput;
    private Vector3 _directionMove = Vector3.zero;
    private const float _moveSpeed = 7f;
    private CharacterMove _characterMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _handlerInput = new HandlerInput();
        _characterMove = new CharacterMove(transform, _cameraTransform);
    }

    private void OnEnable()
    {
        _handlerInput.Enable();
    }

    private void FixedUpdate()
    {
        var direction = _handlerInput.GetMoveDirection();
        _directionMove.x = direction.x;
        _directionMove.z = direction.y;
        _characterMove.Move(_directionMove);
    }
    

    private void OnDisable()
    {
        _handlerInput.Disable();
    }
}