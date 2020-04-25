using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeManController : MonoBehaviour
{
    public Animator animator;
    public float MAX_SPEED = 1.0f;
    public float MIN_SPEED = 0.0f;
    public float speed = 0.0f;
    public float sensitivity;

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
            if (Time.time - this.doubleClick < 0.3f)
                this.MAX_SPEED = 1.0f;
            else
                this.MAX_SPEED = 0.5f;
            this.doubleClick = Time.time;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            this.speed = 0.5f;
            if (this.MAX_SPEED > 0.5f)
                this.speed = this.MAX_SPEED;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            this.speed = 0.5f;
            if (this.MAX_SPEED > 0.5f)
                this.speed = this.MAX_SPEED;
        }
        else
        {
            this.speed = 0;
        }

        this.speed = Mathf.Clamp(this.speed, this.MIN_SPEED, this.MAX_SPEED);
        animator.SetFloat("Speed", this.speed);
        this.gameObject.transform.Translate(Vector3.right * this.speed * this.sensitivity);
    }
}
