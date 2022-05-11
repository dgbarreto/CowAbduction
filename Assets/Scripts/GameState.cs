using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts {
    internal sealed class GameState {
        private static GameState _instance;

        public static GameState Shared() {
            if(_instance == null) {
                _instance = new GameState();
            }

            return _instance;
        }

        public enum eGameState {
            Opening = 1,
            Gaming = 2
        }

        public eGameState State { get; set; }
    }
}
