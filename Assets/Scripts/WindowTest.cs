using UnityEngine;
using UnityEditor;
public class WindowTest : EditorWindow
{

    public Color _color;
    private Transform _mainCamera;
    public MeshRenderer _meshRenderer;
    float value = 1f;
    [MenuItem("��������� �������/������/���������")]
    public static void ShowMyWindow()
    {
        GetWindow(typeof(WindowTest), false, "��������� �������");
    }
    private void OnGUI()
    {
        _meshRenderer = EditorGUILayout.ObjectField("������", _meshRenderer, typeof(MeshRenderer), true) as MeshRenderer;
        value = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 50, 90, 200, 30), value, 1.0f, 10f);
      

        if (GUI.Button(new Rect(Screen.width / 2 - 80, 30, 160, 30), "���������"))
        {
            TransformObject(_meshRenderer, value);
        }
    }

    public void TransformObject(MeshRenderer mesh, float val)
    {
        var transform = mesh.GetComponent<Transform>();
        if (transform)
        {
            transform.localScale = new Vector3(val, val, val);
        }
    }
}
