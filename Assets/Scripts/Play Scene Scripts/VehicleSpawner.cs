using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vehicle;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeparationTime;
    [SerializeField] private float maxSeparationTime;
    [SerializeField] private bool isRightSide;

    void Start()
    {
        StartCoroutine(SpawnVehicle()); 
    }

    private IEnumerator SpawnVehicle()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
            
            GameObject go = Instantiate(vehicle, spawnPos.position, Quaternion.identity);
            
            Destroy(go, 13);

            if(!isRightSide)
            {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
