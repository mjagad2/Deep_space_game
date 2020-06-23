using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class InstructionTest 
{
    [Test]
    public void test_leaveScene1()
    {
        var inst = new Instruction();
        inst.leaveScene1();
    }
}
