using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void Start()
    {
        if (string.IsNullOrEmpty(PlayerSpawnData.spawnPointName))
        {
            return;
        }

        GameObject spawnPoint = GameObject.Find(PlayerSpawnData.spawnPointName);

        if (spawnPoint == null)
        {
            Debug.LogWarning("Spawn point not found: " + PlayerSpawnData.spawnPointName);
            return;
        }

        transform.position = spawnPoint.transform.position;
    }
}