using _Project.Scripts.Player.CharacterAnimator;
using UnityEngine;

public class CharacterJump : IJumpComand
{
    private CharacterAnimator _animator;
    private const float JumpForce = 10f;
    
    public CharacterJump()
    {
        
    }

    public void Execute(Rigidbody rigidbody)
    {
        if (rigidbody.velocity.y == 0)
        {
            rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}