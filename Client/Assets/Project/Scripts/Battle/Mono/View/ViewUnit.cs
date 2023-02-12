/*********************************************************************************
 *Author:         Wulala
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2023-01-31
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using IFramework;
using LockStep.Math;
using UnityEngine;

namespace EasyMoba.GameLogic.Mono
{
	public class ViewUnit : UnityEngine.MonoBehaviour
	{
		public MobaUnit logic_unit;
    }
	public class PlayerUnitView : ViewUnit
	{
		public PlayerUnit logic_player { get { return logic_unit as PlayerUnit; } }
		private void OnEnable()
		{
			Camera.main.transform.parent = this.transform;
		}
		private void Update()
		{
			var pos = this.logic_player.position.ToVector3XZ();
			this.transform.position = pos;
		}
	}
}
