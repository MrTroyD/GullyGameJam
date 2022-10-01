using UnityEngine;

public class Player:MonoBehaviour
{
    [SerializeField] Material _standardMaterial; //Will I swap materials? Or entire models? 

    [SerializeField] Animation _globalPlayerAnimator;
    [SerializeField] GameObject _playerModelA;
    [SerializeField] GameObject _playerModelB;

    [SerializeField] Transform _playerArea;

    [SerializeField] GullyGameManager _gameManager;

    [SerializeField]LayerMask _queryMask;
    [SerializeField] PlayerControl _playerControls;

    float _rotationSpeed = 360f;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(this._playerArea.position, .5f, this._queryMask);

        foreach(Collider col in colliders)
        {
            print(col.name);
            switch (col.tag)
            {
                case "Collectible":
                    OnCollectible(col);
                    break;
            }
        }


        if (this._playerControls.velocity != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(this._playerControls.velocity, Vector3.up);
            this._playerArea.rotation = Quaternion.RotateTowards(this._playerArea.rotation, toRotation, this._rotationSpeed * Time.deltaTime);
        }

    }

    public void EnableControls()
    {
        this._playerControls.EnableControls();
    }

    public void DisableControls()
    {
        this._playerControls.DisableControls();
    }

    void OnCollectible(Collider col)
    {
        GameCollectible collectible = col.GetComponent<GameCollectible>();

        if (collectible == null) return;

        this._gameManager.OnCollectible(collectible.collectibleType);

        collectible.OnCollect();
    }
}

