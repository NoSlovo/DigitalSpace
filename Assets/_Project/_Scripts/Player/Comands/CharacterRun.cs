using _Project.Scripts.Interfaces;
using _Project.Scripts.Player.CharacterAnimator;

public class CharacterRun : ICharacterComand
{
    private CharacterAnimator _animator;
    
    private const float _runSpeed = 0.30f;

    public CharacterRun(CharacterAnimator Animator)
    {
        _animator = Animator;
    }
    public void Execute( ref float speedNow)
    {
        speedNow = _runSpeed;
        _animator.SetSpeedValue(speedNow);
    }
}