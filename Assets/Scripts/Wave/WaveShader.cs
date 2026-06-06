using UnityEngine;

public class WaveShader : MonoBehaviour
{
    private WaterWave _wave;
    public SpriteRenderer mainSprite;
    private Material material;
    public float shiftMultiplier = -0.1f;

    public void Init(WaterWave wave) {
        _wave = wave;
        material = mainSprite.material;
    }

    private void Update() {        
        Vector2 shift = new Vector2(_wave.transform.position.x * shiftMultiplier, _wave.transform.position.y * shiftMultiplier);
        material.SetVector("_shift", shift);
    }
}