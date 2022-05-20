using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [Header("Speed")]
    public float walkSpeed = 2;
    public float sprintSpeed = 8;

    [Header("Smoothing")]

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;

    [Header("Debug")]
    [SerializeField] float currentSpeed;

    //State machine
    public string DebugStateName;
    PlayerStateMachine stateMachine;
    IdlePlayerState idlePlayerState;
    WalkPlayerState walkPlayerState;
    SprintPlayerState sprintPlayerState;

    public PlayerStateMachine StateMachine { get => stateMachine; }
    public IdlePlayerState IdlePlayerState { get => idlePlayerState; }
    public WalkPlayerState WalkPlayerState { get => walkPlayerState; }
    public SprintPlayerState SprintPlayerState { get => sprintPlayerState; }

    //Components
    MovementManager movementManager;
    Interactor interactor;
    AnimationManager animationManager;


    public MovementManager MovementManager { get => movementManager; }
    public Interactor Interactor { get => interactor; }
    public AnimationManager AnimationManager { get => animationManager; }


    private void Awake()
    {
        movementManager = GetComponent<MovementManager>();
        interactor = GetComponent<Interactor>();
        animationManager = GetComponent<AnimationManager>();
    }

    private void Start()
    {
        stateMachine = new PlayerStateMachine();
        idlePlayerState = new IdlePlayerState(this);
        walkPlayerState = new WalkPlayerState(this);
        sprintPlayerState = new SprintPlayerState(this);
        stateMachine.Initialize(idlePlayerState);
    }

    void Update()
    {
        stateMachine.CurrentState.Update();
    }

    void FixedUpdate()
    {
        stateMachine.CurrentState.FixedUpdate();
    }

    private void LateUpdate()
    {
        stateMachine.CurrentState.LateUpdate();
    }
}
