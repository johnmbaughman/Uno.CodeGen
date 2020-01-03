// ******************************************************************
// Copyright � 2015-2018 nventive inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ******************************************************************
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.Equality;

namespace Uno.CodeGen.Tests
{
	public partial class Given_GeneratedEquality
	{
		[TestMethod]
		public void Equality_WhenUsingDifferentDerivedTypes()
		{
			var d1 = new MyDerived1.Builder { a = 10, b = 15, }.ToImmutable();
			var d2 = new MyDerived2.Builder { a = 10, c = 25, }.ToImmutable();
			var d3 = new MyDerived3.Builder { a = 10, b = 15, c=25 }.ToImmutable();

			(d1 == d2).Should().BeFalse();
			d1.Equals(d2).Should().BeFalse();
			d2.Equals(d1).Should().BeFalse();
			(d1==d3).Should().BeFalse();
			d1.Equals(d3).Should().BeFalse();
			d3.Equals(d1).Should().BeFalse();
		}

	}

	[GeneratedImmutable]
	internal partial class MyBase
	{
		public int a { get; }
	}
	internal partial class MyDerived1 : MyBase
	{
		public int b { get; }
	}
	internal partial class MyDerived2 : MyBase
	{
		public int c { get; }
	}
	internal partial class MyDerived3 : MyDerived1
	{
		public int c { get; }
	}
}
