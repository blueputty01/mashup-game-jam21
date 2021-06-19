﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PortalStart : MonoBehaviour
{
	//config
	[SerializeField]
	[Tag]
	private string playerTag;
	
	[SerializeField]
	private GameObject portalClose;
	
	//runtime
	private GameObject playerCopy;

	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(playerTag))
		{
			//spawn copy on the other side
			playerCopy = Instantiate(other.gameObject, portalClose.transform.position, Quaternion.identity);
		}
	}
	
	// Sent when another object leaves a trigger collider attached to this object (2D physics only).
	protected void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag(playerTag))
		{
			//delete this player
			var name = other.name;
			Destroy(other.gameObject);
			
			//change name of copy
			playerCopy.name = name;
		}
	}
}