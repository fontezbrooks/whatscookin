import React, {useState} from "react";

export default function RecipeImage(props){
    return(
        <div>
            <img src={props.image} alt={"recipeImage"}/>
        </div>

    )
}