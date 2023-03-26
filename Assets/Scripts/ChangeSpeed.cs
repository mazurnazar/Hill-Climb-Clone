using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeSpeed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int speedDirection;
    private int speedChange = 5;
    [SerializeField] CarController carController;
    public bool pressed;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        carController.press= true;
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        carController.press = false;
        pressed = false;
    }

    void Update()
    {
        if (carController.press)
        {
            if (pressed) ChangeSpeedTo();
        }
        else ReturnToZeroSpeed();
    }
    void ChangeSpeedTo()
    {
        if (Mathf.Abs(carController.speed) < carController.maxSpeed)
        {
            carController.speed += speedDirection * speedChange * Time.deltaTime;
        }
    }
    void ReturnToZeroSpeed()
    {
        if(carController.speed<0) carController.speed = speedChange * Time.deltaTime;
        else carController.speed-=  speedChange * Time.deltaTime;
    }
}
