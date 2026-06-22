using UnityEngine;

public class EnemySound : MonoBehaviour
{  

    private Game _game;
    private Enemy _enemy;

    public AudioSource hitAudioSource;
    public AudioSource struggleAudioSource;
    public AudioSource deathAudioSource;    

    public void Init(Game game, Enemy enemy) {
        _game = game;
        _enemy = enemy;        
    } 

    public void Hit() {
        hitAudioSource.Play();
    }

    public void Struggle() {
        struggleAudioSource.Play();
    }

    public void Death() {
        deathAudioSource.Play();
    }


}
