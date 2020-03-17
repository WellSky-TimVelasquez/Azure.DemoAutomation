using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

[SetUpFixture]
public class KTOneTimeSetup : WebGlobalSetup
{
    /// <summary>
    /// This setup runs automatically before the actual test suite starts running.
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetup()
    {

    }

    /// <summary>
    /// This Teardown runs automatically after the actual test suite has completed running.
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
    }
}
