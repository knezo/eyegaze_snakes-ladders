using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public Sprite[] diceSides;
    public SpriteRenderer rend;
    public int whosTurn = 0;
    private bool coroutineAllowed = true;
    public int numberOfPlayers = 0;

    // Start is called before the first frame update
    private void Start()
    {
        numberOfPlayers = GameSetup.numberOfPlayers;
        
        whosTurn = 0;
        // Debug.Log("dice start:" + whosTurn);
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("Dice");
        rend.sprite = diceSides[5];

    }

    private void OnMouseDown()
    {
        // Debug.Log("dice onmouse:" + whosTurn);
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        SoundManagerScript.PlaySound("dice");
        // Debug.Log("dice roll:" + whosTurn);
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i < 12; i++)
        {
            randomDiceSide = Random.Range(0,6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.1f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;

        if (whosTurn == 0){
            GameControl.MovePlayer(1);
        } else if (whosTurn == 1){
            GameControl.MovePlayer(2);
        } else if (whosTurn == 2){
            GameControl.MovePlayer(3);
        } else if (whosTurn == 3){
            GameControl.MovePlayer(4);
        }

        // Debug.Log("na kraju"+whosTurn);
        
        coroutineAllowed = true;

    }

    // is there enough fields to move piece forward?
    // private bool checkIfPossibleToMove(int randomDiceSide, int whosTurn){
    //     switch (whosTurn) {

    //         case 0:
    //             if (player1.GetComponent<FollowThePath>().waypointIndex + randomDiceSide > 100){
    //                 return false;
    //                 break;
    //             }

    //         case 1:
    //             if (player2.GetComponent<FollowThePath>().waypointIndex + randomDiceSide > 100){
    //                 return false;
    //                 break;
    //             }
                

    //         default:
    //             return true;
    //     }
        
    // }
}