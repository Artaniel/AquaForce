using UnityEngine;

public class Game : MonoBehaviour
{    
    private Boot _boot;
    public SceneBootChannel bootChannel;

    public UI ui;
    public Session session;
    public Camera mainCamera;
    public Sound sound;
    public PlayerInput input;
    public WaveFactory waveFactory; 
    public WaveStarter waveStarter;

    public Library library;

    private void Awake() {
        mainCamera = Camera.main;
        ui.Init(this);
        input.Init(this);
        waveFactory.Init(this);
        waveStarter.Init(this);
    }

    private void Update() {
        input.ManualUpdate();
        waveStarter.ManualUpdate();
        waveFactory.ManualUpdate();
    }
}
