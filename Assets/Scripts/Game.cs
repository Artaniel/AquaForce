using UnityEngine;

public class Game : MonoBehaviour
{    
    private Boot _boot;
    public SceneBootChannel bootChannel;

    public UI ui;
    public Session session;
    public Camera mainCamera;
    public Sound sound;
    public WaterWave wave;
    public PlayerInput input;

    public Library library;

    private void Awake() {
        bootChannel.BootCreatedSignal(this);
        mainCamera = Camera.main;
        ui.Init(this);
        wave.Init(this);
        input.Init(this);
    }
}
