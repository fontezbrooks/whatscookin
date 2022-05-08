import React from 'react';
import {Text, StyleSheet} from 'react-native';

export default function ComponentsScreen(){
    return(
        <Text style={styles.textStyle}>
            HelloComponentScreen!
        </Text>
    )
}

const styles = StyleSheet.create({
    textStyle: {
        fontSize: 30
    }
});