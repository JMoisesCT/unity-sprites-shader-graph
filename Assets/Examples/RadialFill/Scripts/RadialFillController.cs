namespace MoisesCT.SpritesShaderGraph.RadialFill
{
    using UnityEngine;

    public class RadialFillController : MonoBehaviour
    {
        [SerializeField] [Range(0, 1f)] private float _fill;
        [SerializeField] private bool _clockwise;
        [SerializeField] [Range(0, 360f)] private float _originAngle;

        private SpriteRenderer _renderer;

        private void OnValidate()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void UpdateFillAmount()
        {
            _renderer.sharedMaterial.SetFloat("_FillAmount", _fill);
        }

        public void UpdateClockwise()
        {
            float numBool = _clockwise ? 1f : 0f;
            _renderer.sharedMaterial.SetFloat("_Clockwise", numBool);
        }

        public void UpdateOriginAngle()
        {
            _renderer.sharedMaterial.SetFloat("_OriginAngle", _originAngle);
        }
    }

}
