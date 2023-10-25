using UnityEngine;

namespace _Project.Scripts.Player.CharacterAnimator
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animatorCharacter;
        
        private static readonly int _iJump = Animator.StringToHash("IJump");


        public void Jump(bool characterJump)
        {
            _animatorCharacter.SetBool(_iJump,characterJump);
        }
    }
}