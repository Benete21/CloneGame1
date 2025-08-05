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

    public bool Enemy1 = false;
    public bool Enemy2 = false;

    public GameObject enenmy_01Object;
    public GameObject enenmy_02Object;

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy_1"))
        {
            Enemy2 = false;
            Enemy1 = true;
            StartCoroutine(Enemy_01Destroy());
        }
        else if (collision.CompareTag("Enemy_2"))
        {
            Enemy1 = false;
            Enemy2 = true;
            StartCoroutine(Enemy_02Destroy());
        }
    }

    IEnumerator Enemy_01Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(enenmy_01Object);
    }
    IEnumerator Enemy_02Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(enenmy_02Object);
    }
}