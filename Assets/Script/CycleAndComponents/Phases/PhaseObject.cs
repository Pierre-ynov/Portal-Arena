using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseObject : Phase
{
    public List<Vector3> objectPositions = new List<Vector3>();
    public GameObject[] objectTiles;

    public override void action()
    {

        GameObject instance = null;
        GameObject toInstantiate = null;

        DeleteAllOldObject("Potion","Protection");

        foreach (Vector3 item in objectPositions)
        {
            // Remplace le sol par les sprites d'objet
            toInstantiate = objectTiles[Random.Range(0, objectTiles.Length)];

            instance = Instantiate(toInstantiate, item, Quaternion.identity) as GameObject;
        }
        GenerateCoolDown(time);
    }

    /// <summary>
    /// Supprime les objets déjà présents sur le terrain pour éviter une accumulation
    /// </summary>
    /// <param name="tagObject"></param>
    private void DeleteAllOldObject(params string[] tagObject)
    {
        foreach (string tag in tagObject)
        {
            GameObject[] tabObject = GameObject.FindGameObjectsWithTag(tag);
            foreach(GameObject itemObject in tabObject)
            {
                Destroy(itemObject);
            }
        }
    }
}
