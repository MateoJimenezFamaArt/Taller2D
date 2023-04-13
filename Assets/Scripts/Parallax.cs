using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{


    [SerializeField] private Vector2 parallaxEffectMultiplier;

    [SerializeField] private Vector3 lastCameraPosition;
    private Transform cameraTransform;
    private float textureUnitSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;

    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3 (deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y , 0);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) 
        {
            float offsetPosX = (cameraTransform.position.x - transform.position.y) / textureUnitSizeX;
            transform.position = new Vector3 (cameraTransform.position.x + offsetPosX, transform.position.y, 0);        
        }
    }
}
