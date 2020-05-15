"..\..\oqtane.framework\oqtane.package\nuget.exe" pack Tres.Customers.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
