using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{

	public GameObject tilePrefab;
	public GameObject parent;
	public SortedDictionary<float, GameObject> tiles = new SortedDictionary<float, GameObject>();

	// Change the board size to not be hardcoded when you get a menu or other selection tool.
	private int width = 30;
	private int height = 30;
	private float initialRangeEnd = 1.0f;

	void Awake() {
		GameObject tile;
		for (int i = 0; i < height; ++i) {
			for (int j = 0; j < width; ++j) {
				tile = Instantiate(tilePrefab, new Vector3(j, i, 0f), Quaternion.identity, parent.transform);
				tiles.Add(initialRangeEnd, tile);
				++initialRangeEnd;
			}
		}
		parent.transform.position = new Vector3(0.5f, 0.5f, 0);
	}

	public int getWidth() {
		return width;
	}

	public int getHeight() {
		return height;
	}

	public void setWidth(int width) {
		this.width = width;
	}

	public void setHeight(int height) {
		this.height = height;
	}
}