﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public GameObject originParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime;

        Debug.DrawLine(currentPosition, newPosition, Color.red);

        RaycastHit2D[] hits = Physics2D.LinecastAll(currentPosition, newPosition);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject != originParent)
            {
                Destroy(gameObject);

                // ToDo: Add Player Health Check
            }
        }

        this.transform.position = newPosition;
    }
}
