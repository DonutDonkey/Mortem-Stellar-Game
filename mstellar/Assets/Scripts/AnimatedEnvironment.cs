using System.Collections;
using UnityEngine;

public class AnimatedEnvironment : MonoBehaviour 
{
    [Tooltip("Aniamted texture frames, will automatically go trough all frames")]
    [SerializeField] private DAnimatedTexture animatedTexture = null;

    [Tooltip("Speed at with animation will switch frames, highier number equals slower animation speed")]
    [SerializeField] private float animationSpeed = 1.0f;

    private MeshRenderer meshRenderer;

    IEnumerator Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        while(true) 
        {
            foreach (Texture i in animatedTexture.textures) {
                meshRenderer.material.mainTexture = i;
                yield return new WaitForSeconds(animationSpeed);
            }
        }
    }
}
