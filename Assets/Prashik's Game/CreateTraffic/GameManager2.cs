using UnityEngine;
using UnityEngine.SceneManagement; // For scene reloading

public class GameManager2 : MonoBehaviour
{
    public GameObject carPrefab; // Reference to the car prefab
    public GameObject spawnPoint; // Reference to the empty GameObject that defines the spawn position
    public float spawnInterval = 2f; // Interval between car spawns
    public float minZ = -10f; // Minimum Z position to spawn cars
    public float maxZ = 10f; // Maximum Z position to spawn cars

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCar();
            timer = 0f;
        }
    }

    void SpawnCar()
    {
        float spawnX = spawnPoint.transform.position.x;
        float spawnZ = Random.Range(minZ, maxZ);
        Vector3 spawnPosition = new Vector3(spawnX, 0.7786503f, spawnZ);
        Instantiate(carPrefab, spawnPosition, Quaternion.identity);
    }

    public void GameOver(bool won)
    {
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
}
