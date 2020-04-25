using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBallScript : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!this.stop)
        {
            this.gameObject.transform.Translate(Vector3.right * this.speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            this.stop = true;
            this.animator.SetTrigger("Break");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

}
