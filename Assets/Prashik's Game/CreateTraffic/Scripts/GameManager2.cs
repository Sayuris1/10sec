using UnityEngine;
using UnityEngine.SceneManagement; // For scene reloading
using System.Collections.Generic;

public class GameManager2 : MonoBehaviour
{
    public GameObject carPrefab; // Reference to the car prefab
    public GameObject spawnPoint; // Reference to the empty GameObject that defines the spawn position
    public float spawnInterval = 2f; // Interval between car spawns
    public float minZ = -1f; // Minimum Z position to spawn cars
    public float maxZ = 1f; // Maximum Z position to spawn cars
    public float minSpawnDistance = 1f; // Minimum distance between spawned cars

    private float timer;
    private bool gameRunning = true; // Variable to track if the game is running
    private List<GameObject> activeCars = new List<GameObject>(); // List to track active cars

    void Update()
    {
        if (!gameRunning)
        {
            return; // Stop updating if the game is not running
        }

        timer += Time.deltaTime;

        // Spawn cars at intervals
        if (timer >= spawnInterval)
        {
            SpawnCar();
            timer = 0f;
        }
    }

    void SpawnCar()
    {
        // Calculate a random spawn position within the specified Z range
        float spawnX = spawnPoint.transform.position.x;
        float spawnZ = Random.Range(minZ, maxZ);
        Vector3 spawnPosition = new Vector3(spawnX, 0, spawnZ);

        // Check if the new car's spawn position is too close to any existing cars
        foreach (GameObject car in activeCars)
        {
            if (Vector3.Distance(spawnPosition, car.transform.position) < minSpawnDistance)
            {
                // If the distance is too small, skip spawning this car
                return;
            }
        }

        // Instantiate the car and add it to the activeCars list
        GameObject newCar = Instantiate(carPrefab, spawnPosition, Quaternion.identity);
        activeCars.Add(newCar);
    }

    public void GameOver(bool won)
    {
        gameRunning = false; // Stop the game

        if (won)
        {
            Debug.Log("You Win!");
            // Add any additional win logic here
        }
        else
        {
            Debug.Log("You Lose!");
            // Add any additional lose logic here
        }

        // Stop all cars and Granny
        foreach (var car in activeCars)
        {
            if (car != null)
            {
                car.GetComponent<Cars>().enabled = false; // Disable car movement
            }
        }

        // Disable Granny's movement
        GameObject granny = GameObject.FindGameObjectWithTag("Player");
        if (granny != null)
        {
            granny.GetComponent<Granny>().enabled = false; // Disable Granny's movement
        }

        // Optionally reload the scene or stop the game
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }
}
