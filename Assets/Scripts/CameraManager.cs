using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public BoardMaker board;
	public Camera mainCamera;

    void Start()
    {
        float width = board.getWidth();
		float height = board.getHeight();

		if (width > (height * 2)) {
			mainCamera.orthographicSize = (height + 1);
			mainCamera.GetComponent<Transform>().position = new Vector3(width/2, height/2, -1);
		}
		else {
			mainCamera.orthographicSize = (height/2 + 1);
			mainCamera.GetComponent<Transform>().position = new Vector3(width/2, height/2, -1);
		}

    }
}
