using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerrb;
    public float movespeed = 5f;
    public float negativelimitX = -1.67f;
    public float positivelimitX = 1.67f;
    public float adjuster = 1.5f;

    void Start()
    {
        playerrb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        transform.position += transform.forward * movespeed * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {

            var mousePos = Input.mousePosition;

            var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

            transform.position = new Vector3(Mathf.Clamp(wantedPos.x / adjuster, negativelimitX, positivelimitX), transform.position.y, transform.position.z);

        }
        else
        {
        
        }

    }

}

