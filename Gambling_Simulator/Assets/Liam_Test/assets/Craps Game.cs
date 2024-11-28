using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrapsGame
{
    public class Craps
    {
        private ROLL rollScript;
        private GameStatus gameStatus;

        private enum DiceSums { SNAKE_EYES = 2, TREY = 3, SEVEN = 7, YO_LEVEN = 11, BOX_CARS = 12 }
        private enum GameStatus { WIN, LOSE, PLAY_MORE }

        public int Sum { get; private set; }
        public int Point { get; private set; }

        public Craps(ROLL rollScript)
        {
            this.rollScript = rollScript;
            gameStatus = GameStatus.PLAY_MORE;
        }

        public void PlayGame()
        {
            while (gameStatus == GameStatus.PLAY_MORE)
            {
                rollScript.diceroll();
                Sum = rollScript.GetDiceSum();
                EvaluateRoll();
            }
        }

        private void EvaluateRoll()
        {
            switch ((DiceSums)Sum)
            {
                case DiceSums.SEVEN:
                case DiceSums.YO_LEVEN:
                    gameStatus = GameStatus.WIN;
                    Point = 0;
                    break;
                case DiceSums.SNAKE_EYES:
                case DiceSums.TREY:
                case DiceSums.BOX_CARS:
                    gameStatus = GameStatus.LOSE;
                    Point = 0;
                    break;
                default:
                    gameStatus = GameStatus.PLAY_MORE;
                    Point = Sum;
                    break;
            }
        }
    }
}