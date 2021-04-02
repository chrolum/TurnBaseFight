using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedFight
{
	class GlobalHerosPool
	{
		public static List<CharacterBase> herosPool = new List<CharacterBase>(30);
		private GlobalHerosPool() { }

		private static GlobalHerosPool _instance;

		public static GlobalHerosPool GetInstance()
		{
			if (_instance == null)
			{
				_instance = new GlobalHerosPool();
			}

			return _instance;
		}

		static public CharacterBase GetHerosByIdx(int idx)
		{
			if (idx >= herosPool.Count)
				return null;

			return herosPool[idx];
		}
	}
}
