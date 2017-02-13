﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory {

  #region Fields

  private static Vector3 StraightIncrement = new Vector3(Config.TileSize, 0, 0);
  private static Vector3 LeftIncrement = new Vector3(0, 0, Config.TileSize);
  private static Vector3 RightIncrement = new Vector3(0, 0, -Config.TileSize);

  private static Vector3 FirstTileLeftIncrement = new Vector3(24f, 0, 37.8f);
  private static Vector3 FirstTileRightIncrement = new Vector3(24f, 0, -37f);

  #endregion

	#region Public Behaviour

  public static Tile TileByTileGroupType(Tile previousTile, TileType tileType, TileGroupType tileGroupType) {

    if(tileType == TileType.FirstLeft)
      return new Tile(TileType.FirstLeft, tileGroupType, previousTile.Position + FirstTileLeftIncrement, new Vector3(0, -90, 0));
    if(tileType == TileType.FirstRight)
      return new Tile(TileType.FirstRight, tileGroupType, previousTile.Position + FirstTileRightIncrement, new Vector3(0, 90, 0));

    switch(tileGroupType) {
      case TileGroupType.Left:
        return new Tile(tileType, tileGroupType, previousTile.Position + LeftIncrement, new Vector3(0, -90, 0));
      case TileGroupType.Right: 
        return new Tile(tileType, tileGroupType, previousTile.Position + RightIncrement, new Vector3(0, 90, 0));
      case TileGroupType.Down: 
        return new Tile(tileType, tileGroupType, previousTile.Position - StraightIncrement, Vector3.zero);
      default:
        return new Tile(tileType, tileGroupType, previousTile.Position + StraightIncrement, Vector3.zero);
    }

  }

  #endregion

}