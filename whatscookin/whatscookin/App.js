import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import {useEffect, useState} from "react";
import RecipeImage from "./components/RecipeImage";
import RecipeTitle from "./components/RecipeTitle";
import parse from 'html-react-parser';
import dangerouslySetInnerHTML from 'dangerously-set-inner-html';
import Box from "@mui/material/Box";
import Fab from "@mui/material/Fab";
import FavoriteIcon from "@mui/icons-material/Favorite";
import NotInterestedIcon from "@mui/icons-material/NotInterested";
import {Grid} from "@mui/material";


export default function App() {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);

    const handleClick = () => {
        const url = "http://localhost:5400/api/recipe/random";
        fetch(url)
            .then((response) => response.json())
            .then((result) => {
                setItems(result);
            })
            .catch((error) => console.log(error));
    };
  useEffect(() => {
    fetch("http://localhost:5400/api/recipe/random")
        .then(res => res.json())
        .then(
            (result) => {
              setIsLoaded(true);
              setItems(result);
            },
            (error) => {
              setIsLoaded(true);
              setError(error);
            }
        )
  }, [])
  if (error) {
    return <div>Error: {error.message}</div>;
  } else if (!isLoaded) {
    return <div>Loading...</div>;
  } else {
    return (
        <div>
            <RecipeImage
                title={items.Title}
                image={items.Image}
                instructions={items.Instructions}
                summary={items.Summary}
                readIn={items.ReadyInMinutes}
            />
            <Grid  container
                   spacing={1}
                   direction="row"
                   alignItems="center"
                   justifyContent="center"
                   style={{ minHeight: '1vh' }}>
                <Box sx={{ '& > :not(style)': { m: 1 } }}>
                    <Fab color="primary" aria-label="add">
                        <FavoriteIcon onClick={handleClick} />
                    </Fab>
                    <Fab color="secondary" aria-label="edit">
                        <NotInterestedIcon onClick={handleClick} />
                    </Fab>
                </Box>
            </Grid>
        </div>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
