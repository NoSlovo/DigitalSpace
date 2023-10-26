using _Project.Scripts.Interfaces;
using _Project.Scripts.Player.CharacterAnimator;
using UnityEngine;

public class CharacterMove
{
    private Transform _cameraTransform;
    private Transform _transform;
    private CharacterAnimator _animator;
    private Rigidbody _rb;
    private CharacterJump _characterJump;

    private ICharacterComand _comand;

    private float _smoth;
    private float _smothTime = 0.2f;
    private float _moveSpeed = 0.15f;
    private const float _minSpeedValue = 0;

    public CharacterMove(Transform transform, Transform cameraTransform, Rigidbody Rb, CharacterAnimator animator)
    {
        _cameraTransform = cameraTransform;
        _transform = transform;
        _rb = Rb;
        _animator = animator;
        _characterJump = new CharacterJump(_rb, _animator);
    }

    public void Move(Vector3 DirectionMove)
    {
        if (DirectionMove.magnitude > 0.1f)
        {
            _comand.Execute(ref _moveSpeed);
            var _angle = CalculateRotationAnge(DirectionMove);
            var move = CharacterRotation(_angle);
            _animator.SetSpeedValue(_moveSpeed);
            _rb.AddForce(move * _moveSpeed,ForceMode.Impulse);
        }
        else
        {
            _animator.SetSpeedValue(_minSpeedValue);
        }
    }

    public void Run() => _comand = new CharacterRun(_animator);

    public void Wallking() => _comand = new CharacterWallking(_animator);

    public void Jump() => _characterJump.Jump();

    private Vector3 CharacterRotation(float Angle)
    {
        _rb.rotation = Quaternion.Euler(0f, Angle, 0);
        Vector3 move = Quaternion.Euler(0f, Angle, 0f) * Vector3.forward;
        return move;
    }

    private float CalculateRotationAnge(Vector3 Direction)
    {
        float rotationAnge = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + _cameraTransform.eulerAngles.y;
        return Mathf.SmoothDampAngle(_transform.eulerAngles.y, rotationAnge, ref _smoth, _smothTime);
    }
}