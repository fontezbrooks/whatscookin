Write-Host "<Downloading New Recipe :)>`n" -ForegroundColor Green

Start-Job -Name Fetch -ScriptBlock { pwsh -File .\fetchdata.ps1 } | Out-Null

Wait-Job -Name "Fetch" | Out-Null

Write-Host "Download Complete`n" -ForegroundColor Cyan

Start-Job -Name Import -ScriptBlock { pwsh -File .\Import-CollectionToMongo.ps1 } | Out-Null

Write-Host "<Importing Latest Recipe in Database>`n" -ForegroundColor Green

Wait-Job -Name "Import" | Out-Null

Write-Host "Database Update Complete. You rock!!!!`n" -ForegroundColor Yellow

