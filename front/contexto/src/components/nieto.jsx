import { useContext } from "react";
import CountContext from "../contexts/count";

export default function Nieto() {
  const { count } = useContext(CountContext);
  return (
    <div className="border-2 border-violet-500">
      <h5>Soy el Nieto</h5>
      <p>Yo recibo el contador: {count}</p>
    </div>
  );
}
