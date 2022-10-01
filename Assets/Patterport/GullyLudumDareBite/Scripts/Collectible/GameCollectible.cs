using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCollectible : MonoBehaviour
{
    public enum CollectibleType
    {
        Dud,
        TimeBonus
    }

    [SerializeField] CollectibleType _type;

    public CollectibleType collectibleType
    {
        get { return this._type; }
    }

    public void OnCollect()
    {
        Debug.Log("I got em");
        Destroy(this.gameObject);
    }
}
