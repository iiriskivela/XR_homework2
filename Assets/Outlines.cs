using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ObjectOutline : MonoBehaviour
{
    public Color outlineColor = Color.white;
    [Range(0.0f, 40.0f)]
    public float outlineThickness = 0.05f;

    private Material outlineMaterial;
    private Renderer objectRenderer;

    void Start()
    {
        // Create a new material for the outline
        outlineMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));
        outlineMaterial.hideFlags = HideFlags.HideAndDontSave;
        outlineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        outlineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        outlineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Back);
        outlineMaterial.SetInt("_ZWrite", 0);
        outlineMaterial.SetInt("_ZTest", (int)UnityEngine.Rendering.CompareFunction.Always);
        outlineMaterial.color = outlineColor;

        // Get the renderer of the object
        objectRenderer = GetComponent<Renderer>();
    }

    void OnRenderObject()
    {
        // Set the material to the outline material
        outlineMaterial.SetPass(0);

        // Draw the outline
        Graphics.DrawMeshNow(objectRenderer.GetComponent<MeshFilter>().sharedMesh, transform.position, transform.rotation);
    }

    void OnDisable()
    {
        // Clean up the outline material
        if (outlineMaterial != null)
        {
            Destroy(outlineMaterial);
        }
    }

    void OnValidate()
    {
        // Ensure that outlineThickness does not go out of range
        outlineThickness = Mathf.Clamp(outlineThickness, 0.0f, 40.0f);
    }
}
