using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayer
{
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    
    public void Damage()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        CharacterMovement();
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
