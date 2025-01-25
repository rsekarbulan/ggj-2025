using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public TMP_Text text; // Ganti dengan TMP_Text
    public float fallSpeed = 0.5f;
    private SpriteChanger spriteChanger; // Referensi ke SpriteChanger
    private ColliderManager colliderManager; // Referensi ke ColliderManager

    private void Start()
    {
        // Mencoba mendapatkan komponen SpriteChanger dari child GameObject
        spriteChanger = GetComponentInChildren<SpriteChanger>();

        // Debugging apakah spriteChanger berhasil diambil atau tidak
        if (spriteChanger != null)
        {
            Debug.Log("SpriteChanger ditemukan pada child GameObject.");
        }
        else
        {
            Debug.LogWarning("SpriteChanger TIDAK ditemukan pada child GameObject. Pastikan komponen terpasang.");
        }

        // Mencoba mendapatkan komponen ColliderManager
        colliderManager = GetComponentInChildren<ColliderManager>();

        // Debugging apakah colliderManager berhasil diambil atau tidak
        if (colliderManager != null)
        {
            Debug.Log("ColliderManager ditemukan pada GameObject.");
        }
        else
        {
            Debug.LogWarning("ColliderManager TIDAK ditemukan pada GameObject. Pastikan komponen terpasang.");
        }
    }

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;

        if (string.IsNullOrEmpty(text.text)) // Jika kata selesai
        {
            Debug.Log($"Kata '{text.text}' selesai!"); // Debug log saat kata selesai
            CompleteWord();
        }
    }

    public void RemoveWord()
    {
        // Tidak langsung destroy, ubah sprite terlebih dahulu
        if (spriteChanger != null)
        {
            spriteChanger.CompleteWord();
        }
    }

    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }

    private void CompleteWord()
    {
        Debug.Log("Word completed and triggering sprite change."); // Debug log untuk metode CompleteWord

        if (spriteChanger != null)
        {
            spriteChanger.CompleteWord();
        }

        // Aktifkan penghancuran collider saat kata selesai
        if (colliderManager != null)
        {
            colliderManager.EnableDestruction();
        }
    }
}
