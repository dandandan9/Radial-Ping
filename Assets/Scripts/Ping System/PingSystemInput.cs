using UnityEngine;

public class PingSystemInput : MonoBehaviour
{
	/// <summary>
	/// The key to press to bring up the menu.
	/// </summary>
	[SerializeField]
	[Tooltip( "Key to press to bring up the menu" )]
	private KeyCode inputKey;

	/// <summary>
	/// How long to hold the button for the menu to appear.
	/// </summary>
	[SerializeField]
	[Tooltip( "How long the user has to hold the button to bring up the menu. Leave 0 for instant" )]
	private float holdTime = 0f;

	/// <summary>
	/// How long the user has currently been pressing the button.
	/// </summary>
	private float currentHoldTime = 0f;

	/// <summary>
	/// Whether the menu should be shown, based on the current hold time and the max hold time.
	/// </summary>
	/// <returns>Whether the menu should be shown.</returns>
	public bool ShouldShowMenu ()
	{
		return currentHoldTime >= holdTime;
	}

	/// <summary>
	/// Handles the input.
	/// </summary>
	private void HandleInput ()
	{
		if ( Input.GetKey( inputKey ) )
		{
			currentHoldTime += Time.deltaTime;
		}
		else
		{
			currentHoldTime = 0;
		}
	}

	private void Update ()
	{
		HandleInput();
	}
}
