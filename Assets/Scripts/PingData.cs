using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu( fileName = "PingData", menuName = "Ping Data", order = 1 )]
public class PingData : ScriptableObject {

	public Sprite texture;
	public Color colour;
}
