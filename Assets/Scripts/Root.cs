using UnityEngine;

public class Boot : MonoBehaviour
{
    public SceneBootChannel bootChannel;
    public Game activeGame;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        bootChannel.boot = this;
    }

    public void OnBootCreated(Game game) {
        activeGame = game;
        //game.Init(this);
    }
} 