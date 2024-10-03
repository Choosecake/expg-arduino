using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    float moveSpeed = 10f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.drag = 2f;
        transform.Rotate(transform.forward, Random.Range(5, 355));
    }

    private void Update()
    {
        rigidbody.velocity = transform.up * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            var initialDir = collision.transform.position - transform.position;
            var wallAngle = Vector3.zero;
            if (collision.gameObject.name == "up")
            {
                wallAngle = new Vector3(0, 0, 180);
            }
            if (collision.gameObject.name == "down")
            {
                wallAngle = new Vector3(0, 0, 0);
            }
            if (collision.gameObject.name == "left")
            {
                wallAngle = new Vector3(0, 0, 90);
            }
            if (collision.gameObject.name == "right")
            {
                wallAngle = new Vector3(0, 0, 270);
            }

            transform.Rotate(transform.forward, wallAngle.z - transform.rotation.z);
        }
    }
}
