namespace Ping_System
{
	using UnityEngine;
	using System.Collections;

	public class RadialMenu : MonoBehaviour
	{
		/// <summary>
		/// The radial menu object.
		/// </summary>
		[SerializeField]
		private GameObject radialMenu;

		/// <summary>
		/// How long the animation takes.
		/// </summary>
		[SerializeField]
		private float animationDuration = 0.08f;

		/// <summary>
		/// Whether the radial menu is showing.
		/// </summary>
		public bool IsShowing { get; private set; }

		/// <summary>
		/// The amount of pings in the wheel.
		/// </summary>
		private int numberOfPings;

		private void Awake()
		{
			//radialMenuInput = GetComponent<RadialPingMenuInput>();

			// Make sure the radial menu is scaled out and disabled
			radialMenu.transform.localScale = Vector3.zero;
			radialMenu.SetActive( false );

			numberOfPings = radialMenu.transform.childCount;
		}

		private void Update()
		{
			if ( !IsShowing )
			{
				//if ( ShouldShowMenu() )
				//{
				//	AnimateIn();
				//}
			}
			else
			{
				//if ( !ShouldShowMenu() )
				//{
				//	AnimateOut();
				//}
			}
		}

		/// <summary>
		/// Animates the radial menu in.
		/// </summary>
		public void AnimateIn ()
		{
			if ( IsShowing ) return;

			radialMenu.SetActive( true );
			StopAllCoroutines();
			StartCoroutine( AnimateRadialMenu( 1f, animationDuration, false ) );
			IsShowing = true;
		}

		/// <summary>
		/// Animates the radial menu out.
		/// </summary>
		public void AnimateOut ()
		{
			if ( !IsShowing ) return;

			//HandlePingSelection( GetCurrentPingSelection() );

			StopAllCoroutines();
			StartCoroutine( AnimateRadialMenu( 0f, animationDuration, true ) );
			IsShowing = false;
		}

		/// <summary>
		/// Animates the radial menu.
		/// </summary>
		/// <param name="endScale"></param>
		/// <param name="duration"></param>
		/// <param name="disableAfterAnimation"></param>
		/// <returns></returns>
		private IEnumerator AnimateRadialMenu ( float endScale, float duration, bool disableAfterAnimation )
		{
			float startScale = radialMenu.transform.localScale.x;
			float timer = 0f;

			while ( timer < duration )
			{
				float currentScale = Mathf.Lerp( startScale, endScale, timer / duration );
				radialMenu.transform.localScale = new Vector3( currentScale, currentScale, currentScale );

				timer += Time.deltaTime;

				yield return null;
			}

			// Make sure it's scaled correctly
			radialMenu.transform.localScale = new Vector3( endScale, endScale, endScale );

			if ( disableAfterAnimation )
			{
				radialMenu.SetActive( false );
			}
		}

		/// <summary>
		/// Handles the input.
		/// </summary>
		private void HandleInput ()
		{
		}


		private void CalculatePingPositions ()
		{

		}

	}
}
