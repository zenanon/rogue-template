using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{


	public abstract class RLBaseTile
	{
		public delegate void OnTileDisplayRefreshDelegate(RLBaseTile tile);

		protected OnTileDisplayRefreshDelegate _tileDisplayRefresh;

		public OnTileDisplayRefreshDelegate TileDisplayRefresh
		{
			get { return _tileDisplayRefresh; }
			set
			{
				_tileDisplayRefresh = value;
				if (_tileDisplayRefresh != null)
				{
					_tileDisplayRefresh(this);
				}
			}
		}

		public abstract Vector3Int GetDisplayPosition();
		public abstract int GetDisplayType();
		public abstract RLBaseActor GetActor();
		public abstract void SetActor(RLBaseActor actor);
		public abstract RLTileType GetTileType();
	}
}