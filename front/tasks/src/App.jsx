import FormTask from "./components/form-task";
import TaskProvider from "./contexts/tasks/provider";

function App() {
  return (
    <>
      <h1>App de Tareas</h1>
      <TaskProvider>
        <FormTask />
      </TaskProvider>
    </>
  );
}

// los contextos, siguiendo una buena practica, se crean 3 archivos:
// el primero es el contexto propiemente dicho
// el segundo es el proveedor del contexto
// el tercero es un custom hook que manipula las funcionalidades (si las posee) del contexto

export default App;
