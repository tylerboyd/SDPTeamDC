using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVisual : MonoBehaviour {

    [SerializeField]
    GameObject hitPicture;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Enemy"))
        {
            Instantiate(hitPicture, new Vector2(transform.position.x + 1f, transform.position.y),
                Quaternion.identity);
        }
    }
}
