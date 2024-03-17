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

    // Hasar al�nd���nda �a�r�lacak fonksiyon
    public void TakeDamage()
    {
        lives--; // Can� azalt
        UpdateLivesUI(); // Can UI's�n� g�ncelle
        if (lives <= 0)
        {
            // E�er canlar t�kenirse, oyunu bitir veya di�er i�lemleri yap
            Debug.Log("Game Over");
        }
    }

    // Can UI's�n� g�ncelleyen fonksiyon
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
