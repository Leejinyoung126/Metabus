using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movementDirection;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovementInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void HandleMovementInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(h, v).normalized;
    }

    private void Move()
    {
        _rigidbody.velocity = movementDirection * moveSpeed;
    }
}

