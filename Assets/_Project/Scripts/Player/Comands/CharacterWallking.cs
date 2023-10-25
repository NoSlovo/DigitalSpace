using _Project.Scripts.Interfaces;
using _Project.Scripts.Player.CharacterAnimator;

public class CharacterWallking : ICharacterComand
{
    private CharacterAnimator _animator;
    private float _defaultSpeed = 5f;

    public CharacterWallking(CharacterAnimator Animator)
    {
        _animator = Animator;
    }
    
    public void Execute(ref float speedNow)
    {
        speedNow = _defaultSpeed;
        _animator.SetSpeedValue(speedNow);
    }
}