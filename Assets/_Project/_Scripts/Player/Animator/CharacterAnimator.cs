using UnityEngine;

namespace _Project.Scripts.Player.CharacterAnimator
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animatorCharacter;
        
        private static readonly int _iJump = Animator.StringToHash("IJump");
        private static readonly int _speed = Animator.StringToHash("Speed");
        private const string _nameAnimation = "Jump";
        public void Jump()
        {
            _animatorCharacter.Play(_nameAnimation);
        }

        public void SetSpeedValue(float speed)
        {
            if (speed >= 0)
            {
                _animatorCharacter.SetFloat(_speed,speed);
            }
        }
        
    }
}