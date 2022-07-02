import React from 'react';
import {Box, Button, Paper, Typography} from "@mui/material";
import "./app.css"
function App() {
    return (
        <Box m={8} p={2} className="App">
            <Paper >
                <Button variant={"contained"}>Bouton</Button>
                <Typography>Texte</Typography>
            </Paper>
        </Box>
    );
}

export default App;
