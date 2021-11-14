using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] planes;
    [SerializeField] private IntVariable score;
    [SerializeField] private float startTimeToSpawn = 3;
    private int generateNumberOfPlane;
    private float timeToSpawn;
    private List<GameObject> avaiblePlanes = new List<GameObject>();

    private void Start()
    {
        score.Value = 0;
        for (int i = 0; i < planes.Length; i++)
        {
            avaiblePlanes.Add(planes[i]);
        }
    }
    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn <= 0)
        {
            SpawnPlane();
            timeToSpawn = startTimeToSpawn * 0.99f;
        }
    }
    private void SpawnPlane()
    {
        if (avaiblePlanes[0] != null)
        {
            generateNumberOfPlane = (int)Random.Range(0, avaiblePlanes.Count);
            avaiblePlanes[generateNumberOfPlane].SetActive(true);
            avaiblePlanes[generateNumberOfPlane].transform.position = spawnPoints[(int)Random.Range(0, spawnPoints.Length)].transform.position;
            avaiblePlanes[generateNumberOfPlane].GetComponent<PlaneController>().ResetPlaneData();
            avaiblePlanes.RemoveAt(generateNumberOfPlane);
        }
        else
        {
            timeToSpawn = startTimeToSpawn;
        }
    }
    public void CheckAvaiblePlanes(GameObject addPlane)
    {
        avaiblePlanes.Add(addPlane);
    }
}
