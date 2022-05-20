using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public string currentState;

    //StateMachine
    GameStateMachine stateMachine;
    MainMenuState mainMenuState;
    DialogState dialogState;
    PlayState playState;

    //Components
    SceneLoader sceneLoader;
    InputManager inputManager;


    public GameStateMachine StateMachine { get => stateMachine; }
    public MainMenuState MainMenuState { get => mainMenuState; }
    public DialogState DialogState { get => dialogState; }
    public PlayState PlayState { get => playState; }



    public SceneLoader SceneLoader { get => sceneLoader; }
    public InputManager InputManager { get => inputManager; }

    protected override void Awake()
    {
        base.Awake();

        //Components
        sceneLoader = GetComponent<SceneLoader>();
        inputManager = GetComponent<InputManager>();
    }

    private void Start()
    {
        //StateMachine
        stateMachine = new GameStateMachine();
        mainMenuState = new MainMenuState();
        dialogState = new DialogState();
        playState = new PlayState();
        StateMachine.Initialize(mainMenuState);
    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.FixedUpdate();
    }
    private void LateUpdate()
    {
        StateMachine.CurrentState.LateUpdate();
    }

}
