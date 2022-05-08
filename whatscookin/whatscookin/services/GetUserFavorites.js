export function GetUserFavorites(){
    return fetch('http://localhost:5400/api/recipe/user')
        .then(data => data.json());
}