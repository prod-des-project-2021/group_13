using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CanvasSave : MonoBehaviour
{
    private static CanvasSave canvas;
        void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        if (canvas == null){
            canvas = this;
        } else {
            DestroyObject(gameObject);
        }


    }
}
