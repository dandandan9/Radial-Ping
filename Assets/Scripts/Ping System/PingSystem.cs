namespace Ping_System
{
	using System.Collections;
	using UnityEngine;

	public class PingSystem : MonoBehaviour
	{
		/// <summary>
		/// The ping prefab to use.
		/// </summary>
		[SerializeField]
		private GameObject pingPrefab;

		/// <summary>
		/// The radial menu script.
		/// </summary>
		[SerializeField]
		private RadialMenu radialMenu;

		/// <summary>
		/// The key to press to ping.
		/// </summary>
		[ SerializeField ]
		[ Tooltip( "Key to press to bring up the menu" ) ]
		private KeyCode pingKey = KeyCode.X;

		/// <summary>
		/// How long to hold the button for the menu to appear.
		/// </summary>
		[SerializeField]
		[Tooltip( "How long the user has to hold the button to bring up the menu. Leave 0 for instant" )]
		private float menuHoldTime = 0;

		/// <summary>
		/// How long the user has currently been pressing the button.
		/// </summary>
		private float currentHoldTime = 0f;

		//public Camera cam;

		//private int m_numberOfPingTypes;

		//private PingData m_currentPingData;

		//private GameObject player;

		//public GameObject m_pingObject;

		//public Canvas canvas;


		private void Awake ()
		{
			

			
		}

		private void Update()
		{
			HandleInput();
		}

		/// <summary>
		/// Handles the input, checking whether a normal ping should execute or the radial menu.
		/// </summary>
		private void HandleInput ()
		{
			// Exit out if the radial menu is showing
			if ( radialMenu.IsShowing ) return;

			// Increment the hold timer if key is held down
			if ( Input.GetKey( pingKey ) )
			{
				currentHoldTime += Time.deltaTime;
			}
			else
			{
				// If hold time was incremented, handle the pinging
				if ( currentHoldTime > 0 )
				{
					if (ShouldDefaultPing() )
					{
						Ping ping = Instantiate( pingPrefab, this.transform ).GetComponent<Ping>();

					}
					else if ( ShouldShowMenu() )
					{
						radialMenu.AnimateIn();
					}
				}

				currentHoldTime = 0;
			}

		}

		/// <summary>
		/// Whether a default ping should be executed (on tap).
		/// </summary>
		/// <returns>True if a default ping will happen.</returns>
		private bool ShouldDefaultPing ()
		{
			return ( currentHoldTime <= menuHoldTime ) && ( currentHoldTime <= 0.2f );
		}

		/// <summary>
		/// Whether the menu should be shown, based on the current hold time and the max hold time.
		/// </summary>
		/// <returns>True if the menu should be shown.</returns>
		private bool ShouldShowMenu ()
		{
			return currentHoldTime >= menuHoldTime;
		}

		public PingDatabase.PingType GetCurrentPingSelection()
		{
			return PingDatabase.PingType.Default;
		}

		private void HandlePingSelection( PingDatabase.PingType pingType )
		{

		}

		

		

		//private void Start ()
		//{
		//	player = GameObject.FindGameObjectWithTag( "Player" );

		//	setupRadialMenu();
		//}

		//// Update is called once per frame
		//private void Update ()
		//{
		//	if ( Input.GetKeyDown( KeyCode.V ) )
		//	{
		//		sendPing();
		//	}
		//}

		//private void setupRadialMenu ()
		//{
		//	m_numberOfPingTypes = pings.Length;
		//	Debug.Log( m_numberOfPingTypes );
		//}

		//private void sendPing ()
		//{
		//	RaycastHit raycastHit;
		//	if ( Physics.Raycast( cam.transform.position, cam.transform.forward, out raycastHit, Mathf.Infinity ) )
		//	{
		//		m_currentPingData = pings[ (int) PingDatabase.PingType.Alert ];
		//		displayPing( m_currentPingData, raycastHit.point );
		//	}
		//}

		//private void displayPing ( PingData pingData, Vector3 position )
		//{
		//	// Create the ping and set the parent to the canvas
		//	GameObject pingObject = Instantiate(
		//		m_pingObject,
		//		Vector3.zero,
		//		Quaternion.Euler( Vector3.zero ),
		//		canvas.transform );

		//	// Get the ping script and set the data
		//	//Ping pingScript = pingObject.GetComponent<Ping>();
		//	//pingScript.pingData = pingData;
		//	//pingScript.player = m_player;
		//	//pingScript.raycastHitPoint = position;
		//	//pingScript.cam = cam;
		//}

	}
}