using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConstants : Singleton<DataConstants>
{
    public float Speed;
    public float[] BlockY;
    public float BlockMinX, BlockMaxX;
    public float TargetMinX, TargetMaxX,TargetY;

    public Vector3 PlayerInitilizePosition()
    {
       return new Vector3(0, -TargetY, 0);
    }
}
