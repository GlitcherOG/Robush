using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject slider;
    public Slider health;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (health.value == 1 || health.value == 0)
        {
            slider.SetActive(false);
        }
        else
        {
            slider.SetActive(true);
        }
    }
}
