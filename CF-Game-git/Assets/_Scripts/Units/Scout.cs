public class Scout : UnitBehavior
{
	protected override void Defend(Unit other, int damage)
	{
		var realDamage = damage;
		if (other is Assault)
			realDamage *= 2;//Assault Units deals double damage to Scout Units.

		base.Defend(other, realDamage);
	}
}