using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayScale : MonoBehaviour
{
	protected Material m_Material;
	public Shader m_Shader;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (m_Shader != null && m_Material == null)
		{
			m_Material = new Material(m_Shader);
			m_Material.hideFlags = HideFlags.DontSave;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture dest)
	{
		if (m_Material != null)
		{
			Graphics.Blit(source, dest, m_Material);
		}
		else Graphics.Blit(source, dest);
	}
}
