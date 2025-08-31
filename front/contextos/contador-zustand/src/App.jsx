import { useEffect } from "react";
import Botones from "./components/botones";
import DisplayContador from "./components/display-contador";
import { useUsersStore } from "./store/use-store";

function App() {
  const { usuarios, cargarUsuarios } = useUsersStore();

  useEffect(() => {
    cargarUsuarios();
  }, [cargarUsuarios]);

  return (
    <main>
      <h1>Context con ZUSTAND</h1>
      <DisplayContador />
      <Botones />
      <h2>Usuarios</h2>
      <ul>
        {usuarios.length === 0 ? (
          <li>Cargando...</li>
        ) : (
          usuarios.map((usuario) => <li key={usuario.id}>{usuario.name}</li>)
        )}
      </ul>
    </main>
  );
}

export default App;
