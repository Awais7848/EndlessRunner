using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPatch : MonoBehaviour
{
    [SerializeField] PatchData patchData;
    float InitialValue = -40f;
    [SerializeField] Transform[] Lines;
    Vector3 InitPosLine1=new Vector3(0f,0f,-40f);
    Vector3 InitPosLine2 = new Vector3(0f,0f,-20f);
    Vector3 InitPosLine3 = new Vector3(0f,0f,-30f);

    List<GameObject> LineObjects = new
         List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        InitializeLines();
       
    }

    void InitializeLines()
    {
        LineData lineData = patchData.GetRandomLine;
        GenrateLine(lineData, Lines[0], InitPosLine1, LineObjects);

        lineData = patchData.GetRandomLine;
        GenrateLine(lineData, Lines[1], InitPosLine2, LineObjects);

        lineData = patchData.GetRandomLine;
        GenrateLine(lineData, Lines[2], InitPosLine3, LineObjects);

    }


    void GenrateLine(LineData lineData,Transform Line,Vector3 InitialPosition,List<GameObject> objects)
    {

        for (int i = 0; i < lineData.lineData.Length; i++)
        {
            switch (lineData.lineData[i])
            {
                case SpawnType.None:

                    InitialPosition.z += patchData.GetOffset(lineData.lineData[i]);
                    break;
                case SpawnType.Cars:
                    GameObject g = PoolManager.SpawnObject(patchData.CarPrefabs[Random.Range(0, patchData.CarPrefabs.Length)], InitialPosition, Quaternion.identity, Line);

                    g.transform.localPosition = InitialPosition;

                    InitialPosition.z += patchData.GetOffset(lineData.lineData[i]);
                    objects.Add(g);
                    break;
                case SpawnType.JumpObstacle:
                    GameObject g1 = PoolManager.SpawnObject(patchData.JumpPrefab, InitialPosition, Quaternion.identity, Line);

                    g1.transform.localPosition = InitialPosition;

                    InitialPosition.z += patchData.GetOffset(lineData.lineData[i]);
                    objects.Add(g1);
                    break;
                case SpawnType.SlideObstacle:
                    GameObject g2 = PoolManager.SpawnObject(patchData.SlidePrefab, InitialPosition, Quaternion.identity, Line);

                    g2.transform.localPosition = InitialPosition;

                    InitialPosition.z += patchData.GetOffset(lineData.lineData[i]);
                    objects.Add(g2);
                    break;
                case SpawnType.CoinLine:
                    GameObject g3 = PoolManager.SpawnObject(patchData.CoinPrefab, InitialPosition, Quaternion.identity, Line);

                    g3.transform.localPosition = InitialPosition;

                    InitialPosition.z += patchData.GetOffset(lineData.lineData[i]);
                    objects.Add(g3);
                    break;


            }
            InitialPosition.z += patchData.DistanceOffset;

            if (InitialPosition.z >= 50f)
            {
                break;
            }
        }

    }


   public void RespawnObstacles()
    {
        ClearAllObjects();
        InitializeLines();
    }


    void ClearAllObjects()
    {
        if (LineObjects.Count <= 0)
            return;

        for(int i = 0; i < LineObjects.Count; i++)
        {
            PoolManager.DestroyObject(LineObjects[i].name, LineObjects[i]);
        }

        LineObjects.Clear();
    }
}
