using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
	public int attackCount;
	public Material m_Material;
	public Shader freeze, normal;

    // Start is called before the first frame update
    void Start()
    {
		attackCount = 0;
		normal = m_Material.shader;
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Freeze Ball")
		{
			attackCount++;
			if (attackCount == 1)
				m_Material.shader = freeze;
			else if (attackCount == 2)
			{
				m_Material.shader = normal;
				Destroy(this.gameObject);
			}
		}
	}
}
