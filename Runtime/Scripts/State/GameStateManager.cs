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
            None,
            State1,
            State2,
            State3,
            State4,
            State5,
            State6,
            State7,
            State8,
            State9,
            State10
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

        public override void Initialize()
        {
            _stateDic = new();
            name = "GameStateManager";
            base.Initialize();
        }
    }
}
