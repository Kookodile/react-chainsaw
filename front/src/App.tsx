import React from 'react';
import {Box, Button, buttonClasses, Paper, Stack, Typography} from "@mui/material";
import {ToDo, ToDoApi} from "./api";

const api = new ToDoApi(undefined, "http://localhost:5017");

function App() {

    const [todoTab, setTodoTab] = React.useState<ToDo[]>([]);

    React.useEffect(() => {

        refreshTodo();

        console.log("mount");

    }, []);

    function onClick() {
        api.addTodos({nom: "randomNom", description: "randomDescription"}).then(refreshTodo);

    }

    function clicDelete(id:number) {

        api.deleteTodos(id).then(refreshTodo);


    }

    function refreshTodo() {

        api.getToDos().then((response) => {

            setTodoTab(response.data)

        });
    }

    return (


        <header>
            <Button onClick={onClick} variant={"contained"}>Bouton</Button>
            <Box m={8} p={2} className="App">
                <Paper style={{padding: "2em"}}>

                    {
                        todoTab.map(todo => <Stack m={1} direction={"row"}>
                            <Paper>
                                <Box p={2} mt={2}>
                                    <Typography>{todo.nom} {todo.id}</Typography>
                                    <Button color={"error"} onClick={() => clicDelete(todo.id!)}>Delete</Button>
                                </Box>
                            </Paper>
                        </Stack>)
                    }
                    <pre>
                        {JSON.stringify(todoTab, null, 4)}
                    </pre>
                    <Typography>Texte {todoTab[0]?.id}</Typography>
                </Paper>
            </Box>
        </header>
    );
}

export default App;
