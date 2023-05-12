using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = 9.8f;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        // Position
        Vector2 axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        axis = axis.normalized * speed;

        // Rotation
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

        // Apply
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        transform.localRotation = Quaternion.Euler(0, angle, 0);
        _rb.velocity = new Vector3(axis.x, -gravity, axis.y);
    }
}
