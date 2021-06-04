using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody2D))]
public class GunManager : MonoBehaviour
{
    
    public GameObject shootTargetPrefab;
    private GameObject shootTarget;
    private Transform playerTransform;
    private Rigidbody2D playerRb;
    private Vector2 move_direction;
    private float delta = 10f;
    private float delayShoot = 0.1f;

    //prefab object to shoot
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRb = GetComponent<Rigidbody2D>();
        shootTarget = Instantiate<GameObject>(shootTargetPrefab);
        shootTarget.transform.position = playerTransform.position;

        StartCoroutine(AsyncGetKey());
    }

    // Update is called once per frame
    void Update()
    {
        move_direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (move_direction != Vector2.zero)
        {
            Debug.DrawRay(playerTransform.position, move_direction * 5.0f, Color.red);
            shootTarget.transform.position = playerTransform.position + new Vector3(move_direction.x * delta, move_direction.y * delta, 0);
        }
    }

    void FixedUpdate()
    {

    }

    void Shoot()
    {
        Vector2 shootDirection = move_direction.normalized;
        if (shootDirection != Vector2.zero)
        {
            GameObject arrows = Instantiate(projectile, playerTransform.position, Quaternion.identity);
            //arrows.GetComponent<Rigidbody2D>().velocity = shootDirection * 5.0f/*speed*/;
            arrows.GetComponent<Bullet>().moveDirection = shootDirection * 5.0f;
            arrows.transform.Rotate(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);
            Destroy(arrows, 2f);
        }
    }

    IEnumerator AsyncGetKey()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
            }
            yield return new WaitForSeconds(delayShoot);
        }
    }
}
