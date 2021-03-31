using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedFight
{
	class GlobalSkillPool
	{
		Dictionary<int, SkillBase> skillPool = new Dictionary<int, SkillBase>()
		{
		};
		private GlobalSkillPool() { }

		private static GlobalSkillPool _instance;

		public static GlobalSkillPool GetInstance()
		{
			if (_instance == null)
			{
				_instance = new GlobalSkillPool();
			}

			return _instance;
		}

		public static SkillBase RegisterSkill(SkillType stype)
		{
			switch (stype)
			{
				case SkillType.EnumArcaneMissile:
					return new ArcaneMissile();
				case SkillType.EnumNormalHealth:
					return new NormalHealth();
				case SkillType.EnumCriticalHit:
					return new CriticalHit();
				case SkillType.EnumLearnVital:
					return new LearnVital();
				case SkillType.EnumMoonWellPower:
					return new MoonWellPower();
			}
			return new SkillBase();
		}

	}
}
