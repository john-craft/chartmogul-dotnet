REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"
 
REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0ChartMogulTest.trx" del "%~dp0ChartMogulTest.trx%"
 
REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"
 
REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics
 
REM Generate the report output based on the test results
if %errorlevel% equ 0 (
 call :RunReportGeneratorOutput
)
 
REM Launch the report
if %errorlevel% equ 0 (
 call :RunLaunchReport
)
exit /b %errorlevel%
 
:RunOpenCoverUnitTestMetrics
"%~dp0..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\bin\Debug\TestChartMogul.dll\" /resultsfile:\"%~dp0ChartMogulTest.trx\"" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0GeneratedReports\ChartMogulReport.xml"
exit /b %errorlevel%
 
:RunReportGeneratorOutput
"%~dp0..\..\packages\ReportGenerator.2.5.1\tools\ReportGenerator.exe" ^
-reports:"%~dp0GeneratedReports\ChartMogulReport.xml" ^
-targetdir:"%~dp0GeneratedReports\ReportGenerator Output"
exit /b %errorlevel%
 
:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGenerator Output\index.htm"
exit /b %errorlevel%