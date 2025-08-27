import { useContext } from "react";
import { ContextoContador } from "../context/contexto-contador";

export default function DisplayContador() {
  const { contador } = useContext(ContextoContador);

  return <h2>Contador: {contador}</h2>;
}
