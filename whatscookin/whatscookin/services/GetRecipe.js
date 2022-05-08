export function GetRecipe(){
    return fetch('http://localhost:5400/api/recipe/random')
        .then(data => data.json());
}