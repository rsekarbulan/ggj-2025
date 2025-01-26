using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public TMP_Text text; // Ganti dengan TMP_Text
    public float fallSpeed = 0.5f;

    public Words words;

    private SpriteRenderer spriteRenderer; // Untuk menampilkan sprite
    private ParticleSystem particleSystem; // Untuk efek partikel

    private void Start()
    {
        // Mendapatkan referensi ke komponen SpriteRenderer
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = words.sprite1; // Atur sprite awal
        }

        // Mendapatkan referensi ke ParticleSystem
        particleSystem = Instantiate(words.particleEffect, transform); // Buat instance efek partikel
        particleSystem.Stop(); // Hentikan efek partikel pada awalnya
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
            CompleteWord();
        }
    }

    private void CompleteWord()
    {
        Debug.Log("Word completed and triggering sprite change."); // Debug log untuk metode CompleteWord

        // Hilangkan Sprite 1
        if (spriteRenderer != null && spriteRenderer.sprite == words.sprite1)
        {
            spriteRenderer.sprite = words.sprite2; // Ubah ke Sprite 2
        }

        // Aktifkan efek partikel
        if (particleSystem != null)
        {
            particleSystem.Play(); // Mainkan efek partikel
        }

        // Hancurkan objek setelah efek partikel selesai (opsional)
        //Destroy(gameObject, particleSystem.main.duration);
    }

    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }
}
