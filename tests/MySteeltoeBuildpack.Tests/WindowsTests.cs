using CloudFoundry.Buildpack.V2.Testing;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using static CloudFoundry.Buildpack.V2.Testing.DirectoryHelper;

namespace MySteeltoeBuildpack.Tests;

[Collection(nameof(ContainerPlatform.Windows))]
public class WindowsTests(ITestOutputHelper output, WindowsStackFixture fixture) : BaseTests(output, fixture)
{
    
    
}