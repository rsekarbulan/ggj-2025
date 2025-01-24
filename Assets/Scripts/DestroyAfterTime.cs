using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime = 3f;

    void Start()
    {
        // Memulai penghancuran GameObject setelah waktu tertentu
        Destroy(gameObject, destroyTime);
    }
}
