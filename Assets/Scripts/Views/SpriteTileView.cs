using Game.Abstractions;
using Game.Models;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Views
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteTileView : AbstractTile
    {
        private SpriteCache _cache;

        private void Awake()
        {
            _cache = Locator.Get<SpriteCache>();
        }

        public override void Init(int type)
        {
            Assert.IsTrue(type < _cache.Length, "Type must be lower than " + _cache.Length);
            _type = type;
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = _cache.Get(Type);
        }

        public void OnClick()
        {
            Debug.Log("Click", this);
        }
    }
}