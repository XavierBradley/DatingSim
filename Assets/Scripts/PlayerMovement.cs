using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    private string currentAnimation = "";
    private string lastDirection = "Down";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        if (movement != Vector2.zero)
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0)
                {
                    lastDirection = "Right";
                    PlayAnimation("Player_Walk_Right");
                }
                else
                {
                    lastDirection = "Left";
                    PlayAnimation("Player_Walk_Left");
                }
            }
            else
            {
                if (movement.y > 0)
                {
                    lastDirection = "Up";
                    PlayAnimation("Player_Walk_Up");
                }
                else
                {
                    lastDirection = "Down";
                    PlayAnimation("Player_Walk_Down");
                }
            }
        }
        else
        {
            PlayAnimation("Player_Idle_" + lastDirection);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void PlayAnimation(string animationName)
    {
        if (currentAnimation == animationName)
        {
            return;
        }

        animator.Play(animationName);
        currentAnimation = animationName;
    }
}