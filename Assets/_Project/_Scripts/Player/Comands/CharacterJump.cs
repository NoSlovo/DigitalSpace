using _Project.Scripts.Player.CharacterAnimator;
using UnityEngine;

public class CharacterJump
{
    private Rigidbody _rb;
    private CharacterAnimator _animator;
    private const float _jumpForce = 7f;
    
    public  CharacterJump(Rigidbody rb,CharacterAnimator animator)
    {
        _rb = rb;
        _animator = animator;
    }
    
    public void Jump()
    {
        if (_rb.velocity.y == 0)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _animator.Jump(true);
        }
        else
        {
            _animator.Jump(false);
        }
    }
}