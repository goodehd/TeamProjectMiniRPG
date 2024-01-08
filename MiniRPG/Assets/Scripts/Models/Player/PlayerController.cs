
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(
    typeof(Animator),
    typeof(CharacterController), 
    typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    #region Fields

    // Member
    private CharacterController _characterController;
    private PlayerInput _playerInput;
    private Rigidbody _playerRBody;
    private Animator _playerAnimator;
    private Camera _mainCamera;
    
    // Player
    private Player _player;
    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;
    
    // State Machine
    private FiniteStateMachine _finiteStateMachine;

    // Timers
    private List<Timer> _timers;
    private CountdownTimer _attackCooldownTimer;
    
    #endregion




    //#region Getter (Properties)

    public CharacterController Controller => _characterController;
    public Animator Animator => _playerAnimator;
    public Rigidbody RBody => _playerRBody;
    public PlayerInput Input => _playerInput;
    public Camera MainCamera => _mainCamera;

    public Player Player => _player;
    public PlayerMovement PlayerMovement => _playerMovement;
    public PlayerAttack PlayerAttack => _playerAttack;

    //#endregion



    //#region Unity Behavior

    private void Awake()
    {
        InitializeAwake();
    }

    private void Start()
    {
        InitializeStart();
    }

    private void Update()
    {
        _finiteStateMachine.Update();

        UpdateAnimator();
        UpdateTimerHandle();
    }

    private void FixedUpdate()
    {
        _finiteStateMachine.FixedUpdate();
        //_playerMovement.HandleMovement();
    }

    private void OnEnable()
    {
        AllocInputEvent();
        _playerInput.OnAttackTimer += OnAttackTimer;
    }

    private void OnDisable()
    {
        ReleaseInputEvent();
        _playerInput.OnAttackTimer -= OnAttackTimer;
    }

    //#endregion



    //#region Initialize Behavior

    // Awake
    private void InitializeAwake()
    {
        // Player
        _player = new Player();

        _characterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _playerRBody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        
        _playerMovement = new PlayerMovement(this);
        _playerAttack = new PlayerAttack(this);
    }

    private void InitializeStart()
    {
        SetupStateMachine();
        SetupTimers();
    }

    //#endregion



    //#region Initialize

    private void SetupStateMachine()
    {
        // State Machine 
        _finiteStateMachine ??= new FiniteStateMachine();
        
        // Declare States
        var locomotionState = new LocomotionState(this, Player);
        var attackState = new AttackState(this, Player);

        // Define transitions
        At(locomotionState, attackState, new FuncPredicate(() => _attackCooldownTimer.IsRunning));
        At(attackState, locomotionState, new FuncPredicate(() => !_attackCooldownTimer.IsRunning));
        Any(locomotionState, new FuncPredicate(ReturnToLocomotionState));
        
        // Set Initial State
        _finiteStateMachine.SetState(locomotionState);
    }

    private void SetupTimers()
    {
        _attackCooldownTimer = new CountdownTimer(0.5f);

        _timers = new List<Timer> { _attackCooldownTimer };
    }

    private void OnAttackTimer()
    {
        if (!_attackCooldownTimer.IsRunning)
        {
            _attackCooldownTimer.Start();
        }
    }

    private bool ReturnToLocomotionState()
    {
        return !_attackCooldownTimer.IsRunning;
    }

    private void AllocInputEvent()
    {
        _playerMovement.AllocMovementInputEvent();
        _playerAttack.AllocAttackInputEvent();
    }

    private void ReleaseInputEvent()
    {
        _playerMovement.ReleaseMovementInputEvent();
        _playerAttack.ReleaseAttackInputEvent();
    }

    //#endregion



    //#region Rename

    private void At(IFiniteState from, IFiniteState to, IStatePredicate condition)
        => _finiteStateMachine.AddTransition(from, to, condition);

    private void Any(IFiniteState to, IStatePredicate condition)
        => _finiteStateMachine.AddAnyTransition(to, condition);

    //#endregion



    #region Update

    private void UpdateAnimator()
    {
        _playerAnimator.SetFloat(Player.AnimationData.Speed, _playerMovement.CurrentSpeed);
    }

    private void UpdateTimerHandle()
    {
        foreach (var timer in _timers)
        {
            timer.Tick(Time.deltaTime);
        }
    }

    #endregion
}