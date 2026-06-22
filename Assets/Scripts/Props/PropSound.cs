using UnityEngine;

public class PropSound : MonoBehaviour
{
    private Game _game;
    private Prop _prop;

    public AudioSource hitAudioSource;

    public void Init(Game game, Prop prop) {
        _game = game;
        _prop = prop;
    }
    
    public void Hit() {
        hitAudioSource.Play();
    }
}
