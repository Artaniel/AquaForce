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
    public AudioSource onWaterEnd;
    
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
        if (isMuted) {
            onHold.Stop();
        }
    }    

    public void OnPress(){
        if (isMuted) return;
        onPress.Play();
        onHold.Play();
    }
    
    public void OnRelease(){
        if (isMuted) return;
        onRelease.Play();
        onHold.Stop();
    }

    public void OnWaterEnd(){
        if (isMuted) return;
        onWaterEnd.Play();
    }
    
    public void OnVoidZoneDeath(){
        if (isMuted) return;
        voidZoneDeath.Play();
    }
    
    public void OnUIClick(){
        if (isMuted) return;
        uiClick.Play();
    }
    
    public void OnSpawn(){
        if (isMuted) return;
        spawn.Play();
    }
    
    public void OnWin(){
        if (isMuted) return;
        win.Play();
    }
    
    public void OnLose(){
        if (isMuted) return;
        lose.Play();
    }    
}
