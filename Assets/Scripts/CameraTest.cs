using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
	Transform _Trans;

    // Start is called before the first frame update
    void Start()
    {
		_Trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(_Trans.position);
		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (_Trans.position.x < 50)
				_Trans.Translate(new Vector2(10 * Time.deltaTime, 0));
		}
		else if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			if(_Trans.position.x > 0)
				_Trans.Translate(new Vector2(-10 * Time.deltaTime, 0));
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
			if(_Trans.position.y<10)
				_Trans.Translate(new Vector2(0, 10 * Time.deltaTime));
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			if (_Trans.position.y > -27)
				_Trans.Translate(new Vector2(0, -10 * Time.deltaTime));
		}
	}
}
