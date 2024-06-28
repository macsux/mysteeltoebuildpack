using CloudFoundry.Buildpack.V2;
using CloudFoundry.Buildpack.V2.MySteeltoeBuildpack;

return BuildpackHost.Create<MySteeltoeBuildpackBuildpack>().Run();