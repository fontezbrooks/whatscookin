import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import {useEffect, useState} from "react";

export default function App() {
  const [posts, setPosts] = useState();
  useEffect(() => {
    async function fetchData() {
      try {
        const response = await fetch(
            "http://localhost:5400/api/recipes"
        );
        const json = await response.json();
        setPosts(json.data.children.map(it => it.data));
      } catch (e) {
        console.error(e);
      }
    }
    fetchData().then(r => console.log(r.response.body));
  }, [])
  return (
      <div>
        <h1>
          {posts}
        </h1>
      </div>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
