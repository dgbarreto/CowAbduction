using Assets.Scripts.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
  internal sealed class GameState
  {
    private static GameState _instance;
    private int _lives = 3;
    private GameLevel _actualLevel;
    private List<GameLevel> _availableLevels;

    public static GameState Shared()
    {
      if (_instance == null)
      {
        _instance = new GameState();
      }

      return _instance;
    }

    public enum eGameState
    {
      Opening = 1,
      Gaming = 2
    }

    public eGameState State { get; set; }
    public int BaseLives
    {
      get { return _lives; }
      set { _lives = value; }
    }

    public GameLevel ActualLevel
    {
      get { return _actualLevel; }
      set { _actualLevel = value; }
    }

    public List<GameLevel> AvailableLevels
    {
      get { return _availableLevels; }
      set { _availableLevels = value; }
    }
  }
}
