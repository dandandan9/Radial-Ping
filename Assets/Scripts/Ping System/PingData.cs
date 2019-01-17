namespace Ping_System
{
	using UnityEngine;
	
	/// <summary>
	/// Holds data about a certain type of ping.
	/// </summary>
	[CreateAssetMenu( fileName = "PingData", menuName = "Ping Data", order = 1 )]
	public class PingData : ScriptableObject
	{
		/// <summary>
		/// The name of the ping.
		/// </summary>
		public string Name;

		/// <summary>
		/// The type of ping.
		/// </summary>
		public PingDatabase.PingType Type;

		/// <summary>
		/// Texture of the ping that is shown.
		/// </summary>
		public Sprite Texture;

		/// <summary>
		/// The color of the ping (leave white for default texture)
		/// </summary>
		public Color Color = Color.white;

		/// <summary>
		/// The sound that is played when the ping is triggered.
		/// </summary>
		public AudioClip Sound;

		/// <summary>
		/// How long the ping stays on screen.
		/// </summary>
		public float Lifetime = 4f;
	}
}