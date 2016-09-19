using Game.Abstractions;
using Game.Views;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Extentions;

namespace Game.Views
{
    public class GridView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _template;

        [SerializeField]
        private Vector2 _cellSize;

        private IGridModel _model;
        private AbstractTile[] _tiles;

        private void Awake()
        {
            Assert.IsNotNull(_template, "You must specify a template");
            _model = Locator.GetInterface<IGridModel>();
        }

        private void Start()
        {
            _tiles = new AbstractTile[_model.NumberOfTiles];
            int index = 0;
            for (int i = 0; i < _model.Rows; i++)
            {
                for (int j = 0; j < _model.Columns; j++)
                {
                    GameObject tileObject = Instantiate(_template, transform) as GameObject;
                    AbstractTile tile = tileObject.GetComponent<AbstractTile>();
                    tile.Init(_model.Get(i, j));
                    tile.transform.localPosition = PositionOf(i, j);
                    _tiles[index] = tile;
                    index++;
                }
            }
        }

        private Vector3 PositionOf(int row, int column)
        {
            return new Vector3(column * _cellSize.x, row * _cellSize.y, 0f);
        }
    } 
}