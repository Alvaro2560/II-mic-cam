using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificator : MonoBehaviour
{
    public delegate void Message();
    public event Message OnSpiderCollision;
    public event Message OnEggCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spider")
        {
            OnSpiderCollision();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Egg")
        {
            OnEggCollision();
            other.gameObject.SetActive(false);
        }
    }
}
