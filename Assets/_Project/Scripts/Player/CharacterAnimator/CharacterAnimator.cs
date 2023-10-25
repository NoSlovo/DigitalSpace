using UnityEngine;

namespace _Project.Scripts.Player.CharacterAnimator
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animatorCharacter;
        
        private static readonly int _iJump = Animator.StringToHash("IJump");
        private static readonly int _speed = Animator.StringToHash("Speed");


        public void Jump(bool characterJump)
        {
            _animatorCharacter.SetBool(_iJump,characterJump);
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