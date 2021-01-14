using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatGoal : MonoBehaviour
{
	[SerializeField] Transform target;

	// カーソル
	[SerializeField] Transform cursor;

	// Update is called once per frame
	void Update()
	{
		cursor.LookAt(target);
	}
}
