using UnityEngine;
using Random = System.Random;

public class SpawnAndRemoveMarkers:MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("Spawn"))
        {
            double tlx, tly, brx, bry;
            OnlineMaps.instance.GetCorners(out tlx, out tly, out brx, out bry);
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                double lng = rnd.NextDouble() * (brx - tlx) + tlx;
                double lat = rnd.NextDouble() * (tly - bry) + bry;
                OnlineMaps.instance.AddMarker(lng, lat, i.ToString());
            }
        }
        if (GUILayout.Button("Remove all markers"))
        {
            OnlineMaps.instance.RemoveAllMarkers();
            OnlineMaps.instance.Redraw();
        }
    }
}

