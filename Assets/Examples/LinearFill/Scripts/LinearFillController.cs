namespace MoisesCT.SpritesShaderGraph.LinearFill
{
    using UnityEngine;

    public class LinearFillController : MonoBehaviour
    {
        public enum FillOrigin
        {
            None, Bottom, Top, Left, Right
        }

        [SerializeField][Range(0, 1f)] private float _fill;
        [SerializeField] private FillOrigin _fillOrigin;

        private SpriteRenderer _renderer;
        private float _oldFill;
        private FillOrigin _oldFillOrigin;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _oldFill = -1f;
            _oldFillOrigin = FillOrigin.None;
        }

        private void Update()
        {
            if (_oldFill != _fill)
            {
                _oldFill = _fill;
                UpdateFillAmount();
            }
            if (_oldFillOrigin != _fillOrigin)
            {
                string oldKeyword = GetKeyword(_oldFillOrigin);
                _renderer.material.DisableKeyword(oldKeyword);
                _oldFillOrigin = _fillOrigin;
                string newKeyword = GetKeyword(_fillOrigin);
                _renderer.material.EnableKeyword(newKeyword);
            }
        }

        private void UpdateFillAmount()
        {
            _renderer.material.SetFloat("_FillAmount", _fill);
        }

        private string GetKeyword(FillOrigin fillOrigin)
        {
            string keyword = "_FILLORIGIN_BOTTOM"; // as default;
            switch (fillOrigin)
            {
                case FillOrigin.Bottom:
                    keyword = "_FILLORIGIN_BOTTOM";
                    break;
                case FillOrigin.Top:
                    keyword = "_FILLORIGIN_TOP";
                    break;
                case FillOrigin.Left:
                    keyword = "_FILLORIGIN_LEFT";
                    break;
                case FillOrigin.Right:
                    keyword = "_FILLORIGIN_RIGHT";
                    break;
            }
            return keyword;
        }
    }

}
