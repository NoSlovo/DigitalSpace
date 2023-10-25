using UnityEngine;

public class CharacterMove
{
    private Transform _cameraTransform;
    private Transform _transform;
    private Animator _animator;
    private Rigidbody _rb;

    private float _angle;
    private float _smoth;
    private float _smothTime = 0.2f;
    private const float _moveSpeed = 7f;
    private const float _jumpForce = 7f;

    public CharacterMove(Transform transform, Transform cameraTransform,Rigidbody Rb,Animator animator)
    {
        _cameraTransform = cameraTransform;
        _transform = transform;
        _rb = Rb;
        _animator = animator;
    }

    public void Move(Vector3 DirectionMove)
    {
        if (DirectionMove.magnitude > 0.1f)
        {
            _angle = CalculateRotationAnge(DirectionMove);
            var move = CharacterRotation(_angle);
            _rb.MovePosition(_rb.position + move.normalized * (_moveSpeed * Time.fixedDeltaTime));
        }
    }

    private Vector3 CharacterRotation(float Angle)
    {
        _rb.rotation = Quaternion.Euler(0f, Angle, 0);
        Vector3 move = Quaternion.Euler(0f, Angle, 0f) * Vector3.forward;
        return move;
    }

    public void Jump()
    {
        if (_rb.velocity.y == 0)
        {
            _rb.AddForce(Vector3.up * _jumpForce,ForceMode.Impulse);
            _animator.SetBool("IJump",true);
        }
        else
        {
            _animator.SetBool("IJump",false);
        }
    }

    private float CalculateRotationAnge(Vector3 Direction)
    {
        float rotationAnge = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + _cameraTransform.eulerAngles.y;
        return Mathf.SmoothDampAngle(_transform.eulerAngles.y, rotationAnge, ref _smoth, _smothTime);
    }
}