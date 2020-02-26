using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float maxSpeed;
    public float Speed;


    void Start()
    {
        UpdateSpeed();
    }
    public void UpdateSpeed()
    {
        Speed = slider.value * Time.deltaTime * maxSpeed; 
    }
}
