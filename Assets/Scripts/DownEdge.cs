﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownEdge : MonoBehaviour
{
	public Rigidbody2D player;
	Rigidbody2D downEdge;
	Vector2 beginPos;
	public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
		downEdge = GetComponent<Rigidbody2D>();
		beginPos = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		mainCam.GetComponent<GrayScale>().enabled = false;
		player.transform.position = beginPos;
	}
}
