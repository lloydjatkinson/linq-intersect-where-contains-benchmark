using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    [InProcess]
    public class Benchmark
    {
        private readonly List<int> _first = new List<int>();
        private readonly List<int> _second = new List<int>();

        private readonly Consumer _consumer = new Consumer();

        public Benchmark()
        {
            var random = new Random();

            for (int i = 0; i < 500; i++)
            {
                _first.Add(random.Next(0, 1001));
            }

            for (int i = 0; i < 500; i++)
            {
                _second.Add(random.Next(0, 1001));
            }
        }

        [Benchmark]
        public void Intersect()
        {
            _first.Intersect(_second).Consume(_consumer);
        }

        [Benchmark]
        public void Where()
        {
            _first.Where(x => _second.Contains(x)).Consume(_consumer);
        }
    }
}
