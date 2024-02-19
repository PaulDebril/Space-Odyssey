using UnityEngine;
using TMPro; // N'oubliez pas cette directive pour utiliser TextMeshPro

public class BasketScore : MonoBehaviour
{
    public int score = 0; // Variable pour stocker le score
    public TMP_Text scoreText; // Référence publique au texte du score dans l'UI

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball")) // Assurez-vous que le ballon est tagué "Ball"
        {
            score++; // Incrémente le score
            UpdateScoreText(); // Appelle la fonction pour mettre à jour le texte du score
        }
    }

    // Fonction pour mettre à jour le texte du score
    void UpdateScoreText()
    {
        if (scoreText != null) // Vérifie si scoreText est bien référencé
        {
            scoreText.text = ""+score; // Met à jour le texte du score
        }
        else
        {
            Debug.LogWarning("Score Text not set in the inspector");
        }
    }
}
