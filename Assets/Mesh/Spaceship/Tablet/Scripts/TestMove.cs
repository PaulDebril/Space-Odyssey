using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMove : MonoBehaviour
{
    private Vector3 startPosition;
    public float speed = 1.5f; // Vitesse de déplacement
    private float repeatDuration = 30.0f; // Durée totale de répétition
    private bool isMoving = false; // Initialisé à false pour empêcher le mouvement au lancement

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // Sauvegarder la position initiale
    }

    public void StartMovementCycle()
    {
        if (!isMoving) // Commence le cycle de mouvement seulement si l'objet n'est pas déjà en mouvement
        {
            StartCoroutine(MoveAndReset());
        }
    }

    public IEnumerator MoveAndReset()
    {
        float startTime = Time.time;

        while (Time.time - startTime < repeatDuration)
        {
            StartMoving();
            yield return new WaitForSeconds(4f); // Attendre 4 secondes
            ResetPosition();
        }
    }

    void StartMoving()
    {
        isMoving = true;
    }

    void StopMoving()
    {
        isMoving = false;
    }

    void ResetPosition()
    {
        transform.position = startPosition;
        StopMoving();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed);
    }
}
