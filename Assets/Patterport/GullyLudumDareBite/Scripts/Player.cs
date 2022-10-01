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
    }

    void OnCollectible(Collider col)
    {
        GameCollectible collectible = col.GetComponent<GameCollectible>();

        if (collectible == null) return;

        this._gameManager.OnCollectible(collectible.collectibleType);

        collectible.OnCollect();
    }
}

