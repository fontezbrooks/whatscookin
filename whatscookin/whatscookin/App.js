import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import {useEffect, useState} from "react";

export default function App() {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);

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
        <div style={styles}>
            <h1>
                {items.Title}
            </h1>
            <img src={items.Image} alt="Recipe-Image"/>
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
