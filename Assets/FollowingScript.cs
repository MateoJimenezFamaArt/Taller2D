using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingScript : MonoBehaviour
{

    public Transform Target;
    public float Dis;


    // Update is called once per frame
    void Update()
    {
        Dis = Vector2.Distance(transform.position, Target.transform.position);

        if (Dis >= 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, 5 * Time.deltaTime);
        }

        if (Target = null)
        {
            Destroy(gameObject);
        }

    }
}
