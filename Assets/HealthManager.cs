using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{ 
    [Header("** Set This First **")]
    [SerializeField]
    [Range(1.0f, 100.0f)]
    private float localhealth = 100f;

    public GameObject HealthBarObj;
    public Gradient gradient;
    public Image fill;
    private Slider health_slider;

    // Start is called before the first frame update
    void Start()
    {
        health_slider = HealthBarObj.GetComponent<Slider>();
        InitHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getHit(float damage)
    {
        this.localhealth -= damage;
        SetHealth();
        if (this.localhealth < 1)
        {
            // add player check

            Destroy(gameObject);
        }
    }

    void InitHealth()
    {
        health_slider.maxValue = localhealth;
        health_slider.value = localhealth;
        gradient.Evaluate(1f);
    }
    void SetHealth()
    {
        health_slider.value = localhealth;
        fill.color = gradient.Evaluate(health_slider.normalizedValue);
    }
    void OnCollisionEnter2D(Collision2D coll) { }
}
