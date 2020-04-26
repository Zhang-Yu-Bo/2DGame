using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNeg : MonoBehaviour
{
	public Camera mainCam;
	AudioSource au;
	// Start is called before the first frame update
	void Start()
	{
		au = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			mainCam.GetComponent<Neg>().enabled = true;
			mainCam.GetComponent<AudioSource>().Play(0);
			Destroy(this.gameObject);
		}
	}
}
