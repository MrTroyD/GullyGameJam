using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCameraTracking : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    Vector3 _playerSnapPoint = new Vector3();
    void Start()
    {
        
    }

    private void OnEnable()
    {
        this._playerSnapPoint = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this._playerSnapPoint.x = this._playerTransform.position.x;
        this._playerSnapPoint.z = this._playerTransform.position.z;

        this.transform.position = this._playerSnapPoint;
    }
}
