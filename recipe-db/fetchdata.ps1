$data = Invoke-RestMethod -Uri "https://api.spoonacular.com/recipes/random?number=3&tags=main course&apiKey=f59785e0cb6241beb58e5c6ce953bf8b&"

$FileName = (Get-Date).tostring("dd-MM-yyyy-hh-mm-ss")

$data | ConvertTo-Json -Depth 100 | Out-File ($FileName + ".json")


