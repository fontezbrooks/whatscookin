export function AddRecipeToUserFavorites(id){
    const url = `http://localhost:5400/api/recipe/user/favorite/${id}`
    const requestHeaders = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(url)
    }
    return fetch(url, requestHeaders).then(data => data.json());

}