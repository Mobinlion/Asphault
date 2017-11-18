using UnityEngine;

public class TilePreloader:MonoBehaviour
{
	// Number of tiles at the current zoom level.
	// If you do not want to load extra tiles on the sides of the map, this should be Width / 256 and Height / 256.
	public int countTilesX = 4;
	public int countTilesY = 4;

	public int countParentZoom = 7;
	public int countNextZoom = 1;

	private void Start()
	{
		OnlineMaps.instance.OnMapUpdated += PreloadTiles;
	}

	private void PreloadTiles()
	{
		foreach (OnlineMapsTile tile in OnlineMapsTile.tiles) tile.used = false;

		int countX = countTilesX * (1 << countNextZoom);
		int countY = countTilesY * (1 << countNextZoom);

		int cz = OnlineMaps.instance.zoom + countNextZoom;
		if (cz > OnlineMaps.MAXZOOM)
		{
			countX /= 1 << (cz - OnlineMaps.MAXZOOM);
			countY /= 1 << (cz - OnlineMaps.MAXZOOM);
			cz = OnlineMaps.MAXZOOM;
		}

		double tx, ty;
		OnlineMaps.instance.GetTilePosition(out tx, out ty, cz);

		tx -= countX / 2;
		ty -= countY / 2;
		int sx = (int) tx;
		int sy = (int) ty;
		int ex = sx + countX;
		int ey = sy + countY;

		int max = 1 << cz;

		if (sx < 0)
		{
			sx += max;
			ex += max;
		}
		if (sy < 0) sy = 0;
		if (ey > max) ey = max;

		bool needRedraw = false;

		for (int z = Mathf.Max(OnlineMaps.instance.zoom - countParentZoom, 3); z <= cz; z++)
		{
			int zoff = cz - z;
			int coof = 1 << zoff;
			int csx = sx / coof;
			int csy = sy / coof;
			int cex = ex / coof;
			int cey = ey / coof;
			int cmax = max / coof;

			for (int x = csx; x <= cex; x++)
			{
				int cx = x;
				if (cx >= cmax) cx -= cmax;

				for (int y = csy; y <= cey; y++)
				{
					OnlineMapsTile t;
					OnlineMapsTile parent;
					OnlineMapsTile.dTiles.TryGetValue(OnlineMapsTile.GetTileKey(z, cx, y), out t);
					if (t != null)
					{
						if (!t.isBlocked) t.Block(this);
						t.used = true;
						continue;
					}

					OnlineMapsTile.dTiles.TryGetValue(OnlineMapsTile.GetTileKey(z - 1, cx / 2, y / 2), out parent);

					t = new OnlineMapsTile(cx, y, z, OnlineMaps.instance, parent);
					t.Block(this);
					t.used = true;
					needRedraw = true;
				}
			}
		}

		foreach (OnlineMapsTile tile in OnlineMapsTile.tiles) if (!tile.used) tile.Unblock(this);
		if (needRedraw) OnlineMaps.instance.Redraw();
	}
}