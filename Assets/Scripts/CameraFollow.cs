using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	Transform _Trans;

	// Start is called before the first frame update
	void Start()
    {
		_Trans = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 followPos = new Vector3(target.position.x, target.position.y, _Trans.position.z);
		if (followPos.x < 0)
			followPos.x = 0;
		else if (followPos.x > 50)
			followPos.x = 50;
		if (followPos.y < -27)
			followPos.y = -27;
		else if (followPos.y > 10)
			followPos.y = 10;
		//Debug.Log(followPos);
		_Trans.position = followPos;
	}
}
