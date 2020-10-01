"..\..\poisnfang.oqtane.framework\oqtane.package\nuget.exe" pack PoisnFang.ThirdParty.nuspec 
XCOPY "*.nupkg" "..\..\poisnfang.oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
