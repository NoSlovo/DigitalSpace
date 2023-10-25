using UnityEngine;

public class CharacterMove
{
    private Transform _cameraTransform;
    private Transform _characterTransform;
    
    private Rigidbody _rb;
    
    private float _angle;
    private float _smoth;
    private float _smothTime = 0.2f;
    private const float _moveSpeed = 7f;

    public CharacterMove(Transform characterTransform,Transform cameraTransform)
    {
        _cameraTransform = cameraTransform;
        _characterTransform = characterTransform;
    }
    
    public void Move(Vector3 DirectionMove )
    {
        if (DirectionMove.magnitude > 0.1f)
        {
            _angle = CalculateRotationAnge(DirectionMove);
            _rb.rotation = Quaternion.Euler(0f, _angle, 0);
            Vector3 move = Quaternion.Euler(0f, _angle, 0f) * Vector3.forward;
            _rb.MovePosition(_rb.position + move.normalized * (_moveSpeed * Time.fixedDeltaTime));
        }
    }
    
    private float CalculateRotationAnge(Vector3 Direction)
    {
        float rotationAnge = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + _cameraTransform.eulerAngles.y;
        return Mathf.SmoothDampAngle(_characterTransform.eulerAngles.y, rotationAnge, ref _smoth, _smothTime);
    } 
}