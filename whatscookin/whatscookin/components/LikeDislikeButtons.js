import React from "react";
import Box from '@mui/material/Box';
import Fab from '@mui/material/Fab';
import NotInterestedIcon from '@mui/icons-material/NotInterested';
import FavoriteIcon from '@mui/icons-material/Favorite';

export default function LikeDislikeButtons() {
    const [selected, setSelected] = React.useState(false);

    return (
        <Box sx={{ '& > :not(style)': { m: 1 } }}>
            <Fab color="primary" aria-label="add">
                <FavoriteIcon />
            </Fab>
            <Fab color="secondary" aria-label="edit">
                <NotInterestedIcon />
            </Fab>
        </Box>
    );
}