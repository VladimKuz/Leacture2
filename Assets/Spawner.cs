using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
     [Header("Настройки кубов")]
    public GameObject cubePrefab; 
    
    public int cubeCount = 8; 
    
    public float radius = 5f; 
    
    public float rotationSpeed = 50f; 
    
    public int direction = 1; 

    public bool isUniform = true;

    private List<Transform> cubes = new List<Transform>();

    void Start()
    {
         GenerateCubes();
    }

    
    void Update()
    {
         transform.Rotate(Vector3.up, rotationSpeed * direction * Time.deltaTime);
    }

    void GenerateCubes()
    {
        
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        cubes.Clear();

        for (int i = 0; i < cubeCount; i++)
        {
            GameObject newCube = Instantiate(cubePrefab, transform);
            
            
            cubes.Add(newCube.transform);
            
            PositionCube(newCube.transform, i);
        }
    }

    void PositionCube(Transform cube, int index)
    {
        float angleStep;

        if (isUniform)
        {
            
            angleStep = 360f / cubeCount;
        }
        else
        {
   
            angleStep = 20f; 
        }

        
        float angle = index * angleStep * Mathf.Deg2Rad;

        // Вычисляем координаты X и Z
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        
        cube.localPosition = new Vector3(x, 0, z);
    }
    
}
