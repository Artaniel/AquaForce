using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "Configs/WaveConfig")]
public class WaveConfig : ScriptableObject
{    
    public float maxMass = 1000f;
    public float maxScale = 100f;
    public float massGainSpeed = 50f;
}
