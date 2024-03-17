using UnityEngine;

public class CanavarTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Oyuncu canavar�n yan�na girdi!");
            // Burada gerekli i�lemleri ger�ekle�tirin, �rne�in matematik sorusu sormak i�in LivesController gibi bir scripti �a��rabilirsiniz.
        }
    }
}
