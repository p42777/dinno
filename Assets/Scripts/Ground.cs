using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Ground : MonoBehaviour{
    private MeshRenderer meshRenderer;

    // Awake is called automatically when the script is initialized
    private void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update(){
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime; // change offset property
    }

}

