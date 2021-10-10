using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para configuração da força de impulso da colisão na bolinha
[System.Serializable]
public class Shot{ //força ball
    public float upForce;
    public float hitForce;
}

public class ShotManager : MonoBehaviour
{
   
    public Shot topSpin;
    public Shot flat;
}
