using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNodes : MonoBehaviour
{
    public GameObject star;
    public GameObject planet;
    public int galaxySize = 1500;
    public int planetsPerSystem = 10;
    public int solarSystemsPerCluster = 25;
    public int clusterCount = 5; // How many solar system clusters we want
    public int clusterSize = 700;
    public int solarSystemSize = 50;
    List<Vector3> systemClusters; // List of locations for each solar system cluster
    List<Vector3> solarSystems; // List of locations for each solar system


    void Start()
    {
        systemClusters = new List<Vector3>();
        solarSystems = new List<Vector3>();
        GenerateSystemClusters();
        GenerateSolarSystems();
        GenerateStars();
    }

    void GenerateSystemClusters()
    {
        for (int i = 0; i < clusterCount; i++)
        {
            float randomx = Random.Range(-galaxySize, galaxySize);
            float randomy = Random.Range(-galaxySize, galaxySize);
            float randomz = Random.Range(-galaxySize, galaxySize);
            systemClusters.Add(new Vector3(randomx, randomy, randomz));
        }
    }

    void GenerateSolarSystems()
    {
        for (int i = 0; i < systemClusters.Count; i++)
        {
            for (int j = 0; j < solarSystemsPerCluster; j++)
            {
                float randomx = Random.Range(-clusterSize, clusterSize);
                float randomy = Random.Range(-clusterSize, clusterSize);
                float randomz = Random.Range(-clusterSize, clusterSize);
                solarSystems.Add(systemClusters[i] + new Vector3(randomx, randomy, randomz));
            }
        }
    }

    void GenerateStars()
    {
        for (int i = 0; i < solarSystems.Count; i++)
        {
            GameObject solarSystemParent = new GameObject("Solar System");
            Instantiate(star, solarSystems[i], transform.rotation, solarSystemParent.transform);
            for (int j = 0; j < planetsPerSystem; j++)
            {
                AddPlanet(solarSystems[i], solarSystemParent.transform);
            }
        }
    }

    void AddPlanet(Vector3 center, Transform parentTransform)
    {
        float randomx = Random.Range(-solarSystemSize, solarSystemSize);
        float randomy = Random.Range(-solarSystemSize, solarSystemSize);
        float randomz = Random.Range(-solarSystemSize, solarSystemSize);
        Vector3 position = new Vector3(center.x + randomx, center.y + randomy, center.z + randomz);
        Instantiate(planet, position, transform.rotation, parentTransform);
    }
}
