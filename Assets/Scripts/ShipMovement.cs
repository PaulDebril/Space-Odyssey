using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 5;
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
        shipTransform.position = new Vector3(0, 0, 0);
    }

    void Start()
    {
        shipTransform = ship.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldStart) return;
        shipTransform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}