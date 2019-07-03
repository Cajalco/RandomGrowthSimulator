using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
	public float totalGrowthRangeEnd = 0f;
	public float growthModifier = 0.05f;
	private float randomGrowthIndex = 0f;
	private int tileCount;
	private BoardMaker boardMaker;

	void Start() {
		boardMaker = GetComponent<BoardMaker>();
		tileCount = boardMaker.tiles.Count;
		totalGrowthRangeEnd = boardMaker.tiles[tileCount].GetComponent<Tile>().getGrowthRangeEnd();
	}
	
    void FixedUpdate() {
		randomGrowthIndex =	Random.Range(0.0f, totalGrowthRangeEnd);

		// Find GameObject with nearest key (growthRangeEnd) greater than or equal to randomGrowthIndex.
		// If (index >= 0), index corresponds to the correct (existing) GameObject. Else, the (~index + 1) corresponds to the correct GameObject.
		List<float> growthRangeEnds = new List<float>(boardMaker.tiles.Keys);
		int index = growthRangeEnds.BinarySearch(randomGrowthIndex);
		if (index < 0f) {
			index = (~index + 1);
		}
		Debug.Log("Index: " + index);
		Debug.Log("Size of tiles: " + boardMaker.tiles.Count);

		// Change corresponding GameObject's sprite renderer's color.
		Color tileColor = (boardMaker.tiles[index] as GameObject).GetComponent<SpriteRenderer>().color;
		tileColor = new Vector4((tileColor.r + 0.05f), (tileColor.g + 0.05f), (tileColor.b + 0.05f), 1);
		boardMaker.tiles[index].GetComponent<SpriteRenderer>().color = tileColor;

		// Change the growthRangeEnd of chosen tile and shift the growthRangeEnd of all tiles with a greater index accordingly.
		changeGrowthRange(index, growthModifier);
    }

	private void changeGrowthRange(int index, float growthModifier) {
		// Copy all key-value pairs to a temporary location. // Is there an easier way to only copy the index element and greater?
		KeyValuePair<float, GameObject>[] copyArray = new KeyValuePair<float, GameObject>[tileCount*2];
		boardMaker.tiles.CopyTo(copyArray, 0);

		// Remove the copied key-value pairs from dictionary.
		boardMaker.tiles.Clear();

		// Shift the succeeding tiles growthRangeStarts of the copies accordingly and add the elements back to the dictionary.
		for (int i = 0; i < index; ++i) {
			boardMaker.tiles.Add(copyArray[i].Key, copyArray[i].Value);
		}
		for (int i = index; i < tileCount; ++i) {
			boardMaker.tiles.Add((copyArray[i].Key + growthModifier), copyArray[i].Value);
		}

		// Shift the growthRangeEnd of the dictionary.
		totalGrowthRangeEnd = boardMaker.tiles[tileCount].GetComponent<Tile>().getGrowthRangeEnd();
	}
}
