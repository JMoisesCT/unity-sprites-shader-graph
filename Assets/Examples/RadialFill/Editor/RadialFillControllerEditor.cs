namespace MoisesCT.SpritesShaderGraph.RadialFill
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(RadialFillController))]
    public class RadialFillControllerEditor : Editor
    {
        SerializedProperty fill;

        private void OnEnable()
        {
            fill = serializedObject.FindProperty("_fill");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            RadialFillController radialFill = (RadialFillController)target;
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(fill);
            if (EditorGUI.EndChangeCheck())
            {
                radialFill.UpdateFillAmount();
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}