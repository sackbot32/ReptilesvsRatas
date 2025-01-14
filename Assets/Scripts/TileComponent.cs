using UnityEngine;

public class TileComponent : MonoBehaviour
{
    GameObject objectOnTile;
    public SpriteRenderer sRendrer;

    private void Start()
    {
        sRendrer = GetComponent<SpriteRenderer>();
    }
    public bool HasGameObject()
    {
        return objectOnTile != null;
    }

    public bool SetGameObject(GameObject newObject,bool overrideObject = false)
    {
        bool beenSet = false;
        if(overrideObject && objectOnTile != null)
        {
            Destroy(objectOnTile);
            objectOnTile = null;
            objectOnTile = Instantiate(newObject,transform.position,Quaternion.identity,transform);
            beenSet = true;
        }
        if(objectOnTile == null)
        {
            objectOnTile = Instantiate(newObject, transform.position, Quaternion.identity, transform);
            beenSet = true;
        }
        return beenSet;
    }
}
