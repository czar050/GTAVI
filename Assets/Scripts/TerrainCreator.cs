using UnityEngine;

public class TerrainCreator : MonoBehaviour
{
    [SerializeField] private int width = 1000;
    [SerializeField] private int depth = 1000;
    [SerializeField] private float maxHeight = 5;
    [SerializeField] private float scale = 20;

    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
       terrainData.heightmapResolution = width + 1;
       terrainData.size = new Vector3(width, maxHeight, depth);
       float[,] height = new float[width, depth];

       for(int x = 0; x < width; x++)
       {
            for(int z =0; z < depth; z++)
            {
                height[x,z] = Mathf.PerlinNoise(x / scale, z / scale);
            }
       }

       for(int x = 0; x < width; x++)
       {
            for(int z =0; z < depth; z++)
            {
                height[x,z] = Mathf.Clamp(height[x,z], 0 , maxHeight);
            }
       }

       terrainData.SetHeights(0,0,height);
       return terrainData;
    }
}
