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
		if (Input.GetKey(KeyCode.RightArrow))
		{
			_Trans.Translate(new Vector2(10 * Time.deltaTime, 0));
		}
		else if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			_Trans.Translate(new Vector2(-10 * Time.deltaTime, 0));
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
			_Trans.Translate(new Vector2(0, 10 * Time.deltaTime));
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			_Trans.Translate(new Vector2(0, -10 * Time.deltaTime));
		}
	}
}
