using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Level", menuName ="SO/Level")]
public class LevelData : ScriptableObject
{
    public List<Wave> Waves = new List<Wave>();
}
[System.Serializable]
public class Wave
{
    public List<GameObject> _enemy;
    [Range (1,1000)]
    public int CountEnemyInWave;
    [Range (1,360)]
    public int NextWaveTimer;
}
