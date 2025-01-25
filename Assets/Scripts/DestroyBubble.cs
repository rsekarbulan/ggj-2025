using UnityEngine;

public class DestroyBubble : MonoBehaviour
{
    private bool isPopped = false;
    private CircleCollider2D circleCollider;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroy"))
        {
            Destroy(gameObject);
            //reduce life
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (isPopped)
            {
                //add score
            }
            else
            {
                circleCollider.isTrigger = true;
            }
        }
    }
}
