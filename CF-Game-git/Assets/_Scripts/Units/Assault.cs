public class Assault : UnitBehavior
{
	protected override void Defend(Unit other, int damage)
	{
		var realDamage = damage;
		if (other is Heavy)
			realDamage *= 2;//Heavy Units deals double damage to Assault Units.

		base.Defend(other, realDamage);
	}
}
