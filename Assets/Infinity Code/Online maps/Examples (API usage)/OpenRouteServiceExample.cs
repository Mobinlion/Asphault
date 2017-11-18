/*     INFINITY CODE 2013-2017      */
/*   http://www.infinity-code.com   */

using System.Collections.Generic;
using UnityEngine;

namespace InfinityCode.OnlineMapsExamples
{
    /// <summary>
    /// Example of a request to Open Route Service.
    /// </summary>
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/OpenRouteServiceExample")]
    public class OpenRouteServiceExample : MonoBehaviour
    {
		private OnlineMapsOpenRouteServiceDirectionResult tesla;
		private OnlineMapsOpenRouteServiceDirectionResult.Route []tesla2; 
        /// <summary>
        /// Open Route Service API key
        /// </summary>
        public string key;

        private void Start()
		{
            // Looking for pedestrian route between the coordinates.
            OnlineMapsOpenRouteService.Directions(
                new OnlineMapsOpenRouteService.DirectionParams(key, 
                    new []
                    {
                        // Coordinates
//                        new OnlineMapsVector2d(8.6817521f, 49.4173462f), 
//                        new OnlineMapsVector2d(8.6828883f, 49.4067577f)  //default
						new OnlineMapsVector2d(114.407878420738f, 30.510284051858f), 
						new OnlineMapsVector2d(114.421482327989f, 30.5164690022613f)
                    })
                {
                    // Extra params
                    language = "ru",
					profile = OnlineMapsOpenRouteService.DirectionParams.Profile.footWalking
                }).OnComplete += OnRequestComplete;
        }

        /// <summary>
        /// This method is called when a response is received.
        /// </summary>
        /// <param name="response">Response string</param>
        private void OnRequestComplete(string response)
        {
            Debug.Log(response);

            // Get the route steps.
            //List<OnlineMapsDirectionStep> steps = OnlineMapsDirectionStep.TryParseORS(response);

			tesla = OnlineMapsOpenRouteService.GetDirectionResults (response);
            // Get the route points.
			tesla2 = tesla.routes;
			Debug.Log (tesla.routes.Length);
			List<OnlineMapsVector2d> points = tesla2[0].points;

            // Draw the route.
            //OnlineMaps.instance.AddDrawingElement(new OnlineMapsDrawingLine(points, Color.red));
			OnlineMaps.instance.AddDrawingElement (new OnlineMapsDrawingLine (points, Color.red, 5));

            // Set the map position to the first point of route.
            OnlineMaps.instance.position = points[0];
        }
    }
}