using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{
	public GameObject tilePrefab;
	public GameObject parent;
	public SortedDictionary<float, GameObject> tiles = new SortedDictionary<float, GameObject>();

	private int width;	    // 18, 34, 50, 66, 82, 98, 114, 130, 146, 162, 178, 194, 210 // Good widths are multiples of 16 + an offset
	private int height;	    //  9, 18, 27, 36, 45, 54,  63,  72,  81,  90,  99, 108, 117 // Good heights are multiples of 9
	private float initialRangeEnd = 1.0f;

    void Awake() {
		GameObject tile;
        width = ConfigurationManager.Instance.getBoardWidth();
        height = ConfigurationManager.Instance.getBoardHeight();
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