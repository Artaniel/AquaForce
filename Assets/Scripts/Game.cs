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

    public Library library;


    private void Awake() {
        instance = this;
        mainCamera = Camera.main;
        ui.Init(this);
        input.Init(this);
        waveFactory.Init(this);
        enemyFactory.Init(this);
        waveStarter.Init(this);
    }

    private void Update() {
        input.ManualUpdate();
        waveStarter.ManualUpdate();
        waveFactory.ManualUpdate();
    }
}
