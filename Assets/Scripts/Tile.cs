using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int tileID;
	public float growthRangeEnd;
	
	public Tile(int tileID = 0) {
		this.tileID = tileID;
	}

	public int getTileID() {
		return tileID;
	}

	public float getGrowthRangeEnd() {
		return growthRangeEnd;
	}

	public void setTileID(int tileID) {
		this.tileID = tileID;
	}

	public void setGrowthRangeEnd(float growthRangeEnd) {
		this.growthRangeEnd = growthRangeEnd;
	}
}