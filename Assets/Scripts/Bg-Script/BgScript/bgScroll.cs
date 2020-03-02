using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroll : MonoBehaviour {

	public float scroll_speed = 0.3f;
	private MeshRenderer mesh_Renderer;
	private string _MainTexture = "_MainTex";
	void Awake() {
		mesh_Renderer = GetComponent<MeshRenderer>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Scroll();
	}
	void Scroll()
	{
		//Getting offset of texture
		Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset(_MainTexture);
		//increse its y-axis value
		offset.y -= Time.deltaTime * scroll_speed;
		//Setting new Offset to texture
		mesh_Renderer.sharedMaterial.SetTextureOffset(_MainTexture,offset); 
	}
}
