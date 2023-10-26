using _Project.Scripts.Player.CharacterAnimator;
using Movement;
using PlayerCamera;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CameraGame cameraGame;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private CharacterAnimator _charecterAnimator;

        private PlayerInput _playerInput;
        private Vector3 _directionMove = Vector3.zero;
        private CharacterMove _characterMove;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _rigidbody = GetComponent<Rigidbody>();
            _characterMove = new CharacterMove(transform, cameraGame, _rigidbody, _charecterAnimator);
        }

        private void OnEnable() => _playerInput.Enable();

        private void Start()
        {
            _playerInput.KeyBoard.Jump.performed += _ => { _characterMove.Jump(); };
            _playerInput.KeyBoard.Run.performed += _ => { _characterMove.Run();};
            _playerInput.KeyBoard.Run.canceled += _ => { _characterMove.Wallking();};
        }

        private void FixedUpdate()
        {
            _directionMove = GetMoveDirection();
            _characterMove.Move(_directionMove);
        }

        private Vector3 GetMoveDirection()
        {
            var direction = _playerInput.KeyBoard.WASD.ReadValue<Vector2>();
            return new Vector3(direction.x, 0, direction.y);
        }

        private void OnDisable() => _playerInput.Disable();
    }
} 
