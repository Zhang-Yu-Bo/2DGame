using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffect : MonoBehaviour
{
	public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		mainCam.GetComponent<GrayScale>().enabled = true;
		mainCam.GetComponent<Blur>().enabled = false;
		mainCam.GetComponent<Neg>().enabled = false;
	}
}
