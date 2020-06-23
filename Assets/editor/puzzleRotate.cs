using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class puzzleRotate : MonoBehaviour
	{
		public Rigidbody puzzlePiece;
		bool isActive;

		// A Test behaves as an ordinary method
		[Test]
		public void OnMouseOver()
		{
			isActive = false;
			if (Input.GetMouseButtonDown(1))
			{
				transform.Rotate(0f, 0f, 90f);
				isActive = true;
			}
			Assert.AreEqual(true, isActive);

		}

	}
}




