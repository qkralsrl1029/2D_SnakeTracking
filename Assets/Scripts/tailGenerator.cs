using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailGenerator : MonoBehaviour
{
    [SerializeField] GameObject currentTail;
    [SerializeField] GameObject firstTail;
    [SerializeField] Transform parent;
    [SerializeField] GameObject go_body;

    [SerializeField] Color[] colors;
    int currentColor = 0;


    List<GameObject> tails = new List<GameObject>();

    
    public void createNewTail()
    {
        GameObject newTail = Instantiate(go_body,currentTail.transform.position,Quaternion.identity, parent);
        tails.Add(newTail);
        newTail.GetComponent<BodyScript>().setPrev(currentTail);
        newTail.GetComponent<SpriteRenderer>().color = colors[currentColor++ % 7];
        currentTail = newTail;
    }

    public void removeTails()
    {
        for (int i = 0; i < tails.Count; i++)
        {
            Destroy(tails[i]);
        }
        tails.Clear();
        currentTail = firstTail;
    }
    
}
