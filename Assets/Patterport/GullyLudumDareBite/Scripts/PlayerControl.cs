using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] Camera _camera;
    GameControls _gameControls;


    Vector3 _velocity;

    [SerializeField]float _moveSpeed = 5f; // Do what feeeels right
    void Awake()
    {
        
    }

    private void OnEnable()
    {
        this._gameControls = new GameControls();
        this._gameControls.PlayerActions.Enable(); //Make sure to toggle between WASD or AZSD in the settings file
        this._gameControls.PlayerActions.Movement.performed += Movement;
        this._gameControls.PlayerActions.Movement.canceled += Movement;

    }

    Vector2 _direction;
    public void Movement(InputAction.CallbackContext context)
    {
        print("movement");
        this._direction = context.ReadValue<Vector2>();

    }

        
    public void FixedUpdate()
    {
        Vector3 move = new Vector3(this._direction.x, 0, this._direction.y) * this._moveSpeed;
        move = this._camera.transform.forward * move.z + this._camera.transform.right * move.x;
        this._velocity += move;
        this._velocity.y = 0;

    
        this._velocity *= Time.fixedDeltaTime;

        this._characterController.Move(this._velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
