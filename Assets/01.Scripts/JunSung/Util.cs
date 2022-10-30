using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static Vector3 mousePosition
    {
        get
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 Pos = new Vector3(mousePos.x, mousePos.y, 0);
            return Pos;
        }
    }
}
