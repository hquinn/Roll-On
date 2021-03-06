using System;
using System.Collections.Generic;

namespace RollOn
{
	public class MultiplyNode : ValueObject, INode
	{
		public MultiplyNode(INode first, INode second)
		{
			First = first ?? throw new ArgumentNullException(nameof(first), "Node must be set.");
			Second = second ?? throw new ArgumentNullException(nameof(second), "Node must be set.");
		}

		public INode First { get; }
		public INode Second { get; }

		public DiceResult Evaluate(IRoller roller, IVariableInjector variableInjector) => First.Evaluate(roller, variableInjector) * Second.Evaluate(roller, variableInjector);
		public override string ToString() => $"{First} * {Second}";

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return First;
			yield return Second;
		}
	}
}