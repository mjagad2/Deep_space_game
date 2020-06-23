using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class puzzleDrag : MonoBehaviour
	{
		public Rigidbody puzzlePiece;
		bool selected;

		// A Test behaves as an ordinary method
		[Test]
		public void OnMouseOver()
		{
			if (selected == true)
			{
				Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.position = new Vector2(cursorPos.x, cursorPos.y);
			}
			if (Input.GetMouseButtonUp(0))
			{
				selected = false;
			}
			Assert.AreEqual(true, selected);

		}

	}
}
