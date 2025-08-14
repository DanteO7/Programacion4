import { useContext } from "react";
import Abuelo from "./abuelo";
import CountContext from "../contexts/count";

export default function BisAbuelo() {
  const { handleIncrement } = useContext(CountContext);
  return (
    <div className="border-2 border-red-500">
      <h1>Soy el BisAbuelo</h1>
      <button onClick={() => handleIncrement()}>Aumentar</button>
      <Abuelo />
    </div>
  );
}
