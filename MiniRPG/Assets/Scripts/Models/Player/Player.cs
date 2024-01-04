
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
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
    public NavMeshAgent PlayerAgent { get; private set; }
    public Camera MainCamera { get; private set; }
    
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
        PlayerAgent = GetComponent<NavMeshAgent>();
        MainCamera = Camera.main;

        _playerStateMachine = new PlayerStateMachine(this);
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
