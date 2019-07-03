using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{
	// Change the board size to not be hardcoded when you get a menu or other selection tool.
	private int width = 10;
	private int height = 10;
	private int IDCounter = 0;
	public SortedDictionary<float, GameObject> tiles = new SortedDictionary<float, GameObject>();

	public GameObject tilePrefab;
	public GameObject parent;

	void Awake() {
		GameObject tile;
		for (int i = 0; i < height; ++i) {
			for (int j = 0; j < width; ++j) {
				tile = Instantiate(tilePrefab, new Vector3(j, i, 0f), Quaternion.identity, parent.transform);
				tile.GetComponent<Tile>().setTileID(IDCounter);
				tile.GetComponent<Tile>().setGrowthRangeEnd((IDCounter + 1));
				tiles.Add(tile.GetComponent<Tile>().getGrowthRangeEnd(), tile);
				++IDCounter;
			}
		}
		parent.transform.position = new Vector3(0.5f, 0.5f, 0);
	}
}