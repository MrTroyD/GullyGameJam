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
    Vector2 _direction;

    [SerializeField]float _moveSpeed = 5f; // Do what feeeels right

    public Vector3 velocity
    {
        get { return this._velocity; }
    }

    void Awake()
    {
        
    }

    public void EnableControls()
    {
        this._playerInput.enabled = true;
    }

    public void DisableControls()
    {
            this._direction = Vector3.zero;
        this._playerInput.enabled = false;
    }

    private void OnEnable()
    {
        this._gameControls = new GameControls();
        this._gameControls.PlayerActions.Enable(); //Make sure to toggle between WASD or AZSD in the settings file
        this._gameControls.PlayerActions.Movement.performed += Movement;
        this._gameControls.PlayerActions.Movement.canceled += Movement;

    }

    private void OnDisable()
    {
        if (this._gameControls == null) return;
        try
        {
            this._gameControls.PlayerActions.Movement.performed -= Movement;
            this._gameControls.PlayerActions.Movement.canceled -= Movement;
            this._gameControls.PlayerActions.Disable();
        }
        catch(System.Exception e)
        {

        }

        this._gameControls = null;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        if (!this._playerInput.enabled)
        {
            this._direction = Vector3.zero;
            return;
        }

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
