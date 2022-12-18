using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();
    [SerializeField] private Transform terrainHolder;

    private Vector3 currentPosition = new Vector3(0, 0, 0);

    void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain();
        }
        
        StartCoroutine("PeriodicalTerrainSpawn");
    }
   
    IEnumerator PeriodicalTerrainSpawn()
    {
        while(true)
        {
            GameObject terrain = Instantiate(terrains[Random.Range(0, terrains.Count)], currentPosition, Quaternion.identity,terrainHolder);
            currentPosition.x++;

            Destroy(terrain, 32);

            yield return new WaitForSeconds(1f);
        }       
    }

    private void SpawnTerrain()
    {
        GameObject terrain = Instantiate(terrains[Random.Range(0, terrains.Count)], currentPosition, Quaternion.identity, terrainHolder);        
        currentPosition.x++;

        Destroy(terrain, 30);
    }
}
 