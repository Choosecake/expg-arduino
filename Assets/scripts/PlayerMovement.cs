using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    public AnalogRead analogRead;
    int value0 = 0;
    int value1 = 0;

    float moveSpeed = 10f;   // Increased for better responsiveness
    float thrustLimit = 1f;
    float rotationSpeed = 360f;  // Increased for faster rotation

    private void Start()
    {
        value1 = 0;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateAnalogValue();
        CalculateRotation();
        CalculateThrust();
    }

    void UpdateAnalogValue()
    {
        if (analogRead == null) return;

        value0 = analogRead.readValue0;
        value1 = analogRead.readValue1;
        //print ("0: " + value0);
        //print ("1: " + value1);
    }

    void CalculateRotation()
    {
        float normalizedRotation = NormalizeValue(value0, 0f, 1023f, -360, 360);
        Quaternion targetRotation = Quaternion.Euler(0, 0, normalizedRotation);

        // Faster, more direct rotation without smoothing effect
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void CalculateThrust()
    {
        float normalizedInput = NormalizeValue(value1, 0f, 1023f, thrustLimit, 0);
        Vector2 forceDirection = transform.up;
        float forceMagnitude = normalizedInput * moveSpeed;

        // Set velocity directly for more precise control
            rigidbody.velocity = forceDirection * forceMagnitude;

        // You could also add some damping to avoid excessive momentum buildup
        rigidbody.drag = 2f;  // Adjust this drag value for better responsiveness
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.Rotate(transform.forward, 180);
        }
    }

    float NormalizeValue(float inputValue, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        return ((inputValue - inputMin) / (inputMax - inputMin)) * (outputMax - outputMin) + outputMin;
    }
}
