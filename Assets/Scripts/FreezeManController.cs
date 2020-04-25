using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeManController : MonoBehaviour
{
    public Animator animator;
    public float speed = 0.0f;
    public float sensitivity;
    public string currentState = "Idle";
    public float delayCheckTime = 0.3f;

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
        this.GetCurrentMoveState();
        if (this.currentState == "Idle")
        {
            this.speed = 0.0f;
        }
        else if (this.currentState == "Walk")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            this.speed = 0.5f;
        }
        else if (this.currentState == "WalkInvert")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            this.speed = 0.5f;
        }
        else if (this.currentState == "Run")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            this.speed = 1.0f;
        }
        else if (this.currentState == "RunInvert")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            this.speed = 1.0f;
        }

        animator.SetFloat("Speed", this.speed);
        this.gameObject.transform.Translate(Vector3.right * this.speed * this.sensitivity);
    }

    void GetCurrentMoveState()
    {
        // Set the state machine of moving
        // set walk
        if (this.currentState == "Idle" && Input.GetKeyDown(KeyCode.D))
            this.currentState = "Walk";
        // set walk invert
        if (this.currentState == "Idle" && Input.GetKeyDown(KeyCode.A))
            this.currentState = "WalkInvert";
        // set run
        if ((this.currentState == "Idle" || this.currentState == "Walk") && Input.GetKeyDown(KeyCode.D))
        {
            if (Time.time - this.doubleClick < this.delayCheckTime)
                this.currentState = "Run";
            this.doubleClick = Time.time;
        }
        // set run invert
        if ((this.currentState == "Idle" || this.currentState == "WalkInvert") && Input.GetKeyDown(KeyCode.A))
        {
            if (Time.time - this.doubleClick < this.delayCheckTime)
                this.currentState = "RunInvert";
            this.doubleClick = Time.time;
        }
        // set idle
        if ((this.currentState == "Walk" || this.currentState == "Run") && Input.GetKeyUp(KeyCode.D))
            this.currentState = "Idle";
        if ((this.currentState == "WalkInvert" || this.currentState == "RunInvert") && Input.GetKeyUp(KeyCode.A))
            this.currentState = "Idle";
    }
}
