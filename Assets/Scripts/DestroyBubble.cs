using UnityEngine;

public class DestroyBubble : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
