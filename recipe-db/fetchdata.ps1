$data = Invoke-RestMethod -Uri "https://api.spoonacular.com/recipes/random?number=1&tags=main course&apiKey=f59785e0cb6241beb58e5c6ce953bf8b&"

$FileName = $data.recipes.title

$FileNameNoSpace = $FileName.replace(' ', '')

$data.recipes | ConvertTo-Json -Depth 100 | Out-File ($FileNameNoSpace + ".json")


