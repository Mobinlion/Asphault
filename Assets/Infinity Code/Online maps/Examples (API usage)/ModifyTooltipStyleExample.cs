/*     INFINITY CODE 2013-2017      */
/*   http://www.infinity-code.com   */

using UnityEngine;

namespace InfinityCode.OnlineMapsExamples
{
    /// <summary>
    /// Example of how to intercept preparation of style for drawing tooltips.
    /// </summary>
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/ModifyTooltipStyleExample")]
    public class ModifyTooltipStyleExample : MonoBehaviour
    {


        private void Start()
        {
			//Debug.Log (Screen.dpi);
            // Subscribe to the event preparation of tooltip style.
            OnlineMaps.instance.OnPrepareTooltipStyle += OnPrepareTooltipStyle;
			OnlineMaps.instance.zoomRange = new OnlineMapsRange(3, 18);

        }

        private void OnPrepareTooltipStyle(ref GUIStyle style)
        {
            // Change the style settings.
			if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight || 
				Screen.orientation == ScreenOrientation.Landscape)
				style.fontSize = Screen.height / 35;
			else if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
				style.fontSize = Screen.width / 25;
		}
        
    }
}
