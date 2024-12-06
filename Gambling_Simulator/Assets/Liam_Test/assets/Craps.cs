using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    
    public class Craps : MonoBehaviour 
    {
        private bool pass;
        public ROLL rollScript;
        public GameStatus gameStatus;
        private GamePhase phase;
        
        public bool roundOver=false;
        public bool win=false;
    
        public enum GameStatus { WIN, LOSE, PLAY_MORE }
        private enum GamePhase{COME_OUT, POINT_PHASE}


        public int point=0;

    
        


        public void PlayGame(bool bet){

            pass=bet;
            EvaluateRoll();

        }

        public void EvaluateRoll()
        {

            int sum;
            
            while(roundOver==false){
                rollScript.diceroll();
                sum=rollScript.GetDiceSum();
                if(point==0){
                    if(sum == 11||sum ==7){
                        point=0;
                        if(pass){
                            win=true;
                        }else{
                            win=false;
                        }
                        roundOver=true;
                    }else if(sum == 2||sum ==3||sum ==12){
                        point=0;
                        if(pass){
                            win=false;
                        }else{
                            win=true;
                        }  
                        roundOver=true;

                    }else{
                        point=sum;
                        
                    }
                }else{
                    if(sum==point){
                        if(pass){
                            win=true;
                        }else{
                            win=false;
                        }

                        roundOver=true;
                    }else if(sum==7){
                        if(pass){
                            win=false;
                        }else{
                            win=true;
                        }
                        roundOver=true;
                    }


                }

            }
            if(win){
                Debug.Log("win");
            }else{
                Debug.Log("Lose");
            }

        }

    }  


