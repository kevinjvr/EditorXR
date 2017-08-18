﻿#if UNITY_EDITOR
using UnityEditor.Experimental.EditorVR.Modules;
using UnityEngine;

namespace UnityEditor.Experimental.EditorVR
{
	/// <summary>
	/// Gives decorated class ability to control/perform spatial-scrolling
	/// </summary>
	public interface IControlSpatialScrolling
	{
	}

	public static class IControlSpatialScrollingMethods
	{
		internal delegate SpatialScrollModule.SpatialScrollData PerformSpatialScrollDelegate (object caller, Node? node, Vector3 startingPosition,
			Vector3 currentPosition, float repeatingScrollLengthRange, int scrollableItemCount, int maxItemCount = -1);
		internal static PerformSpatialScrollDelegate performSpatialScroll { private get; set; }

		/// <summary>
		/// Perform a spatial scroll action
		/// </summary>
		/// <param name="caller">The object requesting the performance of a spatial scroll action</param>
		/// <param name="node">The node on which to display & perform the spatial scroll</param>
		/// <param name="startingPosition">The initial position of the spatial scroll</param>
		/// <param name="currentPosition">The current/updated position of the spatial scroll</param>
		/// <param name="repeatingScrollLengthRange">The length at which a scroll action will return a repeating/looping value</param>
		/// <param name="scrollableItemCount">The number of items being scrolled through with this action</param>
		/// <param name="maxItemCount">The maximum number of items that can be scrolled through for this action</param>
		/// <returns>The spatial scroll data for a single scroll action, but an individual caller object</returns>
		public static SpatialScrollModule.SpatialScrollData PerformSpatialScroll(this IControlSpatialHinting obj, object caller, Node? node,
			Vector3 startingPosition, Vector3 currentPosition, float repeatingScrollLengthRange, int scrollableItemCount, int maxItemCount = -1)
		{
			return performSpatialScroll(caller, node, startingPosition, currentPosition, repeatingScrollLengthRange, scrollableItemCount, maxItemCount);
		}

		internal delegate void EndSpatialScrollDelegate (object caller);
		internal static EndSpatialScrollDelegate endSpatialScroll { private get; set; }

		/// <summary>
		/// End a spatial scrolling action for a given caller
		/// </summary>
		/// <param name="caller">The caller whose spatial scroll action will be ended</param>
		public static void EndSpatialScroll(this IControlSpatialHinting obj, object caller)
		{
			endSpatialScroll(caller);
		}
	}
}
#endif