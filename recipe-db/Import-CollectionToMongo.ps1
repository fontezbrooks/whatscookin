$CollectionData = Get-ChildItem -Path .\*.json -Name | ForEach-Object -Process { [System.IO.Path]::GetFileNameWithoutExtension($_) }

foreach ($cd in $CollectionData) {
    mongoimport -d recipes --drop -c "RecipeStore" "$($cd).json"
}