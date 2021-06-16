using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingManagerScript : MonoBehaviour
{
    public TextMeshProUGUI loading_text;

    private string loading_dots = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startAnim());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator startAnim()
    {
        while (true)
        {
            if (loading_dots.Length <= 3)
            {
                loading_dots += ".";
            }
            else
            {
                loading_dots = ".";
            }

            loading_text.text = "Loading"+loading_dots;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
