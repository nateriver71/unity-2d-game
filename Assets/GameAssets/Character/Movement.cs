using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float mspeed = 13f;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);


            transform.position = transform.position + horizontal * mspeed * Time.deltaTime;

            transform.position = transform.position + vertical * mspeed * Time.deltaTime;



    }
}
