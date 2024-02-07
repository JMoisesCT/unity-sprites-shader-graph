namespace MoisesCT.SpritesShaderGraph.RadialFill
{
    using UnityEngine;

    public class RadialFillController : MonoBehaviour
    {
        [SerializeField] [Range(0, 1f)] private float _fill;
        [SerializeField] private bool _clockwise;
        [SerializeField] [Range(0, 360f)] private float _originAngle;

        private SpriteRenderer _renderer;
        private float _oldFill;
        private bool _oldClockwise;
        private float _oldOriginAngle;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _oldFill = -1f;
            _oldClockwise = !_clockwise;
            _oldOriginAngle = -1f;
        }

        private void Update()
        {
            if (_oldFill != _fill)
            {
                _oldFill = _fill;
                UpdateFillAmount();
            }
            if (_oldClockwise != _clockwise)
            {
                _oldClockwise = _clockwise;
                UpdateClockwise();
            }
            if (_oldOriginAngle != _originAngle)
            {
                _oldOriginAngle = _originAngle;
                UpdateOriginAngle();
            }
        }

        private void UpdateFillAmount()
        {
            _renderer.material.SetFloat("_FillAmount", _fill);
        }

        private void UpdateClockwise()
        {
            float numBool = _clockwise ? 1f : 0f;
            _renderer.material.SetFloat("_Clockwise", numBool);
        }

        private void UpdateOriginAngle()
        {
            _renderer.material.SetFloat("_OriginAngle", _originAngle);
        }
    }

}
