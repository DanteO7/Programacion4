import { useCountStore } from "../store/use-store";

export default function Botones() {
  const { aumentar, decrementar, resetear } = useCountStore();
  return (
    <div>
      <button onClick={aumentar}>Aumentar</button>
      <button onClick={decrementar}>Decrementar</button>
      <button onClick={resetear}>Resetear</button>
    </div>
  );
}
