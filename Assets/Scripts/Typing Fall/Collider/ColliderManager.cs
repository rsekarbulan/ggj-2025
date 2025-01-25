using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public Collider2D collider2D; // Collider yang digunakan
    public string playerTag = "Player"; // Tag untuk mendeteksi pemain
    private bool wordCompleted = false; // Status apakah kata telah diisi sepenuhnya

    private void Start()
    {
        if (collider2D == null)
            collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // Jika collider mengenai objek dengan tag Player dan kata sudah selesai
        if (wordCompleted && other.CompareTag(playerTag))
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject); // Hancurkan GameObject parent
            }
            else
            {
                Destroy(gameObject); // Jika tidak ada parent, hancurkan GameObject ini
            }
        }
    }

    // Fungsi untuk mengaktifkan penghancuran collider
    public void EnableDestruction()
    {
        wordCompleted = true;
    }
}
