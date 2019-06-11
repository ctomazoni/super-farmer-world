using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidade;

    public Transform player;
    public Animator animator;

    public bool isGrounded;
    public float force;

    public float jumpTime = 0.4f;
    public float jumpDelay = 0.4f;
    public bool jumped = false;
    public Transform ground;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
    }

    void Movimentar()
    {
        isGrounded = Physics2D.Linecast(this.transform.position, ground.position, 1 << LayerMask.NameToLayer("Plataforma"));

        animator.SetFloat("run", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (Input.GetButtonDown("Jump") /*&& isGrounded*/ && !jumped)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * force);
            jumpTime = jumpDelay;
            animator.SetTrigger("jump");
            jumped = true;
        }

        jumpTime -= Time.deltaTime;

        if (jumpTime <= 0 /*&& isGrounded*/ && jumped)
        {
            animator.SetTrigger("ground");
            jumped = false;
        }
    }

}
