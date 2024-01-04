
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    // Player Data Reference
    public PlayerData PlayerData { get; private set; }
    
    // Animation Data
    [field: Header("Animation Data")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    
    // Properties
    public Rigidbody PlayerRBody { get; private set; }
    public Animator PlayerAnimator { get; private set; }
    public PlayerInput PlayerInput { get; private set; }
    public CharacterController PlayerController { get; private set; }
    
    // State Machine
    private PlayerStateMachine _playerStateMachine;

    #endregion



    #region Unity Behavior

    private void Awake()
    {
        InitializePlayer();
    }

    private void Start()
    {
        CursorLock();
        SetupState();
    }

    private void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        UpdateStatePhysics();
    }

    #endregion



    #region Initialize

    private void InitializePlayer()
    {
        // Player Data Init
        PlayerData = new PlayerData();
        
        // Animation Data Init
        if (!AnimationData.IsInit)
        {
            AnimationData.Initialize();
        }

        PlayerRBody = GetComponent<Rigidbody>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerInput = GetComponent<PlayerInput>();
        PlayerController = GetComponent<CharacterController>();

        _playerStateMachine = new PlayerStateMachine(this);
    }

    private void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetupState()
    {
        _playerStateMachine.TransitionState(_playerStateMachine.IdleState);
    }

    #endregion



    #region State Machine Update Handles

    private void UpdateState()
    {
        _playerStateMachine.HandleInput();
        _playerStateMachine.UpdateLogic();
    }

    private void UpdateStatePhysics()
    {
        _playerStateMachine.UpdatePhysics();
    }

    #endregion
}
