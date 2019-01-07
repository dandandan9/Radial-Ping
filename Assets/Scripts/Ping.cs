using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ping : MonoBehaviour {

	public PingData pingData;
	public float lifeTime = 10f;
	private Image image;
	public GameObject player;
	public Vector3 raycastHitPoint;

	public Camera cam;

	private float minAlpha = 0.3f;
	private float maxAlpha = 0.9f;
	private float maxDistance = 55f;
	private float minDistance = 20f;

	[SerializeField]
	private Text text;

	// Use this for initialization
	void Start () {

		// Set the settings
		image = transform.GetChild(0).GetComponent<Image>();
		image.sprite = pingData.texture;
		image.color = pingData.colour;

		// Destroy the object after the lifetime
		Destroy( gameObject, lifeTime );
	}

	private void Update ()
	{
		// Set the new position
		transform.position = cam.WorldToScreenPoint( raycastHitPoint ) + new Vector3( 0, image.sprite.bounds.extents.y, 0 );

		int distance = (int) Vector3.Distance( raycastHitPoint, player.transform.position );

		updateText( distance );
		updateAlpha( distance );
	}

	private void updateText( int distance )
	{
		text.text = distance.ToString() + "m";
	}

	private void updateAlpha( int distance )
	{
		Color col = image.color;

		if(distance <= 20)
		{
			col.a = maxAlpha;
		}
		else
		{
			float fraction = ( distance - minDistance ) / ( maxDistance - minDistance );
			col.a = Mathf.Lerp( maxAlpha, minAlpha, fraction );
		}

		image.color = col;
	}
}
