using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameControl : MonoBehaviour
{

    private static GameObject whoWinsTextShadow, whoWinsPanel;

    private static GameObject player1, player2, player3, player4, dice;

    public static int diceSideThrown = 0;
    // public static int player1StartWaypoint = 0;
    // public static int player2StartWaypoint = 0;
    // public static int player3StartWaypoint = 0;
    // public static int player4StartWaypoint = 0;
    public static int whosTurn;

    public static bool gameOver = false;

    public static int numOfPlayers = 0;
    public Text whosMoveText;

    public int[] ladderStarts = new int[8] {1, 4, 9, 21, 28, 51, 72, 80};
    public int[] ladderEnds = new int[8] {38, 14, 31, 42, 84, 67, 91, 99};
    // List<int> ladderStarts = new List<int>() {1, 4, 9, 21, 28, 51, 72, 80};
    public int[] snakeHeads = new int[8] {17, 54, 62, 64, 87, 93, 95, 98};
    public int[] snakeTails = new int[8] {7, 34, 19, 60, 36, 73, 75, 79};


    // Start is called before the first frame update
     void Start () {

        // Debug.Log("Start");        
        whosTurn = 0; 
        gameOver = false;

        whoWinsPanel = GameObject.Find("Canvas/WhoWinsPanel");
        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        whosMoveText = GameObject.Find("Canvas/WhosMoveText").GetComponent<Text>();
    
 
        player1 = GameObject.Find("Player1");

        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        dice = GameObject.Find("Dice");


        player1.GetComponent<FollowThePath>().startWaypoint = 0;
        player2.GetComponent<FollowThePath>().startWaypoint = 0;
        player3.GetComponent<FollowThePath>().startWaypoint = 0;
        player4.GetComponent<FollowThePath>().startWaypoint = 0;
    

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;        
        player3.GetComponent<FollowThePath>().moveAllowed = false;
        player4.GetComponent<FollowThePath>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        whoWinsPanel.gameObject.SetActive(false);

        numOfPlayers = GameSetup.numberOfPlayers;



        //disable unused players
        switch (numOfPlayers) { 
            case 1:
                player2.gameObject.SetActive(false);
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                break;

            case 2:
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                break;

            case 3:
                player4.gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // is there enough fields to move piece forward?
      

        //player1
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1.GetComponent<FollowThePath>().startWaypoint + diceSideThrown)
        {
            if(diceSideThrown != 6){
                whosTurn = (whosTurn+1)%numOfPlayers;
                dice.GetComponent<Dice>().whosTurn = whosTurn;              
            }
            CheckField(player1.GetComponent<FollowThePath>().waypointIndex - 1, 1);

            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1.GetComponent<FollowThePath>().startWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        //player 2
        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2.GetComponent<FollowThePath>().startWaypoint + diceSideThrown)
        {
            if(diceSideThrown != 6){
                whosTurn = (whosTurn+1)%numOfPlayers;
                dice.GetComponent<Dice>().whosTurn = whosTurn;
            }
            CheckField(player2.GetComponent<FollowThePath>().waypointIndex - 1, 2); 

            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2.GetComponent<FollowThePath>().startWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // igrac 3
        if (player3.GetComponent<FollowThePath>().waypointIndex >
            player3.GetComponent<FollowThePath>().startWaypoint + diceSideThrown)
        {
            if(diceSideThrown != 6){
                whosTurn = (whosTurn+1)%numOfPlayers;
                dice.GetComponent<Dice>().whosTurn = whosTurn;
            }
            CheckField(player3.GetComponent<FollowThePath>().waypointIndex - 1, 3);

            player3.GetComponent<FollowThePath>().moveAllowed = false;
            player3.GetComponent<FollowThePath>().startWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // igrac 4
        if (player4.GetComponent<FollowThePath>().waypointIndex >
            player4.GetComponent<FollowThePath>().startWaypoint + diceSideThrown)
        {
            if(diceSideThrown != 6){
                whosTurn = (whosTurn+1)%numOfPlayers;
                dice.GetComponent<Dice>().whosTurn = whosTurn;
            }
            CheckField(player4.GetComponent<FollowThePath>().waypointIndex - 1, 4);
            
            player4.GetComponent<FollowThePath>().moveAllowed = false;
            player4.GetComponent<FollowThePath>().startWaypoint = player4.GetComponent<FollowThePath>().waypointIndex - 1;
        }



        //game ends
            //player1 wins
        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Pobjednik je:\n igrač 1!";
            whoWinsPanel.gameObject.SetActive(true);
            SoundManagerScript.PlaySound("win");
            gameOver = true;
        }

            //player2 wins
        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Pobjednik je: igrač 2!";
            whoWinsPanel.gameObject.SetActive(true);
            SoundManagerScript.PlaySound("win");
            gameOver = true;
        }

        if (player3.GetComponent<FollowThePath>().waypointIndex == 
            player3.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Pobjednik je: igrač 3!";
            whoWinsPanel.gameObject.SetActive(true);
            SoundManagerScript.PlaySound("win");
            gameOver = true;
        }

        if (player4.GetComponent<FollowThePath>().waypointIndex == 
            player4.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Pobjednik je: igrač 4!";
            whoWinsPanel.gameObject.SetActive(true);
            SoundManagerScript.PlaySound("win");
            gameOver = true;
        }


        //whos turn text
        if (dice.GetComponent<Dice>().whosTurn == 0){ //change text whos turn is next
            whosMoveText.text = "Na redu je:\nigrač 1";

        } else if (dice.GetComponent<Dice>().whosTurn == 1){
            whosMoveText.text = "Na redu je:\nigrač 2";

        } else if (dice.GetComponent<Dice>().whosTurn == 2){
            whosMoveText.text = "Na redu je:\nigrač 3";

        } else if (dice.GetComponent<Dice>().whosTurn == 3){
            whosMoveText.text = "Na redu je:\nigrač 4";
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        // Debug.Log("Sada smo u 2.update");

        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            
            case 3:
                player3.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 4:
                player4.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }

    // only player whos turn is can click on his piece
    // private void EnableClick(int whosTurn){
    //     switch (whosTurn){
    //         case 0:
    //             player1.GetComponent<BoxCollider2D>().enabled = true;

    //             player2.GetComponent<BoxCollider2D>().enabled = false;

    //             break;
    //         case 1:
    //             player2.GetComponent<BoxCollider2D>().enabled = true;

    //             player1.GetComponent<BoxCollider2D>().enabled = false;
    //             break;
    //     }
    // }

    //check if field is snake head or start of ladder, if yes move piece to expected field
    private void CheckField(int field, int player){
        
        bool activeField = false;
        int goToField = 0;

        if (ladderStarts.Contains(field)){            
            SoundManagerScript.PlaySound("ladder");
            
            activeField = true;
                    
            int index = -1;
            for (int i = 0; i < ladderStarts.Length; i++)
            {
                if(ladderStarts[i] == field){
                    index = i;
                    break;
                }  
            }
            goToField = ladderEnds[index];
             
        } else if (snakeHeads.Contains(field)){
            SoundManagerScript.PlaySound("snake");
            
            activeField = true;
            
            int index = -1;
            for (int i = 0; i < snakeHeads.Length; i++)
            {
                if(snakeHeads[i] == field){
                    index = i;
                    break;
                }  
            }
            goToField = snakeTails[index];

        }

        if (activeField){
            switch (player) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveToField = goToField;
                player1.GetComponent<FollowThePath>().myMoveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveToField = goToField;
                player2.GetComponent<FollowThePath>().myMoveAllowed = true;
                break;

            case 3:
                player3.GetComponent<FollowThePath>().moveToField = goToField;
                player3.GetComponent<FollowThePath>().myMoveAllowed = true;
                break;

            case 4:
                player4.GetComponent<FollowThePath>().moveToField = goToField;
                player4.GetComponent<FollowThePath>().myMoveAllowed = true;
                break;

            }
        }
    }
}

