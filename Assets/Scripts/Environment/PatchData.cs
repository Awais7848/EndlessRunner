using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum SpawnType
{
    None,
    Cars,
    JumpObstacle,
    SlideObstacle,
    CoinLine
}

[System.Serializable]
struct SpawnData
{
   public SpawnType spawnType;
   public float OffSet;

}


[System.Serializable]
public struct LineData
{
    public SpawnType[] lineData;


}


[CreateAssetMenu(menuName ="Environment/PatchData")]
public class PatchData : ScriptableObject
{
    [Header("Line Position")]
    [SerializeField]LineData[] LinesData;

    [Header("Spawn Data")]
    [SerializeField] List<SpawnData> SpawnData;

    public LineData GetRandomLine
    {

        get
        {
            return LinesData[Random.Range(0, LinesData.Length)];
        }
    }

   public float GetOffset(SpawnType type)
    {
        return SpawnData.Find(x => x.spawnType == type).OffSet;
    }

 

    [Header("Prefabs")]

    [SerializeField]public string[] CarPrefabs;
    [SerializeField]public string SlidePrefab;
    [SerializeField]public string JumpPrefab;
    [SerializeField]public string CoinPrefab;
}
