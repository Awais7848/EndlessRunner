using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPatch : MonoBehaviour
{
    [SerializeField] PatchData patchData;
    [SerializeField] GameObject ObstaclePrefab;
    float InitialValue = -40f;
    [SerializeField] Transform[] Lines;
    Vector3 InitPosLine1=new Vector3(0f,0f,-40f);
    Vector3 InitPosLine2 = new Vector3(0f,0f,-20f);
    Vector3 InitPosLine3 = new Vector3(0f,0f,-30f);


    List<GameObject> LineObject;
    // Start is called before the first frame update
    void Start()
    {

        LineData lineData = patchData.GetRandomLine;
        GenrateLine(lineData, Lines[0],InitPosLine1);

         lineData = patchData.GetRandomLine;
        GenrateLine(lineData, Lines[1],InitPosLine2);

        lineData = patchData.GetRandomLine;
        GenrateLine(lineData, Lines[2],InitPosLine3);

       
    }



    void GenrateLine(LineData lineData,Transform Line,Vector3 InitialPosition)
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
                    break;
                case SpawnType.JumpObstacle:
                    GameObject g1 = PoolManager.SpawnObject(patchData.JumpPrefab, InitialPosition, Quaternion.identity, Line);

                    g1.transform.localPosition = InitialPosition;

                    InitialPosition.z += patchData.GetOffset(lineData.lineData[i]);
                    break;
                case SpawnType.SlideObstacle:
                    GameObject g2 = PoolManager.SpawnObject(patchData.SlidePrefab, InitialPosition, Quaternion.identity, Line);

                    g2.transform.localPosition = InitialPosition;

                    InitialPosition.z += patchData.GetOffset(lineData.lineData[i]);
                    break;
                case SpawnType.CoinLine:
                    GameObject g3 = PoolManager.SpawnObject(patchData.CoinPrefab, InitialPosition, Quaternion.identity, Line);

                    g3.transform.localPosition = InitialPosition;

                    InitialPosition.z += patchData.GetOffset(lineData.lineData[i]);
                    break;


            }


            if (InitialPosition.z >= 50f)
            {
                break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
