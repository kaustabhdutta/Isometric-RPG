using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region singelton
    public static Player instance;
    
    void Awake()
    {
        instance = this;
    }
    #endregion
   // public GameObject player;
    void Start ()
    {
		
	}

    void Update ()
    {
	    	
	}
}
