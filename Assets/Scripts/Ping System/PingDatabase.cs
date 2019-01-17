namespace Ping_System
{
	using System;
	using System.Collections.Generic;
	using UnityEditor;
	using UnityEngine;

	/// <summary>
	/// Holds all of the ping data and has methods for retrieving them by id.
	/// </summary>
	public class PingDatabase : MonoBehaviour
	{
		/// <summary>
		/// The type of pings. NOTE: Add your own ping types here.
		/// </summary>
		public enum PingType
		{
			/// <summary>
			/// The default ping. Happens when you tap the button instead of holding it down.
			/// </summary>
			Default = 0,

			/// <summary>
			/// The defend ping.
			/// </summary>
			Defend,

			/// <summary>
			/// The attack ping.
			/// </summary>
			Attack,

			/// <summary>
			/// The alert ping.
			/// </summary>
			Alert
		}

		/// <summary>
		/// Singleton. NOTE: You can delete this and use your own way to reference the database, this is just for ease.
		/// </summary>
		public static PingDatabase Instance { get; private set; }

		/// <summary>
		/// The dictionary holding all the ping data.
		/// </summary>
		public Dictionary<PingType, PingData> PingDictionary { get; } = new Dictionary<PingType, PingData>();


		/// <summary>
		/// Sets the singleton and initialises the ping dictionary.
		/// </summary>
		private void Awake()
		{
			SetSingleton();
			InitialisePingDictionary();
		}

		/// <summary>
		/// Get the ping data associated with the type.
		/// </summary>
		/// <param name="type">The type of the ping data to retrieve.</param>
		/// <returns>The ping data.</returns>
		public PingData GetPing ( PingType type )
		{
			return PingDictionary[ type ];
		}
		
		/// <summary>
		/// Sets the singleton.
		/// </summary>
		private void SetSingleton()
		{
			if ( Instance == null )
				Instance = this;
			else
				Destroy( gameObject );
		}

		/// <summary>
		/// Finds all the ping data assets in "Resources/Pings" and adds them to the dictionary with their type.
		/// </summary>
		private void InitialisePingDictionary()
		{
			PingData[] pings = Resources.LoadAll<PingData>( "Pings" );

			foreach ( PingData data in pings )
			{
				PingDictionary.Add( data.Type, data );
			}
		}
	}
}
