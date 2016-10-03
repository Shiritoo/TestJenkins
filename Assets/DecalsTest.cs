using UnityEngine;
using System.Collections;
using System.IO;

public class DecalsTest : MonoBehaviour {

	public Texture2D tex;
	public Texture2D decal;
	private Texture2D tmp;

	public int xOffset = 0;
	public int yOffset = 0;

	// Use this for initialization
	void Start ()
	{
		tmp = new Texture2D(tex.width, tex.height);

		Color[] texPix = tex.GetPixels ();
		Color[] decalPix = decal.GetPixels ();

		for (int x = 0; x < decal.width; ++x)
		{
			for (int y = 0; y < decal.height; ++y) 
			{
				texPix [(x + xOffset) + decal.width * (y + yOffset)] += decalPix [x + decal.width * y];
			}
		}
		
		tmp.SetPixels(texPix);
		tmp.Apply();

		/*byte[] bytes = app.EncodeToPNG ();
		File.WriteAllBytes (Application.dataPath + "/../SavedScreen.png", bytes);*/

		GetComponent<Renderer> ().material.mainTexture = tmp;
	}
	
	// Update is called once per frame
	void Update () {
	}


}
