import { useContext } from "react";
import { ContextoContador } from "../context/contexto-contador";

export default function Boton() {
  const { contador, setContador } = useContext(ContextoContador);
  return (
    <div>
      <button onClick={() => setContador(contador + 1)}>sumar contador</button>
      <button onClick={() => setContador(contador - 1)}>restar contador</button>

      <button onClick={() => setContador(0)}>resetear contador</button>
    </div>
  );
}
