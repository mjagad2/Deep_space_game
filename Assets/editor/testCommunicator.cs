using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class testCommunicator
{
  
    [Test]
    public void test_leaveScene1()
    {
        var inst = new MainMenu();
        inst.leaveScene();
    }
}

