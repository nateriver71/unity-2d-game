using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody2D))]
public class GunManager : MonoBehaviour
{
    [Header("Shooting projection")]
    public GameObject crosshair;
    public GameObject projectile;

    private float ARROW_BASE_SPEED = 75.0f;
    private float SHOOT_TIME_DELAY = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AsyncGetKey());
    }

    // Update is called once per frame
    void Update()
    {
        MoveCrosshair();
    }

    void FixedUpdate()
    {

    }

    void MoveCrosshair()
    {
        Vector3 aim = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        if (aim.magnitude > 0.0f)
        {
            aim.Normalize();
            aim *= 0.65f;
            crosshair.transform.localPosition = aim;
            crosshair.SetActive(true);
        }
        else
        {
            crosshair.SetActive(false);
        }
    }

    void Shoot()
    {
        Vector2 shootDirection = crosshair.transform.localPosition;
        shootDirection.Normalize();

        GameObject bullet_ = Instantiate(projectile, this.transform.position, Quaternion.identity);
        Bullet bullet = bullet_.GetComponent<Bullet>();
        bullet.velocity = shootDirection * ARROW_BASE_SPEED;
        bullet.originParent = gameObject;
        bullet_.transform.Rotate(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);

        Destroy(bullet_, 10f); // destroy bullet after 10 second if stuck or not doing anything
    }

    IEnumerator AsyncGetKey()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space)) // Hard coded maybe use more input system method
            {
                Debug.Log("Shoot");
                Shoot();
            }
            yield return new WaitForSeconds(SHOOT_TIME_DELAY);
        }
    }
}
