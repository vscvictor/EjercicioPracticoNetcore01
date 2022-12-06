using System;
using Alba;


namespace WSEvaluacion01.IntegrationTest;

public class WebApiFixture : IDisposable
{

    public readonly AlbaHost albaHost;
    public WebApiFixture()
    {
        albaHost = AlbaHost.ForStartup<Program>();

    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
