using UnityEngine;

public class WordTimer : MonoBehaviour
{

    public float wordDelay = 1.5f; // Tetap konstan
    private float nextWordTime = 0f;
    private float currentTimer = 0f;
    [SerializeField] WordManager wordManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inisialisasi waktu awal
        nextWordTime = Time.time + wordDelay;
        //nextWordTime = Time.time + wordDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextWordTime)
            currentTimer += Time.deltaTime;
        if (currentTimer >= nextWordTime)
        {

            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay; // Tidak mengubah wordDelay
            nextWordTime = wordDelay; // Tidak mengubah wordDelay
            currentTimer = 0f;
        }
    }
}
