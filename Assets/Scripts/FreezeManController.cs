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
    public GameObject freezeBall;
    public float roleEdgeX;

    private float doubleClick = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

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
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            this.speed = this.MAX_SPEED;
        }
        else
            this.speed = 0;
        if (Input.GetKeyDown(KeyCode.J))
        {
            this.animator.SetTrigger("Attack");
            Vector3 position = this.gameObject.transform.position;
            Quaternion rotation = this.gameObject.transform.rotation;
            if (this.gameObject.transform.eulerAngles.y == 180)
                position += Vector3.left * this.roleEdgeX;
            else
                position += Vector3.right * this.roleEdgeX;
            Instantiate(this.freezeBall, position, rotation);
        }

        this.isOnTheGround = this.DetectGround();
        if (this.isOnTheGround && Input.GetKeyDown(KeyCode.W))
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(this.jumpPower * Vector2.up);
            this.animator.SetBool("Jump", true);
        }
        else if (!this.isOnTheGround)
            this.MAX_SPEED = 0.5f;

        this.animator.SetFloat("Speed", this.speed);
        this.gameObject.transform.Translate(Vector3.right * this.speed * this.sensitivity);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        this.isOnTheGround = true;
    //        this.animator.SetBool("Jump", false);
    //    }
    //}
    //
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        this.isOnTheGround = false;
    //        this.animator.SetBool("Jump", true);
    //    }
    //}

    private bool DetectGround()
    {
        Vector2 temp = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1f);
        Ray2D ray1 = new Ray2D(temp + Vector2.right * 0.5f, Vector2.down);
        Ray2D ray2 = new Ray2D(temp, Vector2.down);
        Ray2D ray3 = new Ray2D(temp + Vector2.left * 0.5f, Vector2.down);
        RaycastHit2D hit1 = Physics2D.Raycast(ray1.origin, ray1.direction);
        RaycastHit2D hit2 = Physics2D.Raycast(ray2.origin, ray2.direction);
        RaycastHit2D hit3 = Physics2D.Raycast(ray3.origin, ray3.direction);
        if (hit2)
        {
            Debug.DrawLine(ray2.origin, hit2.point, Color.red);
            if (hit2.collider.gameObject.tag == "Ground" && hit2.distance == 0)
            {
                this.animator.SetBool("Jump", false);
                return true;
            }
        }
        if (hit1)
        {
            Debug.DrawLine(ray1.origin, hit1.point, Color.red);
            if (hit1.collider.gameObject.tag == "Ground" && hit1.distance == 0)
            {
                this.animator.SetBool("Jump", false);
                return true;
            }
        }
        if (hit3)
        {
            Debug.DrawLine(ray3.origin, hit3.point, Color.red);
            if (hit3.collider.gameObject.tag == "Ground" && hit3.distance == 0)
            {
                this.animator.SetBool("Jump", false);
                return true;
            }
        }
        this.animator.SetBool("Jump", true);
        return false;
    }

}
