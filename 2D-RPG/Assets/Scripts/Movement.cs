using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;

    public Animator animator;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 direction = new Vector3(horizontal, vertical).normalized;

        AnimateMovement(direction, isRunning);

        transform.position += direction * currentSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Animation for players movement.
    /// </summary>
    /// <param name="direction">Direction the player moves to.</param>
    /// <param name="isRunning">Player is running or walking.</param>
    private void AnimateMovement(Vector3 direction, bool isRunning)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
