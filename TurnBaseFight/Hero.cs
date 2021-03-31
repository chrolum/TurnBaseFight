using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedFight
{
	class WitchDoctor : CharacterBase
	{
		public WitchDoctor(int _HP = 100, int _DEF = 10, int _MP = 300, int _ATK = 10, int _DEX = 10)
			: base(_HP, _DEF, _MP, _ATK, _DEX)
		{
			name = "WitchDoctor";
			onwSkill[SkillType.EnumNormalHealth] = GlobalSkillPool.RegisterSkill(SkillType.EnumNormalHealth);
			onwSkill[SkillType.EnumMoonWellPower] = GlobalSkillPool.RegisterSkill(SkillType.EnumMoonWellPower);
		}
	}

	class Warrior : CharacterBase
	{
		public Warrior(int _HP = 100, int _DEF = 10, int _MP = 120, int _ATK = 10, int _DEX = 10)
			: base(_HP, _DEF, _MP, _ATK, _DEX)
		{
			name = "Warrior";
			onwSkill[SkillType.EnumCriticalHit] = GlobalSkillPool.RegisterSkill(SkillType.EnumCriticalHit);
			onwSkill[SkillType.EnumLearnVital] = GlobalSkillPool.RegisterSkill(SkillType.EnumLearnVital);
		}

	}

	class Magician : CharacterBase
	{
		public Magician(int _HP = 100, int _DEF = 10, int _MP = 400, int _ATK = 10, int _DEX = 10)
			: base(_HP, _DEF, _MP, _ATK, _DEX)
		{
			name = "Magician";
			onwSkill[SkillType.EnumArcaneMissile] = GlobalSkillPool.RegisterSkill(SkillType.EnumArcaneMissile);
		}
	}
}
