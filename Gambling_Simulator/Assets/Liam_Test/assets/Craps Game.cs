using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrapsGame
{
    
    public class Craps
    {
        public ROLL rollScript;
        private GameStatus gameStatus;
        private GamePhase phase;
        

        private enum DiceSums { SNAKE_EYES = 2, TREY = 3, SEVEN = 7, YO_LEVEN = 11, BOX_CARS = 12 }
        private enum GameStatus { WIN, LOSE, PLAY_MORE }
        private enum GamePhase{COME_OUT, POINT_PHASE}

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
            if (phase == GamePhase.COME_OUT)
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
        else if (phase == GamePhase.POINT_PHASE)
        {
            if (Sum == Point)
            {
                gameStatus = GameStatus.WIN;

            }
            else if (Sum ==(int)DiceSums.SEVEN)
            {
                gameStatus = GameStatus.LOSE;
            }
            else {
                Debug.Log($"Rolling again, Current roll: {Sum}");
            }
        }
    }  

    private void ResetGame()
    {
        gameStatus = GameStatus.PLAY_MORE;
        phase = GamePhase.COME_OUT;
        Point = 0;
    
    }

    private void DisplayGameResult()
    {
        if (gameStatus == GameStatus.WIN)
        {
            Debug.Log("You won!");

        }
        else if (gameStatus == GameStatus.LOSE)
        {
            Debug.Log("You lost!");
        }
        ResetGame();
    }

    }  
}