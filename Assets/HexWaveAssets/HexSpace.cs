using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSpace : MonoBehaviour {

    public List<GameObject> HexConnections = new List<GameObject>();
    public GameObject rock;
    public bool playerSelect;
    public bool stoneSelect;
    public int distance;
    public int onHex; //0- empty, 1-player, 2-rock, 3- wave, 4-rock and wave,


}
