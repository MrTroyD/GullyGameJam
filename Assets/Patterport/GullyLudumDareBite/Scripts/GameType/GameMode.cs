using System;
using UnityEngine;

namespace Patterport.Gully.GameType
{
    public class GameMode :ScriptableObject
    {
        protected GullyGameManager _gameManager; //This is probably the most complicated way to do this but... here we are
        [SerializeField] Sprite _modeIcon;
        [SerializeField] int _intensity = 0;

        public int intensity
        {
            get { return this._intensity; }
        }

        public void SetGameManager(GullyGameManager gameManager)
        {
            this._gameManager = gameManager;
        }

        public virtual void GameUpdate(float deltaTime)
        {

        }
    }
}
