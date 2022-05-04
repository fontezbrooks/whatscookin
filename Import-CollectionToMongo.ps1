$CollectionData = Get-ChildItem -Path ./NewRecipes/*.json -Name | ForEach-Object -Process { [System.IO.Path]::GetFileNameWithoutExtension($_) }

Write-Output $CollectionData

foreach ($cd in $CollectionData) {
    mongoimport --uri "mongodb+srv://carlhiggins:whatsc00kin@cluster0.ihno8.mongodb.net/recipe" -c "RecipeStore" --file "./NewRecipes/$($cd).json"
    Move-Item -Path "./NewRecipes/$($cd).json" -Destination ./Old-Recipes
}

