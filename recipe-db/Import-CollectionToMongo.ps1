$CollectionData = Get-ChildItem -Path .\*.json -Name | ForEach-Object -Process { [System.IO.Path]::GetFileNameWithoutExtension($_) }

foreach ($cd in $CollectionData) {
    mongoimport --uri "mongodb+srv://carlhiggins:whatsc00kin@cluster0.ihno8.mongodb.net/recipe" -c "RecipeStore" "$($cd).json"
}