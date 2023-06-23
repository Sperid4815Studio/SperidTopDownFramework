using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEditor;
using UnityEngine;

namespace SperidTopDownFramework.Runtime
{
    public class GameStateManager : SingletonBehaviour<GameStateManager>
    {
        [Flags]
        public enum GameState
        {
            None = 0x01<<1,
            Title = 0x01<<2,
            Tutorial = 0x01<<3,
            Game = 0x01<<4,
            Pause = 0x01<<5,
            Result = 0x01<<6,
            Option = 0x01<<7,
            Restart = 0x01<<8,
            State8 = 0x01<<9,
            State9 = 0x01<<10,
            State10 = 0x01<<11
        }

      
        public GameState CurrentState { get; private set; } = GameState.None;

        public event System.Action<GameState> OnStateChanged;

        public void ChangeState(GameState state)
        {
            CurrentState = state;
            OnStateChanged?.Invoke(state);
        }

        public override void Initialize()
        {
            name = "GameStateManager";
            base.Initialize();
        }
    }
}
