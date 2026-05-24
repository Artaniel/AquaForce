using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "Configs/WaveConfig")]
public class WaveConfig : ScriptableObject
{    
    public float maxMass = 1000f;
    public float maxScale = 100f;
    public float massGainSpeed = 50f;
    public float massDecayPerDistance = 5f;
    public float forceModifier = 0.1f;
    public float releasedDecaySpeed = 10f;
    public float positionLerpFactor = 0.1f;
    public float poiseDamageModifier = 0.1f;
}
