using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayer
{
    public event Action LvlComplete;
    public event Action Dead;

    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private Camera cam;
    [SerializeField] private float dampingSpeed;
    
    public void Damage()
    {
        Destroy(gameObject);
        Dead?.Invoke();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        CharacterMovement();
    }

    private void FixedUpdate()
    {
        cam.transform.position = Vector3.Lerp(new Vector3(cam.transform.position.x, cam.transform.position.y, -10), transform.position, Time.deltaTime * dampingSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }

    public void CharacterMovement()
    {
        float playerInputDir = Input.GetAxis("Horizontal");
        animator.SetFloat("MoveSpeed", Mathf.Abs(playerInputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + playerInputDir, transform.position.y, 0), Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");    
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
