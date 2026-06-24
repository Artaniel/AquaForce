using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    private Game _game;
    [HideInInspector] public bool isMuted = false;
    public AudioMixer mixer;
    
    public AudioSource onPress;
    public AudioSource onHold;
    public AudioSource onRelease;
    
    public AudioSource voidZoneDeath;
    
    public AudioSource uiClick;
    public AudioSource spawn;
    public AudioSource win;
    public AudioSource lose;
    public AudioSource bgm;

    public void Init(Game game) {
        _game = game;
    }

    public void OnMuteButtonPress() {
        isMuted = !isMuted;
        float value = isMuted ? 0 : 1;
        float dBValue = Mathf.Log10(value + 0.0001f) * 20;
        mixer.SetFloat("MasterVolume", dBValue);
    }
}
