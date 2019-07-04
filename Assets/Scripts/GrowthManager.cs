using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
	public bool continueGrowing = true;
	public bool colorOn = false;
	public int growthCounter = 0;
	public float totalGrowthRangeEnd = 0.0f;
	public List<float> growthRangeEnds;

	private float randomGrowthIndex = 0.0f;
	private float correspondingKey = 0.0f;
	private float growthModifier = 0.05f;
	private float colorChangeAmount = .01f;
	private int tileCount;
	private int growthSpeed = 1; // 60/growthSpeed equals tile growth per second, minimum 1.
	private int frameCounter = 0;
	private BoardMaker board;

	void Start() {
		board = GetComponent<BoardMaker>();
	}
	
    void FixedUpdate() {
		tileCount = board.tiles.Count;
		if (continueGrowing && frameCounter == growthSpeed) {
			++growthCounter;
			frameCounter = 0;
			growthRangeEnds = new List<float>(board.tiles.Keys);
			totalGrowthRangeEnd = growthRangeEnds[(tileCount - 1)];
			randomGrowthIndex =	Random.Range(0.0f, totalGrowthRangeEnd);

			// Find GameObject with nearest key (growthRangeEnd) greater than or equal to randomGrowthIndex.
			// If (index >= 0), index corresponds to the correct (existing) GameObject. Else, the (~index + 1) corresponds to the correct GameObject.
			int index = growthRangeEnds.BinarySearch(randomGrowthIndex);
			if (index < 0) {
				index = (~index);
			}
			correspondingKey = growthRangeEnds[index];

			// Change corresponding GameObject's sprite renderer's color.
			Color tileColor = board.tiles[correspondingKey].GetComponent<SpriteRenderer>().color;
			if (colorOn) {
				float H, S, V;
				Color.RGBToHSV(new Color(tileColor.r, tileColor.g, tileColor.b, 1), out H, out S, out V);
				board.tiles[correspondingKey].GetComponent<SpriteRenderer>().color = Color.HSVToRGB((H + colorChangeAmount), 1, 1);
			}
			else {
				tileColor = new Vector4((tileColor.r + colorChangeAmount), (tileColor.g + colorChangeAmount), (tileColor.b + colorChangeAmount), 1);
				board.tiles[correspondingKey].GetComponent<SpriteRenderer>().color = tileColor;
				if (board.tiles[correspondingKey].GetComponent<SpriteRenderer>().color.r >= 1) {
					Debug.Log("Tile " + index + " removed.");
					removeGrownTileFromDictionary(index, correspondingKey);
				}
			}
	
			// Change the growthRangeEnd of chosen tile and shift the growthRangeEnd of all tiles with a greater index accordingly.
			changeGrowthRange(index, growthModifier);
		}
		++frameCounter;
    }

	private void changeGrowthRange(int index, float growthChange) {
		// Copy all key-value pairs to a temporary location.
		KeyValuePair<float, GameObject>[] copyArray = new KeyValuePair<float, GameObject>[tileCount*2];
		board.tiles.CopyTo(copyArray, 0);

		// Remove the copied key-value pairs from dictionary.
		board.tiles.Clear();

		// Shift the succeeding tiles growthRangeStarts of the copies accordingly and add the elements back to the dictionary.
		for (int i = 0; i < index; ++i) {
			board.tiles.Add(copyArray[i].Key, copyArray[i].Value);
		}
		for (int i = index; i < tileCount; ++i) {
			board.tiles.Add((copyArray[i].Key + growthChange), copyArray[i].Value);
		}
	}

	private void removeGrownTileFromDictionary(int index, float correspondingKey) {
		board.tiles.Remove(correspondingKey);
		changeGrowthRange(index, (growthModifier * (1/colorChangeAmount)));
	}
}
