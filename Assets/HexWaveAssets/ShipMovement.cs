using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    
    public GameObject controller;

    public float moveSpeed=1;
    public float rotationSpeed;

    public bool animationFlag = true;//while true animation is executing
    public bool moveFlag;//when true ship moves to next hex
    public bool playTurn;//when play turn is false turn ends
    public bool action; //can move or push rock
    public int selectAction; //0 move, 1 move rock, 2 push rock 

    public List<GameObject> availableMoves=new List<GameObject>();
    public List<GameObject> availableRocks = new List<GameObject>();
    public GameObject currentHex;
    public GameObject nextHex,rockHex;//nextHex is object that player moves to, rockHex is object that playter interacts

    public TeamEnum myTeam;

    public void DeathTrigger()//function that trigers when object dies
    {

    }


    public void AddAvailableMoves()
    {
        HexSpace hs = currentHex.GetComponent<HexSpace>();
        foreach(GameObject i in hs.HexConnections)
        {
            if (i.GetComponent<HexSpace>().onHex == 0)
            {
                availableMoves.Add(i);
            }
        }
    }
    public void AddAvailableRocks()
    {
        HexSpace hs = currentHex.GetComponent<HexSpace>();
        foreach (GameObject i in hs.HexConnections)
        {
            if (i.GetComponent<HexSpace>().onHex == 2)
            {
                availableMoves.Add(i);
            }
        }
    }
    public void SelectMove(GameObject selectedHex) // selects next hex to move to
    {
        foreach (GameObject i in availableMoves)
        {
            if (selectedHex == i)
            {
                nextHex=selectedHex;
                break;
            }
        }
    }
    public void SelectRock(GameObject selectedHex)//selects next rock to interact
    {
        foreach(GameObject i in availableRocks)
        {
            if(selectedHex == i)
            {
                rockHex = selectedHex;
                break;
            }
        }

    }
    public void PossibleMoves()//changes posible moves to diffrent color
    {

    }
    public void HexInteract()// interacts with selected hex
    {
        if (action == true)
        {
            switch (selectAction)
            {
                case 0: moveFlag = true; break;
                case 1:  break;
                case 2: break;
            }
            action = false;
        }

    }

    public void MoveCurNext() //moves from current hex to next
    {
        if (nextHex != null)
        {
            float moveStep = moveSpeed * Time.deltaTime;
            float rotateStep = rotationSpeed * Time.deltaTime;
            Vector3 targetDir = nextHex.transform.position - transform.position;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, rotateStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position = Vector3.MoveTowards(transform.position, nextHex.transform.position, moveStep);
        }
    }

    public void MoveToHex()   //
    {
        if (playTurn == true)
        {

        }
    }

 /*  void OnMouseOver()
    {

        slimeEngine setB = cont.GetComponent<slimeEngine>();
        if (Input.GetMouseButtonDown(0))
        {
            selectObject();

        }

        if (check == false)
        {
            // Debug.Log(this.name);
            check = true;
        }
    }*/

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

         if (animationFlag == true)
         {
             MoveCurNext();
            // flag = false;
         }

    }
}

