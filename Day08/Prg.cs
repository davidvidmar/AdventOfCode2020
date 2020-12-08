using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Prg : List<Inst>
    {
        private int acc = 0;

        public int Acc
        {
            get { return acc; }
        }

        private int[] trace;
        private int i = 0;

        public bool Output = false;

        //public Prg()
        //{
            
        //}

        public Prg(string[] lines)
        {
            Read(lines);
        }

        public void Read(string[] lines)
        {
            Clear();
            Reset();
            foreach (var line in lines)
            {
                var s = line.Split(' ');
                var op = s[0];
                var arg = Convert.ToInt32(s[1]);
                AddInst(op, arg);
            }
        }

        public int Execute()
        {
            Reset();

            var line = 0;
            var end = false;
            
            while (!end)
            {
                // *** infinite loop detection
                if (trace[line] == 0) trace[line] = i++;
                else
                {
                    if (Output) Console.WriteLine($"Infinite loop detected. Value of arg: {acc}");
                    return -1;
                }
                // ***

                line += ExecuteInstruction(this[line]);
                end = line == Count;
            }
            return 0;
        }
        private int ExecuteInstruction(Inst ins)
        {
            var r = 1;

            switch (ins.op)
            {
                case "acc":
                    acc += ins.arg;
                    break;
                case "jmp":
                    r = ins.arg;
                    break;
                case "nop":
                    break;
            }

            if (Output) Console.WriteLine($"{ins.op} {ins.arg,-3} | {i} | {acc} -> {r}");
            return r;
        }

        private void AddInst(string op, int arg)
        {
            Add(new Inst(op, arg));
        }

        private void Reset()
        {
            acc = 0;
            i = 0;
            trace = new int[Count];            
        }

    }

    class Inst
    {
        public string op;
        public int arg;

        public Inst(string op, int arg)
        {
            this.op = op;
            this.arg = arg;
        }
    }
}
