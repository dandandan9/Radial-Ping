using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialPingMenu : MonoBehaviour
{

	enum PingType
	{
		Default = 0,
		Alert,
		Attack,
		Defend
	}

	public PingData[] pings;
	public Camera cam;

	private int m_numberOfPingTypes;

	private PingData m_currentPingData;
	private GameObject m_player;

	public GameObject m_pingObject;
	public Canvas canvas;

	private void Start ()
	{
		m_player = GameObject.FindGameObjectWithTag( "Player" );

		setupRadialMenu();		
	}

	// Update is called once per frame
	void Update ()
	{
		if ( Input.GetKeyDown( KeyCode.V ) )
		{
			sendPing();
		}
	}

	void setupRadialMenu()
	{
		m_numberOfPingTypes = pings.Length;
		Debug.Log( m_numberOfPingTypes );
	}

	void sendPing ()
	{
		RaycastHit raycastHit;
		if ( Physics.Raycast( cam.transform.position, cam.transform.forward, out raycastHit, Mathf.Infinity ) )
		{
			m_currentPingData = pings[ (int) PingType.Alert ];
			displayPing( m_currentPingData, raycastHit.point );
		}
	}

	void displayPing ( PingData pingData, Vector3 position )
	{
		// Create the ping and set the parent to the canvas
		GameObject pingObject = Instantiate( m_pingObject, Vector3.zero, Quaternion.Euler( Vector3.zero ), canvas.transform );

		// Get the ping script and set the data
		Ping pingScript = pingObject.GetComponent<Ping>();
		pingScript.pingData = pingData;
		pingScript.player = m_player;
		pingScript.raycastHitPoint = position;
		pingScript.cam = cam;
	}

}
