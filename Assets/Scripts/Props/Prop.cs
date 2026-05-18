using UnityEngine;

public class Prop : MonoBehaviour
{
    private Game _game;
    private PropFactory _factory;
    public Rigidbody2D propRigidbody;
    public CircleCollider2D propCollider;    
    public Transform mainSprite;
    public Damager damager;
    public bool isAffectedByWave = false;

    void Start() {
        if (_factory) return;
        Debug.LogWarning("Prop was not inited.");
        Game.instance.propFactory.Register(this);
    }

    public void Init(Game game, PropFactory factory) {
        _game = game;
        _factory = factory;
    }

    private void OnValidate() {
        if (!propRigidbody) propRigidbody = GetComponent<Rigidbody2D>();
        if (!propCollider) propCollider = GetComponent<CircleCollider2D>();
    }
}
