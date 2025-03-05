using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerControls : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        private PlayerInput _input;
        private Vector2 _movement;

        private void Awake()
        {
            _input = new PlayerInput();
        }

        private void OnEnable()
        {
            _input.Player.Move.performed += Input_Move;
            _input.Player.Move.canceled += Input_Move;
            _input.Enable();
        }

        private void FixedUpdate()
        {
            transform.Translate(_movement * _movementSpeed * Time.deltaTime);
        }

        private void Input_Move(InputAction.CallbackContext obj)
        {
            _movement = obj.ReadValue<Vector2>();
        }
    }
}
