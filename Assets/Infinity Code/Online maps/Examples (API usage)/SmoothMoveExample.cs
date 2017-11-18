/*     INFINITY CODE 2013-2017      */
/*   http://www.infinity-code.com   */

using UnityEngine;

namespace InfinityCode.OnlineMapsExamples
{
    /// <summary>
    /// Example of a smooth movement to current GPS location.
    /// </summary>
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/SmoothMoveExample")]
    public class SmoothMoveExample : MonoBehaviour
    {
        /// <summary>
        /// Move duration (sec)
        /// </summary>
        public float time = 3;

        /// <summary>
        /// Relative position (0-1) between from and to
        /// </summary>
        private float angle;

        /// <summary>
        /// Movement trigger
        /// </summary>
        private bool isMovement;

        private Vector2 fromPosition;
        private Vector2 toPosition;


		public void hustFindMeGPS()
        {
			fromPosition = OnlineMaps.instance.position;

			// to GPS position;
			toPosition = OnlineMapsLocationService.instance.position;

			//*** must do*********************************************************
			//add 0,0 check if equals to zero return function...
			//*** must do*********************************************************

			// calculates tile positions
			double fromTileX, fromTileY, toTileX, toTileY;
			OnlineMaps.instance.projection.CoordinatesToTile(fromPosition.x, fromPosition.y, OnlineMaps.instance.zoom, out fromTileX, out fromTileY);
			OnlineMaps.instance.projection.CoordinatesToTile(toPosition.x, toPosition.y, OnlineMaps.instance.zoom, out toTileX, out toTileY);

			// if tile offset < 4, then start smooth movement
			if (OnlineMapsUtils.Magnitude(fromTileX, fromTileY, toTileX, toTileY) < 4)
			{
				// set relative position 0
				angle = 0;

				// start movement
				if (toPosition.x != 0 || toPosition.y != 0)
					isMovement = true;
			}
			else // too far
			{
				if (toPosition.x == 0 && toPosition.y == 0)
					return;
				OnlineMaps.instance.position = toPosition;
				OnlineMaps.instance.zoom = 17;
			}
           
        }

        private void Update()
        {
            // if not movement then return
            if (!isMovement) return;

            // update relative position
            angle += Time.deltaTime / time;

            if (angle > 1)
            {
                // stop movement
                isMovement = false;
                angle = 1;
            }

            // Set new position
            OnlineMaps.instance.position = Vector2.Lerp(fromPosition, toPosition, angle);
			OnlineMaps.instance.zoom = 17;
        }
    }
}