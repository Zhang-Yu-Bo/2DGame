using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beverage : MonoBehaviour
{
	public Camera mainCam;
	//public Blur canBlur;

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
		if(other.gameObject.tag=="Player")
		{
			mainCam.GetComponent<Blur>().enabled = true;
			Destroy(this.gameObject);
		}
	}
}
