using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedualGen : MonoBehaviour
{
   
    public int generatorSeed;
    public float noiseScale;
    public int chunkHeight;
    public int chunkWidth;
    public objectToSpawn[] ids;
    
    [System.Serializable]
    public struct objectToSpawn
    {
        public float minValue;
        public float maxValue;
        public int ID;
    }

    int[,] GenerateChunk()
    {

        int[,] chunk = new int[chunkHeight,chunkWidth];

        for (int i = 0; i < chunkWidth; i++)
        {
            for (int j = 0; j < chunkHeight; j++)
            {
                Debug.Log("X:" + i + " Y:" + j);
                int objectID = 0;
                float currentVal = noiseScale * Mathf.PerlinNoise( (generatorSeed + i) / 10000f , (generatorSeed + j) / 10000f );
                Debug.Log(currentVal);
                foreach (objectToSpawn id in ids) 
                {
                    if (currentVal >= id.minValue && currentVal <= id.maxValue)
                    {
                        objectID = id.ID;
                    }
                }
                
                if (objectID == 0)
                {
                    objectID = 0;
                }
                
                chunk[i,j] = objectID;
                Debug.Log(objectID);

            }
        }
        return chunk;

    }

    void Start()
    {

        GenerateChunk();

    }

}
