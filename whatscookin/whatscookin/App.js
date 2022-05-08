import { StyleSheet, Text, View } from 'react-native';
import {useCallback, useEffect, useRef, useState} from "react";
import UserFavoritesCard from "./components/userRecipeStoreComponents/UserFavoritesCard";
import MainView from "./components/Main";
import {GetRecipe} from "./services/GetRecipe";
import UserFavoritesMain from "./components/userRecipeStoreComponents/UserFavoritesMain";
import {AddRecipeToUserFavorites} from "./services/AddRecipeToUserFavorites";

export default function App() {
    const [recipe, setRecipe] = useState([]);
    const [current, setCurrent] = useState();
    const [alert, setAlert] = useState(false);
    const [wakeup, setWakeup] = useState([]);
    const [count, setCount] = useState(0);
    const increment = () => {
        setCount(count + 1)
    }
    useEffect(() => {
        let mounted = true;
        GetRecipe().then(recipeData => {
            setRecipe(recipeData)
        })
        return () => mounted = false;
    }, [alert, current, wakeup])
    const handleClick = (e) => {
        setCurrent(e.target.value)
        setAlert(true);
        AddRecipeToUserFavorites(current)
        {increment()}
    }
    return (
        <div>
            <h1>
                Current Recipe:
            </h1>
            {alert && <h2>Recipe Favorite!</h2>}
            <button
                name={"buttonMan"}
                value={recipe._id}
                onClick={(e) => handleClick(e)}
            >
                {recipe.Title}
            </button>
            <UserFavoritesMain count={count}/>
        </div>
    );
};
