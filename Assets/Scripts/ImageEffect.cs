using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class ImageEffect : MonoBehaviour
{
    [SerializeField] private Material imageEffect;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, imageEffect);
    }
}
