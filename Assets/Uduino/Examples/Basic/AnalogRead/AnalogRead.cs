using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class AnalogRead : MonoBehaviour {

    UduinoManager u;
    public int readValue0 = 0;
    public int readValue1 = 0;

    void Start ()
    {
        UduinoManager.Instance.pinMode(AnalogPin.A0, PinMode.Input);
        UduinoManager.Instance.pinMode(AnalogPin.A1, PinMode.Input);
    }

    void Update ()
    {
        ReadValue();
        //print("pin 0 = " + readValue0);
        //print("pin 1 = " + readValue1);
    }

    void ReadValue()
    {
        readValue0 = UduinoManager.Instance.analogRead(AnalogPin.A0, "Pin0Read");
        readValue1 = UduinoManager.Instance.analogRead(AnalogPin.A1, "Pin1Read");

        UduinoManager.Instance.SendBundle("Pin0Read");
        UduinoManager.Instance.SendBundle("Pin1Read");
    }

}
