using CloudFoundry.Buildpack.V2.Testing;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using static CloudFoundry.Buildpack.V2.Testing.DirectoryHelper;

namespace MySteeltoeBuildpack.Tests;

[Collection(nameof(ContainerPlatform.Linux))]
public class LinuxTests(ITestOutputHelper output, CfLinuxfs4StackFixture fixture) : BaseTests(output, fixture)
{
    [Fact]
    public async Task PushDotnetInjector()
    {
        var appDir = RootDirectory / "tests" / "fixtures" / "dotnetapp";
        var stagingContext = _fixture.CreateStagingContext(appDir);
        stagingContext.Buildpacks.Add( RootDirectory / "artifacts" / "latest" / "linux-x64" / "buildpack.zip");
        // you can download dotnet core buildpack off pivnet https://network.pivotal.io/products/dotnet-core-buildpack/
        stagingContext.Buildpacks.Add(RootDirectory / "artifacts" / "dotnet-core_buildpack-cached-cflinuxfs4-v2.4.22+1707253006.zip");
        stagingContext.SkipDetect = true;
        var stageResult = await _fixture.Stage(stagingContext, _output);

        var dropletDir = stageResult.DropletDirectory;
        var context = _fixture.CreateLaunchContext(dropletDir);
        var launchResult = await _fixture.Launch(context, _output);
        var result2 = await launchResult.HttpClient.GetAsync("/");
        result2.IsSuccessStatusCode.Should().BeTrue();
        var result = await launchResult.HttpClient.GetAsync("/actuator");
        result.IsSuccessStatusCode.Should().BeTrue();
    }
}