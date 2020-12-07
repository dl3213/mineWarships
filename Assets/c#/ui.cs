using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform fly;
    Transform slider;

    void Start()
    {
        slider = this.transform.Find("Slider");
        // print(fly.GetComponent<boomer>().moveSpeed);
        slider.GetComponent<Slider>().maxValue = fly.GetComponent<F18>().MaMax;
    }

    // Update is called once per frame
    void Update()
    {
        slider.GetComponent<Slider>().value = fly.GetComponent<F18>().Ma;
        
    }

    public void speedChange()
    {

    }
}
