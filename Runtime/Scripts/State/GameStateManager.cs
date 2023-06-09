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
        [System.Flags]
        public enum GameState
        {
            None = 0x01<<1,
            State1 = 0x01<<2,
            State2 = 0x01<<3,
            State3 = 0x01<<4,
            State4 = 0x01<<5,
            State5 = 0x01<<6,
            State6 = 0x01<<7,
            State7 = 0x01<<8,
            State8 = 0x01<<9,
            State9 = 0x01<<10,
            State10 = 0x01<<11
        }

        private Dictionary<string, GameState> _stateDic;

        public GameState CurrentState { get; private set; } = GameState.None;

        public event System.Action<GameState> OnStateChanged;

        public void ChangeState(GameState state)
        {
            CurrentState = state;
            OnStateChanged?.Invoke(state);
        }

        public void ChangeState(string stateName)
        {
            if (!_stateDic.ContainsKey(stateName))
            {
                Debug.LogError($"{stateName} not found in GameState.");
                return;
            }

            ChangeState(_stateDic[stateName]);
        }

        public void BindName(string name,GameState state)
        {
            if (_stateDic.ContainsKey(name))
            {
                Debug.LogError($"{name} is already bind to {_stateDic[name]}");
                return;
            }

            _stateDic[name] = state;
        }

        public void UnbindName(string name)
        {
            if (!_stateDic.ContainsKey(name))
            {
                Debug.LogError($"{name} is not exists.");
                return;
            }

            _stateDic.Remove(name);
        }

        public GameState GetBindState(string name)
        {
            if (_stateDic.ContainsKey(name))
            {
                return _stateDic[name];
            }

            return GameState.None;
        }

        public override void Initialize()
        {
            _stateDic = new();
            name = "GameStateManager";
            base.Initialize();
        }
    }
}
