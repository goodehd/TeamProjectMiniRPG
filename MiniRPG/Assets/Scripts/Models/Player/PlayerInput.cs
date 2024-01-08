
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region Fields (events)

    public event Action<Vector2> OnMovement;
    public event Action<Vector2> OnAttack;

    #endregion

    #region Properties

    public PlayerInputAction PlayerInputAction { get; private set; }
    public PlayerInputAction.PlayerActions PlayerActions { get; private set; }

    #endregion



    #region Unity Behavior

    private void Awake()
    {
        PlayerInputAction = new PlayerInputAction();

        PlayerActions = PlayerInputAction.Player;
    }

    private void OnEnable()
    {
        PlayerInputAction.Enable();

        PlayerInputAction.Player.MovementApply.performed += OnRightClick;
        PlayerInputAction.Player.AttackApply.performed += OnLeftClick;
    }

    private void OnDisable()
    {
        PlayerInputAction.Disable();
        
        PlayerInputAction.Player.MovementApply.performed -= OnRightClick;
        PlayerInputAction.Player.AttackApply.performed -= OnLeftClick;
    }

    #endregion



    #region Callback

    private void OnRightClick(InputAction.CallbackContext context)
    {
        if (!(context.ReadValue<float>() > Literals.ZeroF)) return;
        
        OnMovement?.Invoke(Mouse.current.position.ReadValue());
    }

    private void OnLeftClick(InputAction.CallbackContext context)
    {
        if (!(context.ReadValue<float>() > Literals.ZeroF)) return;
        
        OnAttack?.Invoke(Mouse.current.position.ReadValue());
        //_playerAttack.Attack();
    }

    #endregion
}
