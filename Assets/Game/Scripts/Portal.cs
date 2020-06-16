using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

	public GameObject PassageTo;
	public GameObject Player;


	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			StartCoroutine(Teleport());
		}
	}


	IEnumerator Teleport()
	{
		yield return new WaitForSeconds(0.5f);
		Player.transform.position = new Vector2(PassageTo.transform.position.x, PassageTo.transform.position.y);
	}
}