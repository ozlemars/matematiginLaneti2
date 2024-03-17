using UnityEngine;

public class CanavarTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Oyuncu canavarýn yanýna girdi!");
            // Burada gerekli iþlemleri gerçekleþtirin, örneðin matematik sorusu sormak için LivesController gibi bir scripti çaðýrabilirsiniz.
        }
    }
}
