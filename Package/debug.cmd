XCOPY "..\Client\bin\Debug\netstandard2.1\PoisnFang.ThirdParty.Client.Oqtane.dll" "..\..\poisnfang.oqtane.framework\Oqtane.Server\bin\Debug\netcoreapp3.1\" /Y
XCOPY "..\Client\bin\Debug\netstandard2.1\PoisnFang.ThirdParty.Client.Oqtane.pdb" "..\..\poisnfang.oqtane.framework\Oqtane.Server\bin\Debug\netcoreapp3.1\" /Y

XCOPY "..\Client\bin\Debug\netstandard2.1\ChartJs.Blazor.dll" "..\..\poisnfang.oqtane.framework\Oqtane.Server\bin\Debug\netcoreapp3.1\" /Y

XCOPY "..\Client\bin\Debug\netstandard2.1\BlazorInputFile.dll" "..\..\poisnfang.oqtane.framework\Oqtane.Server\bin\Debug\netcoreapp3.1\" /Y

XCOPY "..\Server\bin\Debug\netcoreapp3.1\PoisnFang.ThirdParty.Server.Oqtane.dll" "..\..\poisnfang.oqtane.framework\Oqtane.Server\bin\Debug\netcoreapp3.1\" /Y
XCOPY "..\Server\bin\Debug\netcoreapp3.1\PoisnFang.ThirdParty.Server.Oqtane.pdb" "..\..\poisnfang.oqtane.framework\Oqtane.Server\bin\Debug\netcoreapp3.1\" /Y
XCOPY "..\Shared\bin\Debug\netstandard2.1\PoisnFang.ThirdParty.Shared.Oqtane.dll" "..\..\poisnfang.oqtane.framework\Oqtane.Server\bin\Debug\netcoreapp3.1\" /Y
XCOPY "..\Shared\bin\Debug\netstandard2.1\PoisnFang.ThirdParty.Shared.Oqtane.pdb" "..\..\poisnfang.oqtane.framework\Oqtane.Server\bin\Debug\netcoreapp3.1\" /Y
XCOPY "..\Server\wwwroot\Modules\PoisnFang.ThirdParty\*" "..\..\poisnfang.oqtane.framework\Oqtane.Server\wwwroot\Modules\PoisnFang.ThirdParty\" /Y /S /I
