using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public Collider2D collider2D; // Collider yang digunakan
    public string playerTag = "Player"; // Tag untuk mendeteksi pemain
    public string destroyTag = "Destroy"; // Tag untuk mendeteksi objek penghancur
    private bool wordCompleted = false; // Status apakah kata telah diisi sepenuhnya
    private bool isPopped = false; // Status apakah objek sudah "pecah"

    private CircleCollider2D circleCollider;
    private Health health;
    private GameObject player;

    private void Start()
    {
        // Inisialisasi collider jika belum diassign
        if (collider2D == null)
            collider2D = GetComponent<Collider2D>();

        // Mencari Player di scene
        player = GameObject.Find("Player");
        if (player != null)
        {
            /*health = player.GetComponent<Health>();
            if (health == null)
            {
                Debug.LogWarning("Health component NOT found on Player!");
            }*/
        }
        else
        {
            Debug.LogWarning("Player NOT found in the scene!");
        }

        // Inisialisasi CircleCollider2D
        circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider == null)
        {
            Debug.LogWarning("CircleCollider2D NOT found on this GameObject!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"OnTriggerEnter2D with {other.gameObject.name}, wordCompleted: {wordCompleted}");

        if (wordCompleted && other.CompareTag(playerTag))
        {
            Debug.Log("Trigger detected. Destroying object...");
            DestroyParentOrSelf();
            ResetWordCompleted();
        }

        if (other.CompareTag(destroyTag))
        {
            DestroyParentOrSelf();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log($"OnTriggerStay2D with {other.gameObject.name}, wordCompleted: {wordCompleted}");

        if (wordCompleted && other.CompareTag(playerTag))
        {
            ExecuteDestruction();
            ResetWordCompleted();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag))
        {
            if (isPopped)
            {
                // Tambahkan skor (jika diperlukan)
            }
            else
            {
                if (circleCollider != null)
                {
                    circleCollider.isTrigger = true;
                }
            }
        }
    }

    public void EnableDestruction()
    {
        if (!wordCompleted)
        {
            wordCompleted = true;
            Debug.Log("wordCompleted set to true.");
        }
    }

    private void ResetWordCompleted()
    {
        wordCompleted = false;
        Debug.Log("wordCompleted reset to false.");
    }

    private void DestroyParentOrSelf()
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

    private void ExecuteDestruction()
    {
        DestroyParentOrSelf();
    }
}
