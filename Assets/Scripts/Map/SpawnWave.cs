using UnityEngine;

[CreateAssetMenu(fileName = "SpawnWave", menuName = "AquaForce/SpawnWave")]
public class SpawnWave : ScriptableObject
{
    public float launchTime;
    public Enemy[] prefabs;
}

