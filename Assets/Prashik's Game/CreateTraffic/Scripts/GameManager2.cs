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
    public bool gameWon = false; // Variable to track if the game is won
    private List<GameObject> activeCars = new List<GameObject>(); // List to track active cars

    void Update()
    {
        if (gameWon)
        {
            return; // Stop updating if the game is won
        }

        timer += Time.deltaTime;

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

        // Remove destroyed cars from the activeCars list
        activeCars.RemoveAll(car => car == null);
    }

    public void GameOver(bool won)
    {
        gameWon = won; // Set gameWon to the passed value

        if (won)
        {
            Debug.Log("You Win!");
            // Add any additional win logic here, such as displaying a win message
        }
        else
        {
            Debug.Log("You Lose!");
            // Add any additional lose logic here, such as displaying a lose message
        }

        // Reload the scene or stop the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameWon()
    {
        return gameWon;
    }
}
