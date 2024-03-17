using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    private int lives = 4;

    private void Start()
    {
        UpdateLivesUI();
    }

    // Hasar alýndýðýnda çaðrýlacak fonksiyon
    public void TakeDamage()
    {
        lives--; // Caný azalt
        UpdateLivesUI(); // Can UI'sýný güncelle
        if (lives <= 0)
        {
            // Eðer canlar tükenirse, oyunu bitir veya diðer iþlemleri yap
            Debug.Log("Game Over");
        }
    }

    // Can UI'sýný güncelleyen fonksiyon
    private void UpdateLivesUI()
    {
        switch (lives)
        {
            case 3:
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 1:
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
