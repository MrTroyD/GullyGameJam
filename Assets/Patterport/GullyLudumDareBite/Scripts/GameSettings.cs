using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="GullyBite/Settings")]
public class GameSettings : ScriptableObject
{
    public bool debug = true;
    public int seed = 9291979;
}
