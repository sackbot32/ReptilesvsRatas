using UnityEngine;

public class SelectorTest : MonoBehaviour
{
    TileComponent currentTile;
    Color changedColor = new Color(0.4f, 1, 1);
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<TileComponent>() != null)
        {
            if(currentTile != collision.gameObject.GetComponent<TileComponent>())
            {
                currentTile = collision.gameObject.GetComponent<TileComponent>();
                int[] coords = GridManager.instance.WhereTile(currentTile);
                print("line " + coords[0] + " column " + coords[1]);
                ChangeColorInCross();
            }
        }
    }


    private void ChangeColorInCross()
    {
        foreach(TileComponent allTile in GridManager.instance.allTiles.tiles)
        {
            allTile.sRendrer.color = Color.white;
        }
        int[] coords = GridManager.instance.WhereTile(currentTile);
        foreach(TileComponent lineTile in GridManager.instance.lines[coords[0]].tiles)
        {
            lineTile.sRendrer.color = changedColor;
        }
        foreach (TileComponent columnTile in GridManager.instance.columns[coords[1]].tiles)
        {
            columnTile.sRendrer.color = changedColor;
        }
    }

}
