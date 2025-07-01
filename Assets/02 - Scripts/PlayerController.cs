using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h;
    private float v;
    private float r;


    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float turnSpeed = 200.0f;

    private Animator animator;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Animate();
    }

    private void Animate()
    {
        animator.SetFloat("Forward", v);
        animator.SetFloat("Strafe", h);
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);

        transform.Rotate(Vector3.up * Time.deltaTime * r * turnSpeed);
    }
}
