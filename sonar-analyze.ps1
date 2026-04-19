$token = "sqp_f1b074dc55353744e3c273a45a7b8c64eb65d9ef"
$projectKey = "mediatekdocuments"
$sonarUrl = "http://localhost:9000"

SonarScanner.MSBuild.exe begin `
  /k:$projectKey `
  /d:sonar.host.url=$sonarUrl `
  /d:sonar.token=$token

MsBuild.exe /t:Rebuild

SonarScanner.MSBuild.exe end `
  /d:sonar.token=$token