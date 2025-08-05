using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public Vector3 targetEnemy1Position;
    public Vector3 targetEnemy2Position;
    public Vector3 originalPositionEnemy1;
    public Vector3 originalPositionEnemy2;

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
        if (collision.CompareTag("Enemy_2"))
        {
            Enemy2 = false;
            Enemy1 = true;
            StartCoroutine(Enemy_02Destroy());
        }
        else if (collision.CompareTag("Enemy_1"))
        {
            Enemy1 = false;
            Enemy2 = true;
            StartCoroutine(Enemy_01Destroy());
        }
    }

    IEnumerator Enemy_01Destroy()
    {

        // Move to the new position
        enenmy_02Object.transform.position = targetEnemy1Position;


        // Wait for a few seconds
        yield return new WaitForSeconds(5);

        // Move back to original position
        enenmy_02Object.transform.position = originalPositionEnemy1;
    }
    IEnumerator Enemy_02Destroy()
    {


        // Move to the new position
        enenmy_01Object.transform.position = targetEnemy2Position;

        // Wait for a few seconds
        yield return new WaitForSeconds(5);

        // Move back to original position
        enenmy_01Object.transform.position = originalPositionEnemy2;
    }
}