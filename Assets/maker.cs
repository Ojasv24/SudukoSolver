using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class maker : MonoBehaviour
{
    public GameObject prefab;
    public Image BlackBackGround;
    public Image BackGround;
    GameObject parent;

    void Start()
   {
        
        var xpos = -400;
        var ypos = 400;
        
        for (int j = 0; j < 9; j++)
        {
            ypos -= j % 3 == 0 ? 12 : 0;
            for (int i = 0; i < 9; i++)
            {
                xpos += i % 3 == 0 ? 12 : 0;
                parent = Instantiate(prefab, new Vector3(xpos, ypos, 0), Quaternion.identity)
                    as GameObject;
                parent.name = i.ToString() + " " + j.ToString();
                
                parent.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                parent.transform.SetAsFirstSibling();
                
                xpos += 100;
            }
            xpos = -400;
            ypos -= 100;
        }
        BlackBackGround.transform.SetAsFirstSibling();
        BackGround.transform.SetAsFirstSibling();
    }

}
