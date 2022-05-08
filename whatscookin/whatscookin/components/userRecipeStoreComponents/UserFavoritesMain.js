import React, {useEffect, useState, useRef} from 'react';
import {GetUserFavorites} from "../../services/GetUserFavorites";

export default function UserFavoritesMain(props){
    const [faveList, setFaveList] = useState([]);
    const [alert, setAlert] = useState(false);
    useEffect(() => {
        let mounted = true;
        GetUserFavorites().then(favorites => {
            setFaveList(favorites)
            setAlert(true);
        })
        console.log(props.count)
        return () => mounted = false;
    }, [props.count]);
    return(
        <div>
            <h1>
                Your Favorites:
            </h1>
            {alert && <h2>Recipe FavoriteTest!</h2>}
            <ul>
                {faveList.map(item => <li key={item._id}>{item.Title} {props.count}</li>)}
            </ul>

        </div>
    )
}