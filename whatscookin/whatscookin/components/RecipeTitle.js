import React from "react";
import dangerouslySetInnerHTML from 'dangerously-set-inner-html';

export default function RecipeTitle(props){
    return(
        <div
            dangerouslySetInnerHTML={{__html: props.summary}}
        />
    )
}