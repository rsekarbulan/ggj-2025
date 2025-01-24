using UnityEngine;

public class DragWithoutClick : MonoBehaviour
{
    [SerializeField] private Transform targetObject; // Objek yang akan mengikuti kursor
    private float initialY; // Menyimpan posisi awal di sumbu Y

    private void Start()
    {
        // Menyimpan posisi awal objek di sumbu Y
        if (targetObject != null)
        {
            initialY = targetObject.position.y;
        }
        else
        {
            Debug.LogError("Target Object belum diset di Inspector!");
        }
    }

    private void Update()
    {
        if (targetObject != null)
        {
            // Ambil posisi kursor di dunia
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Hanya ubah posisi di sumbu X, dengan mempertahankan sumbu Y tetap sama
            targetObject.position = new Vector3(mousePosition.x, initialY, targetObject.position.z);
        }
    }
}
