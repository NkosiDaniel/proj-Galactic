using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{

   private void Update() {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

       Material mat = meshRenderer.material;
       Vector2 offset = mat.GetTextureOffset("_MainTex");
       offset.x += Time.deltaTime / 5f;

       mat.mainTextureOffset = offset;
   }
}
