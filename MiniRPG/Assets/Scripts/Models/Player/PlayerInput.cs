
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Property

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
    }

    private void OnDisable()
    {
        PlayerInputAction.Disable();
    }

    #endregion
}
