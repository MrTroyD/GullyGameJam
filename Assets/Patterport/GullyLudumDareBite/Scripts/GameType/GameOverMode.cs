using Patterport.Gully.GameType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverMode : GameMode
{
   public override void GameUpdate(float deltaTime)
   {
        this._gameManager.OnGameOverCalled();
   }
}
