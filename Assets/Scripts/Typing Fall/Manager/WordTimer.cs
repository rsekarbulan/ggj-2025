using UnityEngine;

public class WordTimer : MonoBehaviour
{

    public WordManager wordManager;

    public float wordDelay = 1.5f; // Tetap konstan
    private float nextWordTime = 0f;
    private float currentTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inisialisasi waktu awal
        //nextWordTime = Time.time + wordDelay;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer >= nextWordTime)
        {
            if (wordManager.wordObj != null) return;

            wordManager.AddWord();
            nextWordTime = wordDelay; // Tidak mengubah wordDelay
            currentTimer = 0f;
        }
    }
}
