using System;
using Game.Abstractions;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Models;

namespace Game.Views
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteTileView : AbstractTile
    {
        private SpriteCache _cache;
        private Sprite _sprite;

        private void Awake()
        {
            _cache = Locator.Get<SpriteCache>();
        }

        public void OnClick()
        {
            Debug.Log("Click", this);
        }

        public override void Init(int type)
        {
            Assert.IsTrue(type < _cache.Length, "Type must be lower than " + _cache.Length);
             _type = type;
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _sprite = _cache.Get(Type);
            spriteRenderer.sprite = _sprite;
        }
    } 
}