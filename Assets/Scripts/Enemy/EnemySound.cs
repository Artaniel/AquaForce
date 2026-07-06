using UnityEngine;

public class EnemySound : MonoBehaviour
{  

    private Game _game;
    private Enemy _enemy;

    public AudioSource hitAudioSource;
    public AudioSource struggleAudioSource;
    public AudioSource deathAudioSource;    

    public AudioClip[] hitClips;
    public AudioClip[] struggleClips;
    public AudioClip[] deathClips;

    public void Init(Game game, Enemy enemy) {
        _game = game;
        _enemy = enemy;        
    } 

    public void Hit() {
        if (hitClips.Length == 0) return;
        hitAudioSource.clip = hitClips[Random.Range(0, hitClips.Length)];
        hitAudioSource.Play();
    }

    public void Struggle() {
        if (struggleClips.Length == 0) return;
        struggleAudioSource.clip = struggleClips[Random.Range(0, struggleClips.Length)];
        struggleAudioSource.Play();
    }

    public void Death() {
        if (deathClips.Length == 0) return;
        deathAudioSource.clip = deathClips[Random.Range(0, deathClips.Length)];
        deathAudioSource.Play();
    }


}
