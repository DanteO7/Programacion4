import { useState } from "react";
import { ContextoContador } from "./contexto-contador";

export const ProveedorContador = ({ children }) => {
  const [contador, setContador] = useState(0);

  return (
    <ContextoContador.Provider value={{ contador, setContador }}>
      {children}
    </ContextoContador.Provider>
  );
};
