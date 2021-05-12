using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {HOME, PLAYING}

public delegate void OnStateChangeHandler();

public class GameMgr : MonoBehaviour
{
    protected GameMgr() {}
    private static GameMgr instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }

    public static GameMgr Instance
    {
        get
        { 
            if (GameMgr.instance == null)
            {
                DontDestroyOnLoad(GameMgr.instance);
                GameMgr.instance = new GameMgr();
            }
            return GameMgr.instance;
        }         
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit()
    {
        GameMgr.instance = null;
    }

}
