using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnim : MonoBehaviour
{
 void  Awake()
                   {
                     Destroy(gameObject,0.7f);
                   }
}
