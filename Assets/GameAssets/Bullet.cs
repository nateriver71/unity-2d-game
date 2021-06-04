using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D bulletRb;
    public Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
    }
}
