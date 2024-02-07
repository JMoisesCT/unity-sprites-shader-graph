namespace MoisesCT.SpritesShaderGraph.RadialFill
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(RadialFillController))]
    public class RadialFillControllerEditor : Editor
    {
        SerializedProperty fill;
        SerializedProperty clockwise;
        SerializedProperty originAngle;

        private void OnEnable()
        {
            fill = serializedObject.FindProperty("_fill");
            clockwise = serializedObject.FindProperty("_clockwise");
            originAngle = serializedObject.FindProperty("_originAngle");
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
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(clockwise);
            if (EditorGUI.EndChangeCheck())
            {
                radialFill.UpdateClockwise();
            }
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(originAngle);
            if (EditorGUI.EndChangeCheck())
            {
                radialFill.UpdateOriginAngle();
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}