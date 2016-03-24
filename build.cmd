@echo Off
ECHO Starting build

set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)
if not "%GitVersion_NuGetVersion%" == "" (
	if "%version%" == "" (
		set version=-Version %GitVersion_NuGetVersion%
	)
)

set PATH=C:\Program Files (x86)\MSBuild\14.0\Bin;%PATH%

if "%nuget%" == "" (  
  set nuget=nuget.exe
)

REM Restoring Packages
ECHO Restoring Packages
call "%nuget%" restore "Linq2OData.sln"
if not "%errorlevel%"=="0" goto failure

ECHO Running MSBUILD
REM Build
msbuild Linq2OData.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

REM Package
ECHO Building pacakges
mkdir Build
call "%nuget%" pack "Linq2OData.Client\Linq2OData.Client.csproj" -IncludeReferencedProjects -o Build -p Configuration=%config% %version%
if not "%errorlevel%"=="0" goto failure


:success
ECHO successfully built project
REM exit 0
goto end

:failure
ECHO failed to build.
REM exit -1
goto end

:end