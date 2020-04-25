using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeManController : MonoBehaviour
{
    public Animator animator;
    public float speed = 0.0f;
    public float sensitivity;
    public float delayCheckTime = 0.3f;
    public bool isOnTheGround = false;
    public float jumpPower;
    public float MAX_SPEED = 0.5f;
    public float MIN_SPEED = 0.0f;

    private float doubleClick = 0.0f;
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.CharacterMove();
        
    }

    void CharacterMove()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            if (Time.time - this.doubleClick < this.delayCheckTime && this.isOnTheGround)
                this.MAX_SPEED = 1.0f;
            else
                this.MAX_SPEED = 0.5f;
                this.doubleClick = Time.time;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            this.speed = this.MAX_SPEED;
        }else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            this.speed = this.MAX_SPEED;
        }
        else
        {
            this.speed = 0;
        }
        if (this.isOnTheGround && Input.GetKeyDown(KeyCode.W))
        {
            this.rigidbody2D.AddForce(this.jumpPower * Vector2.up);
        }
        else
        {
            if (!this.isOnTheGround)
                this.MAX_SPEED = 0.5f;
        }

        this.animator.SetFloat("Speed", this.speed);
        this.gameObject.transform.Translate(Vector3.right * this.speed * this.sensitivity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.isOnTheGround = true;
            this.animator.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.isOnTheGround = false;
            this.animator.SetBool("Jump", true);
        }
    }

}
