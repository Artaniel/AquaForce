using UnityEngine;

public class Game : MonoBehaviour
{    
    private Boot _boot;
    public static Game instance;    

    public UI ui;
    public Session session;
    public Camera mainCamera;
    public Sound sound;
    public PlayerInput input;
    public WaveFactory waveFactory; 
    public WaveStarter waveStarter;
    public EnemyFactory enemyFactory;
    public PropFactory propFactory;
    public SdkAdapter sdkAdapter;
    public AbilityFactory abilityFactory;
    
    public Map map;

    public Library library;

    private void Awake() {
        instance = this;
        mainCamera = Camera.main;
        sdkAdapter.Init(this);
        ui.Init(this);
        input.Init(this);
        waveFactory.Init(this);
        enemyFactory.Init(this);
        propFactory.Init(this);
        waveStarter.Init(this);
        session.Init(this);
        sound.Init(this);        
        abilityFactory.Init(this);

        session.SessionStart();        
    }

    private void Update() {
        input.ManualUpdate();
    }
    
    private void FixedUpdate() {
        waveStarter.ManualUpdate();
        waveFactory.ManualUpdate();
        abilityFactory.ManualFixedUpdate();
        enemyFactory.ManualFixedUpdate(Time.fixedDeltaTime);
    }
}
