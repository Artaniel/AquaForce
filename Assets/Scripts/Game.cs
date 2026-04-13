using UnityEngine;

public class Game : MonoBehaviour
{    
    private Boot _boot;
    public SceneBootChannel bootChannel;

    public UI ui;
    public Session session;
    public Camera mainCamera;
    public Sound sound;

    public Library library;


    private void Awake() {
        bootChannel.BootCreatedSignal(this);
        mainCamera = Camera.main;
        ui.Init(this);
        //sound.Init(this);
        //session.Init(this);
    }

    public void Init(Boot root) {
        _boot = root;
    }

    private void Start() {
    }
}
