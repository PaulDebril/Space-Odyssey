using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 1;
    public GameObject ship;
    private Transform shipTransform;
    private bool shouldStart = false;

    public void StartMove()
    {
        shouldStart = true;
    }

    public void EndMove()
    {
        shouldStart = false;
    }

    void Start()
    {
        shipTransform = ship.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldStart) return;
        shipTransform.position += shipTransform.transform.forward * speed;
    }
}
