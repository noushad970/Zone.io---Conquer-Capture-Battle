using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterArea : MonoBehaviour
{
	public Character character;
	public MeshCollider coll;
	//awake to start
	private void Awake()
	{
		coll = gameObject.AddComponent<MeshCollider>();
	}
}