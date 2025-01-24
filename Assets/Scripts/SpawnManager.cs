using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    public List<GameObject> prefabsToSpawn; // Daftar prefab yang akan di-spawn
    public float spawnY; // Posisi Y tempat spawn (tetap)
    public float minX; // Posisi X minimum untuk spawn point
    public float maxX; // Posisi X maksimum untuk spawn point
    public float spawnInterval = 1f; // Interval waktu antara spawn (dalam detik)

    private void Start()
    {
        // Memulai coroutine untuk spawn objek secara berulang
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Pilih prefab secara acak dari daftar
            GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Count)];

            // Membuat posisi spawn baru dengan X acak dan Y tetap
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), spawnY);

            // Instantiate prefab di posisi spawn
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // Menunggu sebelum melakukan spawn berikutnya
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
