namespace Ping_System
{
	using UnityEngine;
	using UnityEngine.UI;

	/// <summary>
	/// The representation of a ping.
	/// </summary>
	public class Ping : MonoBehaviour
	{
		/// <summary>
		/// The current ping data to use.
		/// </summary>
		[SerializeField]
		private PingData pingData;

		/// <summary>
		/// The player's camera.
		/// </summary>
		private Camera playerCamera;

		/// <summary>
		/// The point where the raycast hits.
		/// </summary>
		public Vector3 RaycastHitPoint { get; set; }

		/// <summary>
		/// The minimum alpha the ping will fade to.
		/// </summary>
		private float minAlpha = 0.3f;

		/// <summary>
		/// The maximum alpha the ping will fade to.
		/// </summary>
		private float maxAlpha = 0.85f;

		/// <summary>
		/// The distance where the minimum alpha will cap.
		/// </summary>
		private float distanceToMinAlpha = 20f;

		/// <summary>
		/// The distance where the maximum alpha will cap.
		/// </summary>
		private float distanceToMaxAlpha = 55f;

		/// <summary>
		/// The image component of the ping.
		/// </summary>
		[SerializeField]
		private Image pingImage;

		/// <summary>
		/// The text component of the ping.
		/// </summary>
		[SerializeField]
		private Text pingText;

		/// <summary>
		/// The lifetime of the ping.
		/// </summary>
		private float lifeTime;

		/// <summary>
		/// Start function.
		/// </summary>
		private void Start ()
		{
			// Set the default ping data
			SetPingData( PingDatabase.Instance.GetPing( PingDatabase.PingType.Default ) );

			// Cache the camera
			playerCamera = Camera.main;
		}

		/// <summary>
		/// Sets the ping data from reference.
		/// </summary>
		/// <param name="data">The data to change to.</param>
		public void SetPingData ( PingData data )
		{
			pingData = data;
			OnDataChanged();
		}

		/// <summary>
		/// Sets the ping data from type.
		/// </summary>
		/// <param name="type">The type to change to.</param>
		public void SetPingData ( PingDatabase.PingType type )
		{
			pingData = PingDatabase.Instance.GetPing( type );
			OnDataChanged();
		}

		/// <summary>
		/// Updates all the necessary properties when the data is changed.
		/// </summary>
		private void OnDataChanged ()
		{
			pingImage.sprite = pingData.Texture;
			pingImage.color = pingData.Color;
		}

		private void Update ()
		{
			CheckForDestroy();

			transform.position = playerCamera.WorldToScreenPoint( RaycastHitPoint ) + new Vector3( 0, pingImage.sprite.bounds.extents.y, 0 );

			int distance = (int) Vector3.Distance( RaycastHitPoint, playerCamera.transform.position );
			UpdateText( distance );
			UpdateAlpha( distance );
		}

		private void CheckForDestroy()
		{
			lifeTime += Time.deltaTime;
			if ( lifeTime > pingData.Lifetime ) Destroy( gameObject );
		}
		/// <summary>
		/// Updates the distance text of the ping.
		/// </summary>
		/// <param name="distance"></param>
		private void UpdateText ( int distance )
		{
			pingText.text = distance.ToString() + "m";
		}

		/// <summary>
		/// Updates the alpha of the image.
		/// </summary>
		/// <param name="distance"></param>
		private void UpdateAlpha ( int distance )
		{
			Color col = pingImage.color;

			if ( distance <= distanceToMinAlpha )
			{
				col.a = maxAlpha;
			}
			else
			{
				float fraction = ( distance - distanceToMinAlpha ) / ( distanceToMaxAlpha - distanceToMinAlpha );
				col.a = Mathf.Lerp( maxAlpha, minAlpha, fraction );
			}

			pingImage.color = col;
		}
	}
}

