using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Transform characterVisual;

    private Vector2 movement;
    private Vector2 currentVelocity;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector2 rawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        movement = Vector2.SmoothDamp(movement, rawInput, ref currentVelocity, 0.05f);

        if (movement.x > 0)
            characterVisual.localScale = new Vector3(1, 1, 1);
        else if (movement.x < 0)
            characterVisual.localScale = new Vector3(-1, 1, 1);

        anim.SetFloat("speed", movement.magnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}