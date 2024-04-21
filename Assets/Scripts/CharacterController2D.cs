using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float dashForce = 20f;
    public float dashTime = 0.2f; 
    public float coolDownTime = 1f;
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    private bool isGrounded;
    private bool canDash = true;
    private float dashTimer;
    private float dashCoolDownTimer;
    private float horizontalMove;
    private Animator characterAnimator;
    public bool IsAttacking;

    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {


        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundLayer);

        Debug.DrawRay(transform.position, Vector3.down *0.5f, Color.red );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            characterAnimator.SetBool("IsJumping", true);
        }
        else
        {
            characterAnimator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && isGrounded)
        {
            canDash = false;
            dashTimer = dashTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsAttacking = true;
            characterAnimator.SetBool("IsAttackingL", true);
            float attackDelay = 1.02f;
            StartCoroutine(AttackComplete());
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            IsAttacking = true;
            characterAnimator.SetBool("IsAttackingH", true);
            float attackDelay = 1.02f;
            StartCoroutine(AttackComplete());

        }


        dashCoolDownTimer += Time.deltaTime;
        if (dashCoolDownTimer >= coolDownTime)
        {
            canDash = true;
            dashCoolDownTimer = 0f;
        }


        characterAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        characterAnimator.SetFloat("YVelocity", rb.velocity.y);
    }

    IEnumerator AttackComplete()
    {
        yield return new WaitForSeconds(1.02f);
        Debug.Log("Hit");
        characterAnimator.SetBool("IsAttackingL", false);
        characterAnimator.SetBool("IsAttackingH", false);
        yield return new WaitForSeconds(0.3f);
        IsAttacking = false;
        
    }


    private void FixedUpdate()
    {
        if (!IsAttacking)
        {
            horizontalMove = Input.GetAxis("Horizontal");


            if (dashTimer > 0f)
            {
                rb.velocity = new Vector2(horizontalMove * dashForce, rb.velocity.y);
                dashTimer -= Time.deltaTime;
            }
            else
            {
                rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
            }

            if (horizontalMove > 0f && transform.localScale.x < 0f || horizontalMove < 0f && transform.localScale.x > 0f)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        
    }
}

